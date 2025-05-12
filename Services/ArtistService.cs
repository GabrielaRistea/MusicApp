﻿using Music_App.Models;
using Music_App.Repositories;
using Music_App.Repositories.Interfaces;
using Music_App.Services.Interfaces;

namespace Music_App.Services
{
    public class ArtistService : IArtistService
    {
        private IArtistRepository _artistRepository;
        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public List<Artist> GetAllArtists() {
            return _artistRepository.GetAll().ToList();
        }
        public async Task AddArtistAsync(Artist artist)
        {
            if (artist.ImageFile != null && artist.ImageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await artist.ImageFile.CopyToAsync(ms);
                    artist.ArtistImage = ms.ToArray();
                }
            }
            _artistRepository.Create(artist);
            _artistRepository.Save();
        }
        public async Task UpdateArtistAsync(Artist artist)
        {
            using var ms = new MemoryStream();

            if (artist.ImageFile != null && artist.ImageFile.Length > 0)
            {
                await artist.ImageFile.CopyToAsync(ms);
                artist.ArtistImage = ms.ToArray();
            }
            _artistRepository.Update(artist);
            _artistRepository.Save();
        }
        public void DeleteArtist(int id)
        {
            var artist = _artistRepository.GetById(id);
            if (artist != null)
            {
                _artistRepository.Delete(artist);
                _artistRepository.Save();
            }
        }
        public bool ArtistExists(int id)
        {
            return _artistRepository.ArtistExists(id);
        }
        public Artist GetArtistById(int id)
        {
            return _artistRepository.GetById(id);
        }
        public List<Album> GetAllAlbums()
        {
            return _artistRepository.GetAllAlbums().ToList();
        }

        public List<SongArtist> GetAllSongArtists()
        {
            return _artistRepository.GetAllSongArtists().ToList();
        }
    }
}
