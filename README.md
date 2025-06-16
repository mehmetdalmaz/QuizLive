# QuizLive – Akıllı Online Sınav Platformu

QuizLive, öğrenci ve eğitmenler için geliştirilmiş, dinamik ve güvenli bir online sınav sistemidir. ASP.NET Core Web API tabanlı bu platform, çok katmanlı mimarisi (N-Tier Architecture) ile sürdürülebilir, test edilebilir ve modern yazılım geliştirme prensiplerine (SOLID) uygun bir yapı sunar. Gerçek zamanlı sınav takibi için SignalR entegrasyonu ile dikkat çekmektedir.

## Temel Özellikler

* **Güvenli Kullanıcı Yönetimi:** JWT tabanlı kimlik doğrulama ve rol bazlı yetkilendirme ile öğrenci ve eğitmen hesaplarının güvenli yönetimi.
* **Eğitmen Modülü:** Eğitmenlerin kolayca sınav oluşturabilmesi, soru ve seçenekleri ekleyip güncelleyebilmesi.
* **Öğrenci Modülü:** Öğrencilerin sınavlara katılabilmesi, canlı sınav süresi takibi ve sınavın otomatik puanlanması.
* **Gerçek Zamanlı Sınav Yönetimi:** SignalR kullanarak sınav süresinin canlı takibi ve süresi biten sınavların otomatik olarak sonlandırılması.
* **Temiz Kod ve Veri Doğrulama:** DTO, AutoMapper ve FluentValidation gibi modern kütüphanelerle temiz kod yaklaşımı ve güçlü veri doğrulama mekanizmaları.
* **Veritabanı Tasarımı:** Entity Framework Core ile Code-First mimaride ilişkisel veritabanı tasarımı.

## Kullanılan Teknolojiler

* **ASP.NET Core Web API**
* **Entity Framework Core**
* **ASP.NET Identity**
* **JWT Authentication**
* **SignalR (Real-time communication)**
* **AutoMapper, DTOs**
* **FluentValidation**
* **MSSQL Server**
* **N-Tier Architecture**

QuizLive, ölçeklenebilir altyapısı ve gerçek zamanlı özellikleri ile online sınav süreçlerinin dijitalleştirilmesinde güçlü ve yenilikçi bir çözüm sunmaktadır.
