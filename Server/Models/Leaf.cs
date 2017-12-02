using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspCoreServer.Models
{
   [DataContract()]
    public class Leaf : BaseCollectionItem
    {
        public string ItemArea { set; get; }

        [DataMember(Name = "ContentImages_small")]
        public string ItemContentImages_small { set; get; }

        [DataMember(Name = "ContentImages_large")]
        public string ItemContentImages_large { set; get; }

        //Setting Default value
        public Leaf()
        {
            ItemCreatedDate = DateTime.Now;
        }
    }
}
