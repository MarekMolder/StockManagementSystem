# Inventory and Stock Management System

## Overview

Efficient inventory and stock management are critical for businesses dealing with physical goods. A well-structured inventory system helps companies track stock levels, prevent shortages or overstocking, and maintain accurate records for financial and operational efficiency. However, many small and medium-sized enterprises (SMEs) still rely on outdated methods such as spreadsheets and paper-based documentation, leading to errors, inefficiencies, and increased administrative workload.

## Problem Statement

The author is familiar with inventories that is managed by using an Excel spreadsheet. Throughout the month, stock deductions are recorded manually on paper. At the end of the month, these paper records are collected, and necessary adjustments are made in the Excel file. This process is:

- **Time-consuming** – requiring manual data entry and reconciliation.
- **Error-prone** – increasing the risk of incorrect stock levels due to misplacement or miscalculation.
- **Lacking real-time tracking** – preventing timely decision-making and stock adjustments.

## Proposed Solution

To address these challenges, this project aims to develop a **web-based Inventory and Stock Management System** that provides:

- **Real-time inventory updates** – eliminating delays in stock adjustments.
- **Automated stock tracking** – reducing manual data entry errors.
- **Role-based user access** – ensuring secure and structured inventory control.
- **Comprehensive reporting tools** – generating automated insights for better decision-making.

## Features

- **User Authentication & Role Management** – Secure access control for administrators, warehouse staff, and managers.
- **Real-time Stock Updates** – Automated stock level adjustments based on transactions.
- **Inventory Dashboard** – A visual overview of stock levels, low-stock alerts, and transaction history.
- **Audit Trail & Logging** – Tracking all inventory changes for accountability.
- **Automated Reports & Analytics** – Generating insights for forecasting and optimization.

## Technologies Used

- **Frontend:** React.js (TBD)
- **Backend:** ASP.NET Core / C#
- **Database:** MySQL
- **Hosting:** Docker

~~~sh
dotnet ef migrations add --project App.DAL.EF --startup-project WebApp --context AppDbContext InitialCreate

dotnet ef migrations --project App.DAL.EF --startup-project WebApp remove

dotnet ef database --project App.DAL.EF --startup-project WebApp update
dotnet ef database --project App.DAL.EF --startup-project WebApp drop

~~~

MVC controllers
~~~sh
cd WebApp

dotnet aspnet-codegenerator controller -name ActionsController -actions -m App.Domain.ActionEntity -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name ActionTypesController -actions -m App.Domain.ActionType -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name AddressesController -actions -m App.Domain.Address -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name ApprovalRequestsController -actions -m App.Domain.ApprovalRequests -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name CurrentStocksController -actions -m App.Domain.CurrentStock -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name InventoriesController -actions -m App.Domain.Inventory -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name ProductsController -actions -m App.Domain.Product -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name ProductCategoriesController -actions -m App.Domain.ProductCategory -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name ProductInStorageRoomsController -actions -m App.Domain.ProductInStorageRoom -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name ReasonsController -actions -m App.Domain.Reason -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name RolesController -actions -m App.Domain.Role -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name RoleClaimsController -actions -m App.Domain.RoleClaim -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name StockAuditsController -actions -m App.Domain.StockAudit -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name StockMovementsController -actions -m App.Domain.StockMovement -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name StorageRoomsController -actions -m App.Domain.StorageRoom -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name StorageRoomInInventoriesController -actions -m App.Domain.StorageRoomInInventory -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name SuppliersController -actions -m App.Domain.Supplier -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UsersController -actions -m App.Domain.User -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserClaimsController -actions -m App.Domain.UserClaim -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserLoginsController -actions -m App.Domain.UserLogin -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserRolesController -actions -m App.Domain.UserRole -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UserTokensController -actions -m App.Domain.UserToken -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

~~~

Api controllers
~~~sh
dotnet aspnet-codegenerator controller -name ActionsController -actions -m App.Domain.ActionEntity -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ActionTypesController -actions -m App.Domain.ActionType -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name AddressesController -actions -m App.Domain.Address -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ApprovalRequestsController -actions -m App.Domain.ApprovalRequests -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name CurrentStocksController -actions -m App.Domain.CurrentStock -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name InventoriesController -actions -m App.Domain.Inventory -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ProductsController -actions -m App.Domain.Product -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ProductCategoriesController -actions -m App.Domain.ProductCategory -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ProductInStorageRoomsController -actions -m App.Domain.ProductInStorageRoom -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ReasonsController -actions -m App.Domain.Reason -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name RolesController -actions -m App.Domain.Role -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name RoleClaimsController -actions -m App.Domain.RoleClaim -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name StockAuditsController -actions -m App.Domain.StockAudit -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name StockMovementsController -actions -m App.Domain.StockMovement -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name StorageRoomsController -actions -m App.Domain.StorageRoom -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name StorageRoomInInventoriesController -actions -m App.Domain.StorageRoomInInventory -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name SuppliersController -actions -m App.Domain.Supplier -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name UsersController -actions -m App.Domain.User -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name UserClaimsController -actions -m App.Domain.UserClaim -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name UserLoginsController -actions -m App.Domain.UserLogin -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name UserRolesController -actions -m App.Domain.UserRole -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name UserTokensController -actions -m App.Domain.UserToken -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

~~~
