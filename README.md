# PhoneDirectory

DDD ve Clean Architecture prensiplerine uygun olarak .NET 8, PostgreSQL, Kafka tabanlı microservices mimarisi ile geliştirilmiş Telefon Rehberi ve Raporlama Sistemi.

Teknolojiler

- .NET 8 & EF Core 9
- Clean Architecture & DDD
- PostgreSQL
- Apache Kafka
- Docker
- xUnit - Unit Test

Kurulum ve Çalıştırma

- Docker Desktop: PostgreSQL ve Kafka servisleri için
- .NET 8 SDK

Gerekli connection strings ve configurations appsettings.json dosyasında tanımlanmalıdır.

Proje root dizinde "docker-compose up -d" komutu ile Kafka ve Zookeeper containerleri ayağa kaldırılır.
Projede Directory ve Reporting olmak üzere iki mikroservis yer almaktadır. Bu mikroservisler için database update komutları çalıştırılır.

dotnet ef database update --project Directory/Directory.Infrastructure
dotnet ef database update --project Reporting/Reporting.Infrastructure

Uygulama ayağa kaldırılırken Directory.API ve Reporting.API projeleri birlikte başlatılır.
Directory projesinden istek atılarak kuyruğa bir mesaj bırakılır ve Reporting tarafında consume edilir.