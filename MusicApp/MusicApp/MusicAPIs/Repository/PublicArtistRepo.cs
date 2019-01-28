﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.MusicAPIs.JSON_Classes;
using RestSharp;
using Newtonsoft.Json;

namespace MusicApp.MusicAPIs.Repository
{
    static class PublicArtistRepo
    {
        /// <summary>
        /// It is For Getting Artists form the web service, and these artists are public not fans
        /// </summary>
        /// <param name="userauth"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static List<JsonPublicArtist> GetPublicArtist(User_Authentication userauth,int limit)
        {
            try
            {

                PublicArtist PubArtists = new PublicArtist();
                RestClient client = new RestClient(userauth.token.URL);
                var Request = new RestRequest("artists");
                Request.AddParameter("client_id", userauth.token.Client_ID);
                Request.AddParameter("access_token", userauth.token.Access_Token);
                Request.AddParameter("limit", limit.ToString());
                var tRsponse = client.Execute(Request);
                PubArtists = JsonConvert.DeserializeObject<PublicArtist>(tRsponse.Content);
                return PubArtists.results;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
