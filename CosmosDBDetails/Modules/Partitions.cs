using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBDetails.Modules
{
    public class Partitions
    {
        public DocumentClient Client { get; set; }
        private Uri DocumentCollectionUri { get; set; }

        public Partitions(DocumentClient client)
        {
            this.Client = client;
        }
        public void GetPartitionDetails()
        {

        }
        private async Task<List<PartitionKeyRange>> GetKeyRange()
        {
            string keyRangeToken = null;
            List<PartitionKeyRange> partitionKeyRanges = new List<PartitionKeyRange>();
            do
            {
                FeedResponse<PartitionKeyRange> pkRangesResponse = await Client.ReadPartitionKeyRangeFeedAsync(
                                                                            DocumentCollectionUri,
                                                                            new FeedOptions {
                                                                                RequestContinuation = keyRangeToken,
                                                                                DisableRUPerMinuteUsage = true,
                                                                                PopulateQueryMetrics = true
                                                                            });
                partitionKeyRanges.AddRange(pkRangesResponse);
                keyRangeToken = pkRangesResponse.ResponseContinuation;
            }
            while (keyRangeToken != null);
            return partitionKeyRanges;

        }
    }
}
