using System.Collections.Generic;

namespace GameLibraryWebApp.Models
{
    public class PublisherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //holds all the board games associated with the Id property
        public virtual IEnumerable<BoardGameModel>? BoardGames { get; set; }
    }
}
