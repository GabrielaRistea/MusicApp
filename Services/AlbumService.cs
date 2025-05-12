using Music_App.DTOs;
using Music_App.Models;
using Music_App.Repositories;
using Music_App.Repositories.Interfaces;
using Music_App.Services.Interfaces;

namespace Music_App.Services
{
    public class AlbumService : IAlbumService
    {
        private IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        public AlbumService(IAlbumRepository albumRepository, IArtistRepository artistRepository)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
        }

        public List<Album> GetAllAlbums()
        {
            return _albumRepository.GetAll().ToList();
        }
        public async Task AddAlbumAsync(Album album)
        {
            using var ms = new MemoryStream();
            if (album.ImageFile != null && album.ImageFile.Length > 0)
            {
                    await album.ImageFile.CopyToAsync(ms);
                    album.Image = ms.ToArray();
            }
            _albumRepository.Create(album);
            _albumRepository.Save();
        }
        public async Task UpdateAlbumAsync(Album album)
        {
            using var ms = new MemoryStream();

            if (album.ImageFile != null && album.ImageFile.Length > 0)
            {
                await album.ImageFile.CopyToAsync(ms);
                album.Image = ms.ToArray();
            }
            _albumRepository.Update(album);
            _albumRepository.Save();
        }
        public void DeleteAlbum(int id)
        {
            var album = _albumRepository.GetById(id);
            if (album != null)
            {
                _albumRepository.Delete(album);
                _albumRepository.Save();
            }
        }
        public bool AlbumExists(int id)
        {
            return _albumRepository.AlbumExists(id);
        }
        public Album GetAlbumById(int id)
        {
            return _albumRepository.GetById(id);
        }
        public Album GetAlbumAndRelatedById(int id)
        {
            return _albumRepository.GetByIdWithRelatedEntities(id);
        }
        public List<Artist> GetAllArtists()
        {
            return _albumRepository.GetAllArtists().ToList();
        }

        public List<Song> GetAllSongs()
        {
            return _albumRepository.GetAllSongs().ToList();
        }

        public ArtistDTO     GetAllAlbumsByArtist(int artistId) 
        {
            var albums = _albumRepository.GetAlbumsByArtist(artistId).ToList();
            var artist = _artistRepository.GetById(artistId);

            var result = new ArtistDTO
            {
                Albums = albums.Select(a => new AlbumDto()
                {
                    Id = a.Id,
                    Image = a.Image,
                    ReleaseDate = a.ReleaseDate,
                    Title = a.Title,
                    Duration = a.Duration,
                }).ToList(),
                Name = artist.Name,
                ArtistImage = artist.ArtistImage,
                Description = artist.Description,
                Id = artist.Id,
            };

            return result;
        }
    }
}
