global using System.Diagnostics.CodeAnalysis;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;

global using Vinder.Comanda.Stores.WebApi.Extensions;
global using Vinder.Comanda.Stores.Domain.Errors;

global using Vinder.Comanda.Stores.Application.Payloads.Establishment;
global using Vinder.Comanda.Stores.Application.Payloads.Product;

global using Vinder.Comanda.Stores.Infrastructure.IoC.Extensions;
global using Vinder.Comanda.Stores.CrossCutting.Configurations;

global using Vinder.Dispatcher.Contracts;
global using Vinder.IdentityProvider.Sdk.Extensions;

global using Scalar.AspNetCore;
global using FluentValidation.AspNetCore;