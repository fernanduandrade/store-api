using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;
using RestApiDDD.Domain.Entities;

namespace RestApiDDD.Application.Mapper;

public class ClientMapper : IClientMapper
{
    IEnumerable<ClientDTO> clientsDto = new List<ClientDTO>();
    public Client MapperDtoToEntity(ClientDTO clientDto)
    {
        return new Client()
        {
            Id = clientDto.Id,
            Name = clientDto.Name,
            LastName = clientDto.LastName,
            Email = clientDto.Email,
        };
        
    }

    public IEnumerable<ClientDTO> MapperListClientsDTO(IEnumerable<Client> clients)
    {
        return clients.Select(client => new ClientDTO()
        {
            Id = client.Id,
            Name = client.Name,
            LastName = client.LastName,
            Email = client.Email
        });
    }

    public ClientDTO MapperEntityToDto(Client client)
    {
        return new ClientDTO()
        {
            Id = client.Id,
            Name = client.Name,
            LastName = client.LastName,
            Email = client.Email,
        };
    }
}