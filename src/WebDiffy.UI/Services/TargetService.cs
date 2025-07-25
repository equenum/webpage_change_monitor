using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebDiffy.UI.Infrastructure.Options;
using WebPageChangeMonitor.Models.Consts;
using WebPageChangeMonitor.Models.Dtos;
using WebPageChangeMonitor.Models.Responses;

namespace WebDiffy.UI.Services;

public interface ITargetService
{
    Task<TargetDto> CreateAsync(TargetDto target);
    Task<TargetPaginatedResponse> GetAsync(
        int? page = null, int? count = null, SortDirection? sortDirection = null, string sortBy = null);
    Task<TargetDto> GetAsync(Guid id);
    Task<TargetPaginatedResponse> GetByResourceAsync(
        Guid resourceId, int? page = null, int? count = null, SortDirection? sortDirection = null, string sortBy = null);
    Task<TargetDto> UpdateAsync(TargetDto target);
    Task RemoveAsync(Guid id);
    Task RemoveByResourceAsync(Guid resourceId);
}

public class TargetService : BaseService, ITargetService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly string _targetsBaseUrl;

    public TargetService(IHttpClientFactory clientFactory, IOptions<ApiOptions> options) 
        : base(options)
    {
        _clientFactory = clientFactory;
        _targetsBaseUrl = $"{BaseUrl}/api/public/targets";
    }

    public async Task<TargetDto> CreateAsync(TargetDto target)
    {
        var message = BuildPostRequestMessage(_targetsBaseUrl, target);
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(message);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TargetDto>();
    }

    public async Task<TargetPaginatedResponse> GetAsync(int? page = null, int? count = null,
        SortDirection? sortDirection = null, string sortBy = null)
    {
        var queryParams = new Dictionary<string, string>();

        if (page.HasValue)
        {
            queryParams.Add("page", page.ToString());
        }

        if (count.HasValue)
        {
            queryParams.Add("count", count.ToString());
        }

        if (sortDirection.HasValue && !string.IsNullOrWhiteSpace(sortBy))
        {
            queryParams.Add("sortDirection", sortDirection.ToString());
            queryParams.Add("sortBy", sortBy);
        }

        var message = BuildGetRequestMessage(_targetsBaseUrl, queryParams);
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(message);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TargetPaginatedResponse>();
    }

    public async Task<TargetDto> GetAsync(Guid id)
    {
        var message = BuildGetRequestMessage($"{_targetsBaseUrl}/{id}");
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(message);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TargetDto>();
    }

    public async Task<TargetPaginatedResponse> GetByResourceAsync(Guid resourceId, int? page = null,
        int? count = null, SortDirection? sortDirection = null, string sortBy = null)
    {
        var queryParams = new Dictionary<string, string>();

        if (page.HasValue)
        {
            queryParams.Add("page", page.ToString());
        }

        if (count.HasValue)
        {
            queryParams.Add("count", count.ToString());
        }

        if (sortDirection.HasValue && !string.IsNullOrWhiteSpace(sortBy))
        {
            queryParams.Add("sortDirection", sortDirection.ToString());
            queryParams.Add("sortBy", sortBy);
        }

        var message = BuildGetRequestMessage($"{_targetsBaseUrl}/resource/{resourceId}", queryParams);
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(message);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TargetPaginatedResponse>();
    }

    public async Task RemoveAsync(Guid id)
    {
        var message = BuildDeleteRequestMessage($"{_targetsBaseUrl}/{id}");
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(message);
        response.EnsureSuccessStatusCode();
    }

    public async Task RemoveByResourceAsync(Guid resourceId)
    {
        var message = BuildDeleteRequestMessage($"{_targetsBaseUrl}/resource/{resourceId}");
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(message);
        response.EnsureSuccessStatusCode();
    }

    public async Task<TargetDto> UpdateAsync(TargetDto target)
    {
        var message = BuildPutRequestMessage(_targetsBaseUrl, target);
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(message);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TargetDto>();
    }
}
