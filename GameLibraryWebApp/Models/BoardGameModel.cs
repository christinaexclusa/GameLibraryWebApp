using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLibraryWebApp.Models
{
    public class BoardGameModel
    {
        [Key]
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        
        //Added this for a publisher text box on the create screen
        [NotMapped]
        public string? NewPublisher { get; set; }
        public virtual PublisherModel? Publishers { get; set; }
        //naming is virtual Publishers and Id of the linked table (Id in publisher model)
        [ForeignKey("PublisherModel")]
        public int PublishersId { get; set; }
        //this is going to be used for the publisher name display
        [NotMapped]
        public string Publisher
        {
            get
            {
                if(Publishers is not null)
                {
                    return Publishers.Name;
                }
                else
                {
                    return "";
                }
            }
        }
        
        

    }
}
