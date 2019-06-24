using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class RfidReaderWrapper
    {
        [Key]
        public int Id { get; set; }

        public ReaderStatus Status { get; set; }

        public IList<TagInfo> Infos { get; set; }

    }

    /// <summary>
    /// State of the reader
    /// </summary>
    public enum ReaderStatus
    {
        Activated,
        Deactivated
    }
}