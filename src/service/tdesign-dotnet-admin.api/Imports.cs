﻿global using Autofac;
global using Autofac.Extensions.DependencyInjection;
global using AutoMapper;
global using Serilog;
global using System.Reflection;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using System;
global using System.Collections.Generic;
global using System.Threading.Tasks;
global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.ComponentModel.DataAnnotations;
global using FluentValidation;
global using TDesignDotentAdmin;
global using TDesignDotentAdmin.DomainCore;
global using TDesignDotentAdmin.Aggregates.MenuAgg;
global using TDesignDotentAdmin.Aggregates.MenuAgg.Command;
global using TDesignDotentAdmin.Aggregates.MenuAgg.Event;
global using TDesignDotentAdmin.Aggregates.MenuAgg.Repository;
global using TDesignDotentAdmin.Aggregates.RoleAgg;
global using TDesignDotentAdmin.Aggregates.RoleAgg.Command;
global using TDesignDotentAdmin.Aggregates.RoleAgg.Event;
global using TDesignDotentAdmin.Aggregates.RoleAgg.Repository;
global using TDesignDotentAdmin.Aggregates.ApiAgg;
global using TDesignDotentAdmin.Aggregates.ApiAgg.Command;
global using TDesignDotentAdmin.Aggregates.ApiAgg.Repository;
global using TDesignDotentAdmin.Aggregates.UserAgg;
global using TDesignDotentAdmin.Aggregates.UserAgg.Command;
global using TDesignDotentAdmin.Aggregates.UserAgg.Command.Validation;
global using TDesignDotentAdmin.Aggregates.UserAgg.Event;
global using TDesignDotentAdmin.Aggregates.UserAgg.Repository;
global using TDesignDotentAdmin.DomainCore.Behaviors;
global using TDesignDotentAdmin.Common.Extensions;
global using Newtonsoft;
global using Newtonsoft.Json.Serialization;
global using Newtonsoft.Json.Converters;