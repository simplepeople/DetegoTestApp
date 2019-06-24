using System.Collections.Generic;

namespace Api.Dtos
{
    public class GetInfosResponse
    {
        public int ReaderId { get; set; }
        public TagDto[] Tags { get; set; }
    }
}