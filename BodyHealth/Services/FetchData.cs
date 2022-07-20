using System;
using System.Collections.Generic;
using System.Text;
using BodyHealth.Models;
using Microsoft.Azure.Cosmos;

namespace BodyHealth.Services
{
    public class FetchData
    {

        async void GetFacilitiesInState(string state)
        {
            CosmosClient cosmosClient = new CosmosClient(Cosmos.Endpoint, Cosmos.Key);
            Database database = await
                    cosmosClient.CreateDatabaseIfNotExistsAsync("reprohealthdb");
            Container container = await
                    database.CreateContainerIfNotExistsAsync(
                        "facilities",
                        "/facilites",
                        400);

            QueryDefinition queryDefinition = new QueryDefinition($"SELECT * FROM c WHERE state={state}");

            FeedIterator<Facility> queryResultSetIterator = container.GetItemQueryIterator<Facility>(queryDefinition);

            List<Facility> facilityresults = new List<Facility>();

            while (queryResultSetIterator.HasMoreResults)
            {

                FeedResponse<Facility> results = await queryResultSetIterator.ReadNextAsync();
                foreach (Facility place in results)
                {
                    facilityresults.Add(place);
                }
            }
        }

        async void GetFacilitiesnearState(string state)
        {
            CosmosClient cosmosClient = new CosmosClient(Cosmos.Endpoint, Cosmos.Key);
            Database database = await
                    cosmosClient.CreateDatabaseIfNotExistsAsync("reprohealthdb");
            Container container = await
                    database.CreateContainerIfNotExistsAsync(
                        "facilities",
                        "/facilites",
                        400);



            QueryDefinition queryDefinition = new QueryDefinition($"SELECT * FROM c WHERE state={state}");

            FeedIterator<Facility> queryResultSetIterator = container.GetItemQueryIterator<Facility>(queryDefinition);

            List<Facility> facilityresults = new List<Facility>();

            while (queryResultSetIterator.HasMoreResults)
            {

                FeedResponse<Facility> results = await queryResultSetIterator.ReadNextAsync();
                foreach (Facility place in results)
                {
                    facilityresults.Add(place);
                }
            }
        }

}
