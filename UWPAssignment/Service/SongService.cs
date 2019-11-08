using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UWPAssignment.Entity;

namespace UWPAssignment.Service
{
    class SongService : ISongService
    {
        public Song CreateSong(MemberCredential memberCredential, Song song)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(memberCredential.token);
            var dataToSend = JsonConvert.SerializeObject(song);
            var content = new StringContent(dataToSend, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(ProjectConfiguration.SONG_CREATE_URL, content).GetAwaiter().GetResult();
            var jsonContent = response.Content.ReadAsStringAsync().Result;
            var responseSong = JsonConvert.DeserializeObject<Song>(jsonContent);
            Debug.WriteLine("Create success with song name: " + responseSong.name);
            return responseSong;
        }


        public List<Song> GetAllSong(MemberCredential memberCredential)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(memberCredential.token);
            var response = httpClient.GetAsync(ProjectConfiguration.SONG_GET_ALL).GetAwaiter().GetResult();
            var list = JsonConvert.DeserializeObject<List<Song>>(response.Content.ReadAsStringAsync().Result);
            Debug.WriteLine(response);
            return list;
        }

        public List<Song> GetMineSongs(MemberCredential memberCredential)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(memberCredential.token);
            var response = httpClient.GetAsync(ProjectConfiguration.SONG_GET_MINE).GetAwaiter().GetResult();
            var listSong = JsonConvert.DeserializeObject<List<Song>>(response.Content.ReadAsStringAsync().Result);
            return listSong;
        }
    }
}
