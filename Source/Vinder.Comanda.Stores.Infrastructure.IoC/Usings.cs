global using System.Diagnostics.CodeAnalysis;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using Vinder.Comanda.Stores.Domain.Repositories;
global using Vinder.Comanda.Stores.CrossCutting.Configurations;
global using Vinder.Comanda.Stores.CrossCutting.Exceptions;

global using Vinder.Comanda.Stores.Infrastructure.Repositories;

global using Vinder.Comanda.Stores.Application.Payloads.Product;
global using Vinder.Comanda.Stores.Application.Payloads.Establishment;
global using Vinder.Comanda.Stores.Application.Validators.Establishment;

global using Vinder.Comanda.Stores.Application.Validators.Product;
global using Vinder.Comanda.Stores.Application.Handlers.Establishment;

global using Vinder.Internal.Essentials.Contracts;
global using Vinder.Internal.Infrastructure.Persistence.Repositories;

global using Vinder.Dispatcher.Extensions;

global using MongoDB.Driver;
global using FluentValidation;
