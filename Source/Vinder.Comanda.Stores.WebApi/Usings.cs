global using System.Diagnostics.CodeAnalysis;
global using System.Text.Json;
global using System.Web;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.HttpLogging;

global using Vinder.Comanda.Stores.WebApi.Extensions;
global using Vinder.Comanda.Stores.WebApi.Constants;
global using Vinder.Comanda.Stores.Domain.Errors;

global using Vinder.Comanda.Stores.Application.Payloads.Establishment;
global using Vinder.Comanda.Stores.Application.Payloads.Product;
global using Vinder.Comanda.Stores.Application.Mappers;
global using Vinder.Comanda.Stores.Application.Gateways;
global using Vinder.Comanda.Stores.Application.Payloads;

global using Vinder.Comanda.Stores.Infrastructure.IoC.Extensions;
global using Vinder.Comanda.Stores.Infrastructure.Gateways;

global using Vinder.Comanda.Stores.Infrastructure.Constants;
global using Vinder.Comanda.Stores.Infrastructure.Options;

global using Vinder.Comanda.Stores.CrossCutting.Configurations;

global using Vinder.Dispatcher.Contracts;
global using Vinder.IdentityProvider.Sdk.Extensions;

global using Scalar.AspNetCore;
global using FluentValidation.AspNetCore;