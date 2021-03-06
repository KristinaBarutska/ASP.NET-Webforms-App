﻿using MovieScrapper.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MovieScrapper.Data.Interfaces;

namespace MovieScrapper.Data
{
    public class WatchedMovieRepository: IWatchedMovieRepository
    {
        public Watched AddWatchedEntity(Watched watchedEntity)
        {
            using (var ctx = new MovieContext())
            {
                watchedEntity = ctx.Watched.Add(watchedEntity);
                ctx.SaveChanges();
            }

            return watchedEntity;
        }

        public IEnumerable<Watched> GetAllUsersWatchedAMovie()
        {

            using (var ctx = new MovieContext())
            {
                var watched = ctx.Watched.Include(w => w.Movies);
                return watched;
            }
        }

        public IEnumerable<Watched> GetAllWatchedMovies(string userId)
        {

            using (var ctx = new MovieContext())
            {
                var watched = ctx.Watched.Include(w => w.Movies).Where(x => x.UserId == userId).ToList();

                return watched;
            }
        }

        public Watched GetUserWatchedEntity(string userId)
        {
            using (var ctx = new MovieContext())
            {
                var foundedEntity = ctx.Watched.Where(x => x.UserId == userId).SingleOrDefault();
                return foundedEntity;
            }
        }
       
    }
}
