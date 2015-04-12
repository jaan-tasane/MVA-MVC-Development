using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.Models.Repositories
{
    public class MusicStoreDataContextInitializer : DropCreateDatabaseAlways<MusicStoreDataContext>
    {
        protected override void Seed(MusicStoreDataContext context)
        {
            //Initialize
            Artist artist = new Artist() { Name = "First Artist" };

            context.Artists.Add(artist);

            context.Artists.Add(new SoloArtist() { Name = "Solo Artist", Instrument = "Drums" });

            context.Albums.Add(new Album() { Artist = artist, Title = "First Album" });
            context.Albums.Add(new Album() { Artist = artist, Title = "Second Album" });
            //Inline Add after initialization!!

            context.Albums.Add(new Album()
            {
                Artist = context.Artists.Add(new Artist() { Name = "Second Artist" }),
                Title = "Third Album"
            });

            context.SaveChanges();
        }
    }
}