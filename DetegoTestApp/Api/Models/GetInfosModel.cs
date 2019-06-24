using System.Collections.Generic;

namespace Api.Models
{
    public class GetInfosModel
    {
        public int ReaderId { get; set; }

        public IList<TagInfo> TagInfos { get; set; }
    }
}
