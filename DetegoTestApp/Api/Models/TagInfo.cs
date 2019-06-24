using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class TagInfo
    {
        /// <summary>
        /// Fake identifier to improve seek search
        /// </summary>
        [Key]
        public int Id { get; set; }
        public string RfidKey { get; set; }
        public int ActivationCount { get; set; }

        public virtual IList<ActivateEvent> ActivateEvents { get; set; }
    }
}