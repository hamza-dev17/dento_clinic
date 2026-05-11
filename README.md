# Dento Clinic

ASP.NET MVC dental clinic management system for handling the clinic website and internal admin workflows.

## What it includes

- Public website pages for clinic information, services, contact, and appointments
- Admin-area screens for managing dentists, patients, appointments, treatments, payments, and reports
- Entity Framework 6 data access
- Bootstrap, jQuery, DataTables, and CKEditor assets for the UI

## Tech Stack

- .NET Framework 4.8
- ASP.NET MVC 5
- Entity Framework 6
- SQL Server
- Bootstrap 5

## Project Structure

- `Dento Clinic/Controllers/` - MVC controllers for the main features
- `Dento Clinic/Areas/Website/` - public website area
- `Dento Clinic/Areas/Admin/` - admin area registration
- `Dento Clinic/Views/` - Razor views and shared layouts
- `Dento Clinic/Models/` - entity models and database context files
- `Dento Clinic/Content/` - CSS, JS, and front-end assets
- `Dento Clinic/Scripts/` - client-side scripts
- `Dento Clinic/App_Start/` - route, filter, and bundle configuration

## Main Modules

- `WebsiteController`
- `AppointmentsController`
- `DentistsController`
- `PatientsController`
- `PaymentsController`
- `TreatmentsController`
- `ReportsController`
- `AccountController`

## Getting Started

1. Open `Dento Clinic.sln` in Visual Studio.
2. Restore NuGet packages if prompted.
3. Update the database connection string in `Dento Clinic/Web.config` for your SQL Server instance.
4. Build and run the project.

## Configuration Notes

- The default route opens the `Website` controller and `Index` action.
- The app is configured for target framework `net48`.
- If you move the database, update the `DentalClinicDBEntities` connection string in `Web.config`.

## Packages

The repo uses a checked-in `packages/` folder so the project can be restored and opened without rebuilding every dependency from scratch.
