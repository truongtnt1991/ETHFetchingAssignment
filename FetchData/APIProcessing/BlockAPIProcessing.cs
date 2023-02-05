using System;
using FetchData.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace FetchData.APIProcessing
{
	public class BlockAPIProcessing : IBlockAPIProcessing
    {
        private readonly RestClient _client;
        private readonly IOptions<Settings> _settings;
        public BlockAPIProcessing(IOptions<Settings> settings)
        {
            _client = new RestClient(settings.Value.APIEndpoint);
            _settings = settings;

        }
        public async Task<BlockNumber?> GetBlockByNumber(string blockNumber)
        {
            var request = new RestRequest($"?module=proxy&action=eth_getBlockByNumber&tag={blockNumber}&boolean=true&apikey={_settings.Value.APIKey}");
            var response = await _client.ExecuteGetAsync(request);
            if (!response.IsSuccessful)
            {
                return null;
            }
            var block = JsonConvert.DeserializeObject<BlockNumber>(response.Content);
            return block ?? new BlockNumber();
        }

        public async Task<BlockTransactionCount?> GetBlockTransactionCountByNumber(string blockNumber)
        {
            var request = new RestRequest($"?module=proxy&action=eth_getBlockTransactionCountByNumber&tag={blockNumber}&apikey={_settings.Value.APIKey}");
            var response = await _client.ExecuteGetAsync(request);
            if (!response.IsSuccessful)
            {
                return null;
            }
            var block = JsonConvert.DeserializeObject<BlockTransactionCount>(response.Content);
            return block ?? new BlockTransactionCount();
        }

        public async Task<BlockTransationIndex?> GetTransactionByBlockNumberAndIndex(string blockNumber, string index)
        {
            var request = new RestRequest($"?module=proxy&action=eth_getTransactionByBlockNumberAndIndex&tag={blockNumber}&index={index}&apikey={_settings.Value.APIKey}");
            var response = await _client.ExecuteGetAsync(request);
            if (!response.IsSuccessful)
            {
                return null;
            }
            var block = JsonConvert.DeserializeObject<BlockTransationIndex>(response.Content);
            return block ?? new BlockTransationIndex();
        }
    }
}

