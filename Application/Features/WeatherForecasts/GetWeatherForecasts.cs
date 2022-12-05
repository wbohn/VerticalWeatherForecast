using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VerticalWeatherForecast.Api.Controllers;
using VerticalWeatherForecast.Application.Common;
using VerticalWeatherForecast.Application.Database;
using VerticalWeatherForecast.Application.WeatherForecasts;

namespace VerticalWeatherForecast.Application.Features.WeatherForecasts
{
    public class WeatherForecastsController : BaseController
    {
        public WeatherForecastsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("WeatherForecasts")]
        public async Task<IEnumerable<WeatherForecastDto>> GetWeatherForecasts()
        {
            return await _mediator.Send(new GetWeatherForecastsQuery());
        }
    }

    public class GetWeatherForecastsQuery : IRequest<ICollection<WeatherForecastDto>>
    {
    }

    public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, ICollection<WeatherForecastDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWeatherForecastsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<WeatherForecastDto>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            return await _context.WeatherForecasts
                .ProjectTo<WeatherForecastDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
