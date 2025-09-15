# StudentOS – Öğrenci Yönetim Sistemi  

## Proje Hakkında  
StudentOS, öğrencilerin, öğretmenlerin ve derslerin yönetimini sağlayan bir **Blazor WebAssembly + ASP.NET Core Web API + PostgreSQL** tabanlı web uygulamasıdır.  

Proje kapsamında:  
- Kullanıcı yönetimi (Admin, Teacher, Student rolleri)  
- Öğrenci, öğretmen, ders, kayıt, not ve yoklama işlemleri  
- JWT tabanlı kimlik doğrulama  
- Repository & Service katmanları ile **Clean Code mimarisi**  
- Rol bazlı yetkilendirme (Authorization) hayata geçirilmiştir.  

---

## 🚀 Kullanılan Teknolojiler  
- **Backend**: ASP.NET Core Web API (C#), Entity Framework Core  
- **Database**: PostgreSQL  
- **Frontend**: Blazor WebAssembly  
- **Kimlik Doğrulama**: ASP.NET Core Identity + JWT  
- **UI / UX**: Blazor bileşenleri, rol bazlı menüler  
- **Clean Code**: Repository Pattern, DTO  
- **Bonus**: Swagger UI, CORS  

---

## 🔑 Roller ve Yetkilendirme  

### Admin  
- Öğrenci ve öğretmen ekleyebilir, silebilir, güncelleyebilir  
- Ders açabilir ve tüm kayıtlara erişebilir  

### Teacher  
- Kendi derslerine öğrenci ekleyebilir  
- Not girebilir, yoklama tutabilir  

### Student  
- Sadece kendi bilgilerini görüntüleyebilir  
- Ders kayıtlarını görebilir  

---

## 📜 API Endpointleri  

### 🔹 AuthController  
- `POST /api/auth/register` → Yeni kullanıcı oluşturur (Admin/Teacher/Student)  
- `POST /api/auth/login` → JWT token döner  

### 🔹 StudentsController  
- `GET /api/students` → Admin/Teacher tüm öğrencileri görebilir  
- `POST /api/students` → Admin yeni öğrenci ekler  

### 🔹 CoursesController  
- `POST /api/courses` → Admin ders açar  
- `GET /api/courses` → Ders listesini döner  

### 🔹 EnrollmentController  
- `POST /api/enrollments` → Öğrenciyi derse kaydeder  
- `GET /api/enrollments/{studentId}` → Öğrencinin derslerini listeler  

### 🔹 GradesController  
- `POST /api/grades` → Öğrenciye not ekler  
- `GET /api/grades/{studentId}` → Öğrencinin notlarını listeler  

### 🔹 AttendanceController  
- `POST /api/attendance` → Yoklama kaydı ekler  
- `GET /api/attendance/{courseId}` → Derse ait yoklamaları getirir  

---

## 🎨 Frontend (Blazor WASM)  
- Login/Register ekranları → Token tabanlı giriş  
- Rol bazlı menü  
  - Admin → Öğrenciler, Öğretmenler, Dersler  
  - Teacher → Derslerim, Notlar, Yoklama  
  - Student → Bilgilerim, Derslerim, Notlarım  
- LocalStorage → Token, Rol, UserId saklanıyor  
- HttpClient → Tüm isteklerde JWT header ekleniyor  

---

## ⚙️ Kurulum  

### 1. Database (PostgreSQL)  
```sql
CREATE DATABASE studentos_db;
appsettings.json içinde connection string:

json
Kodu kopyala
"ConnectionStrings": {
  "Default": "Host=localhost;Port=5432;Database=studentos_db;Username=postgres;Password=12345"
}
2. Migration & Seed
bash
Kodu kopyala
cd Backend/StudentOS.Api
dotnet ef database update
3. Backend Çalıştırma
bash
Kodu kopyala
dotnet run --project Backend/StudentOS.Api
4. Frontend Çalıştırma
bash
Kodu kopyala
dotnet run --project Frontend/StudentOS.Web
Backend Swagger: https://localhost:7117/swagger

Frontend Blazor: https://localhost:7173/

Katkıda Bulunan
Ferhat Türe – Bilgisayar Mühendisi
