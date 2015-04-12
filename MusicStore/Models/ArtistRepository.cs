using MusicStore.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class ArtistRepository : Repository<Artist>
    {
        public List<Artist> GetbyNames(String name)
        {
            return DbSet.Where(a => a.Name.Contains(name)).ToList(); 
        }

        public List<SoloArtist> GetSoloArtist()
        {
            return DbSet.OfType<SoloArtist>().ToList();
        }
    }
}