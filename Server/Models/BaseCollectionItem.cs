using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AspCoreServer.Models
{
    [DataContract()]
    public class BaseCollectionItem
    {
        [DataMember(Name = "id")]
        public long ID { get; set; }
        [DataMember(Name = "source")]
        public string ItemSource { set; get; }
        [DataMember(Name = "path")]
        public string ItemPath { set; get; }
        [DataMember(Name = "url")]
        public string ItemUrl { set; get; }
        [DataMember(Name = "name")]
        public string ItemName { set; get; }
        [DataMember(Name = "title")]
        public string ItemTitle { set; get; }
        [DataMember(Name = "description")]
        public string ItemDescription { set; get; }
        [DataMember(Name = "summary")]
        public string ItemSummary { set; get; }
        [DataMember(Name = "content_raw")]
        public string ItemContent_Raw { set; get; }
        [DataMember(Name = "content_rich")]
        public string ItemContent_Rich { set; get; }
        [DataMember(Name = "content_text")]
        public string ItemContent_Text { set; get; }
        [DataMember(Name = "ContentImages")]
        public string ItemContent_Image { set; get; }
        [DataMember(Name = "ContentImages_url")]
        public string ItemContent_Image_Url { set; get; }
        [DataMember(Name = "tags")]
        public string ItemTags { set; get; }
        [DataMember(Name = "keywords")]
        public string ItemKeywords { set; get; }
        [DataMember(Name = "Category")]
        public string ItemCategories { set; get; }
        [DataMember(Name = "type")]
        public string ItemType { set; get; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ItemCreatedDate { set; get; }

        //Setting Default value
        public BaseCollectionItem()
        {
            ItemCreatedDate = DateTime.Now;
        }
    }
}
