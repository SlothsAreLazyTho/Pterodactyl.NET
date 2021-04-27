﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pterodactyl.NET.Objects.Admin;
using Pterodactyl.NET.Objects.Admin.NodeAttributes;

using RestSharp;

namespace Pterodactyl.NET.Endpoints.Admin
{
    public class NodeEndpoints : BaseEndpoint
    {
        internal NodeEndpoints(IRestClient client) : base(client)
        { }

        public async Task<IEnumerable<Node>> GetAllNodesAsync(CancellationToken token = default)
        {
            var request = new RestRequest("/api/application/nodes");

            var response = await HandleRequest<IEnumerable<Node>>(request, token);

            return response.Data;
        }

        public async Task<IEnumerable<Node>> GetAllNodesAsync(Func<Node, bool> func, CancellationToken token = default)
        {
            var users = await GetAllNodesAsync(token);
            return users.Where(func);
        }

        public async Task<Node> GetNodeByIdAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nodes/{id}");

            var response = await HandleRequest<Node>(request, token);

            return response.Data;
        }

        public async Task<IEnumerable<Node>> FindNodesByPublicAsync(bool isPublic, CancellationToken token = default)
        {
            return await GetAllNodesAsync(c => c.Public == isPublic, token);
        }

        public async Task<IEnumerable<Node>> FindNodesByFqdnAsync(string fqdn, CancellationToken token = default)
        {
            return await GetAllNodesAsync(c => c.Fqdn == fqdn, token);
        }

        public async Task<IEnumerable<Node>> FindNodesByLocationIdAsync(int id, CancellationToken token = default)
        {
            return await GetAllNodesAsync(c => c.LocationId == id, token);
        }

        public async Task<IEnumerable<Node>> FindNodesByLocationAsync(Location location, CancellationToken token = default)
        {
            return await GetAllNodesAsync(c => c.LocationId == location.Id, token);
        }

        public async Task<IEnumerable<Node>> FindMainstanceNodesAsync(CancellationToken token = default)
        {
            return await GetAllNodesAsync(c => c.IsMainstanceMode == true, token);
        }

        public async Task<Node> CreateNodeAsync(Action<NodeOptions> options, CancellationToken token = default)
        {
            var node = new NodeOptions();
            options.Invoke(node);
            var request = new RestRequest($"/api/application/nodes", Method.POST)
                .AddJsonBody(node);

            var response = await HandleRequest<Node>(request, token);

            return response.Data;
        }

        public async Task<Node> CreateNodeAsync(NodeOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nodes", Method.POST)
                .AddJsonBody(options);

            var response = await HandleRequest<Node>(request, token);

            return response.Data;
        }

        public async Task<Node> EditNodeAsync(int id, Action<NodeOptions> options, CancellationToken token = default)
        {
            var nodeOptions = new NodeOptions();
            options.Invoke(nodeOptions);

            var request = new RestRequest($"/api/application/nodes/{id}", Method.PATCH)
                .AddJsonBody(nodeOptions);

            var response = await HandleRequest<Node>(request, token);

            return response.Data;
        }

        public async Task<Node> EditNodeAsync(Node node, Action<NodeOptions> options, CancellationToken token = default)
        {
            return await EditNodeAsync(node.Id, options, token);
        }

        public async Task<Node> EditNodeAsync(int id, NodeOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nodes/{id}", Method.PATCH)
                .AddJsonBody(options);

            var response = await HandleRequest<Node>(request, token);

            return response.Data;
        }

        public async Task<Node> EditNodeAsync(Node node, NodeOptions options, CancellationToken token = default)
        {
            return await EditNodeAsync(node.Id, options, token);
        }

        public async Task<bool> DeleteNodeAsync(int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nodes/{id}", Method.DELETE);

            var response = await HandleRequest(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> DeleteNodeAsync(Node node, CancellationToken token = default)
        {
            return await DeleteNodeAsync(node.Id, token);
        }



        public async Task<IEnumerable<Allocation>> GetAllocationsAsync(int nodeId, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nodes/{nodeId}/allocations");

            var response = await HandleRequest<IEnumerable<Allocation>>(request, token);

            return response.Data;
        }

        public async Task<IEnumerable<Allocation>> GetAllocationsAsync(int nodeId, Func<Allocation, bool> func, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nodes/{nodeId}/allocations");

            var response = await HandleRequest<IEnumerable<Allocation>>(request, token);

            return response.Data.Where(func);
        }

        public async Task<IEnumerable<Allocation>> GetAllocationsAsync(Node node, CancellationToken token = default)
        {
            return await GetAllocationsAsync(node.Id, token);
        }

        public async Task<IEnumerable<Allocation>> GetAllocationsAsync(Node node, Func<Allocation, bool> func, CancellationToken token = default)
        {
            return await GetAllocationsAsync(node.Id, func, token);
        }

        public async Task<Allocation> CreateAllocationAsync(int nodeId, Action<AllocationOptions> options, CancellationToken token = default)
        {
            var allocation = new AllocationOptions();
            options.Invoke(allocation);
            var request = new RestRequest($"/api/application/nodes/{nodeId}/allocations", Method.POST)
                .AddJsonBody(allocation);

            var response = await HandleRequest<Allocation>(request, token);

            return response.Data;
        }

        public async Task<Allocation> CreateAllocationAsync(Node node, Action<AllocationOptions> options, CancellationToken token = default)
        {

            return await CreateAllocationAsync(node.Id, options, token);
        }

        public async Task<Allocation> CreateAllocationAsync(int nodeId, AllocationOptions options, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nodes/{nodeId}/allocations", Method.POST)
                .AddJsonBody(options);

            var response = await HandleRequest<Allocation>(request, token);

            return response.Data;
        }

        public async Task<Allocation> CreateAllocationAsync(Node node, AllocationOptions options, CancellationToken token = default)
        {

            return await CreateAllocationAsync(node.Id, options, token);
        }

        public async Task<bool> DeleteAllocationAsync(int nodeId, int id, CancellationToken token = default)
        {
            var request = new RestRequest($"/api/application/nodes/{nodeId}/allocations/{id}", Method.DELETE);

            var response = await HandleRequest(request, token);

            return response.IsSuccessful;
        }

        public async Task<bool> DeleteAllocationAsync(Node node, int allocationId, CancellationToken token = default)
        {
            return await DeleteAllocationAsync(node.Id, allocationId, token);
        }

        public async Task<bool> DeleteAllocationAsync(int nodeId, Allocation allocation, CancellationToken token = default)
        {
            return await DeleteAllocationAsync(nodeId, allocation.Id, token);
        }

        public async Task<bool> DeleteAllocationAsync(Node node, Allocation allocation, CancellationToken token = default)
        {
            return await DeleteAllocationAsync(node.Id, allocation.Id, token);
        }



    }
}
