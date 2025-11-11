/* global using for System namespaces here */

global using System.Net;
global using System.Net.Http.Json;

global using System.Text;
global using System.Text.Json;

/* global using for Microsoft namespaces here */

global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.Extensions.DependencyInjection;

/* global using for Vinder namespaces here */

global using Vinder.Comanda.Stores.WebApi;

global using Vinder.Comanda.Stores.Domain.Repositories;
global using Vinder.Comanda.Stores.Domain.Entities;
global using Vinder.Comanda.Stores.Domain.Concepts;
global using Vinder.Comanda.Stores.Domain.Filtering;

global using Vinder.Comanda.Stores.Application.Payloads;

global using Vinder.Comanda.Stores.CrossCutting.Constants;

global using Vinder.Internal.Essentials.Patterns;
global using Vinder.Internal.Essentials.Utilities;

/* global usings for third-party namespaces here */

global using MongoDB.Driver;
global using DotNet.Testcontainers.Builders;
global using DotNet.Testcontainers.Containers;
global using AutoFixture;