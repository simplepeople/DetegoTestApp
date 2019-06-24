using System;
using System.Threading.Tasks;
using Api.Dal;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Rfid;

namespace Api.Services
{
    public class ReaderService : IDisposable
    {
        public RfidReader RfidReader { get; set; }
        public RfidReaderWrapper RfidReaderWrapper { get; set; }

        private ReaderService(RfidReader rfidReader, RfidReaderWrapper wrapper)
        {
            RfidReader = rfidReader;
            RfidReaderWrapper = wrapper;
            RfidReader.TagSeen += RfidReader_TagSeen;
        }

        public static async Task<ReaderService> Create(RfidReader rfidReader)
        {
            //perhaps there are need to be some logic to init reader
            var wrapper = new RfidReaderWrapper();
            var service = new ReaderService(rfidReader, wrapper);
            using (var context = new ReaderContext())
            {
                await context.ReaderWrappers.AddAsync(wrapper);
            }
            return service;
        }

        public async Task<GetInfosModel> GetInfos(int? readerId)
        {
            var responseModel = new GetInfosModel();
            using (var context = new ReaderContext())
            {
                RfidReaderWrapper wrapper;
                if (!readerId.HasValue || readerId.Value==RfidReaderWrapper.Id)
                {
                    wrapper = RfidReaderWrapper;
                    
                }
                else
                {
                    wrapper = await context.ReaderWrappers.FindAsync();
                    if (wrapper == null)
                        return responseModel;
                }

                responseModel.TagInfos = wrapper.Infos;
                responseModel.ReaderId = wrapper.Id;
            }

            return responseModel;
        }

        private async void RfidReader_TagSeen(object sender, TagSeenEventArgs e)
        {
            using (var context = new ReaderContext())
            {
                var tag = await context.TagInfos.FirstAsync(x => x.RfidKey == e.Identifier);
                if (tag == null)
                {
                    tag = new TagInfo
                    {
                        ActivationCount = 1,
                        RfidKey = e.Identifier,
                    };
                    await context.TagInfos.AddAsync(tag);
                }

                await context.ActivateEvents.AddAsync(new ActivateEvent
                {
                    EventTime = DateTime.UtcNow,
                    TagInfo = tag
                });
            }
        }

        public async Task ActivateReader()
        {
            RfidReader.Activate();
            await UpdateWrapperStatus(ReaderStatus.Activated);
        }

        public async Task DeactivateReader()
        {
            RfidReader.Deactivate();
            await UpdateWrapperStatus(ReaderStatus.Deactivated);
        }

        private async Task UpdateWrapperStatus(ReaderStatus status)
        {
            using (var context = new ReaderContext())
            {
                context.ReaderWrappers.Attach(RfidReaderWrapper);
                RfidReaderWrapper.Status = status;
                await context.SaveChangesAsync();
            }
        }


        public void Dispose()
        {
            RfidReader?.Dispose();
        }
    }
}
