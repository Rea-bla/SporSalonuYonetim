
  <h1 align="center">🏋️‍♂️ Spor Salonu Yönetim Sistemi 🏋️‍♀️</h1>

  <p align="center">
    <b>Modern Spor Salonları için Geliştirilmiş Mobil Uygulama ve Güçlü Backend API Çözümü</b>
  </p>

  <p align="center">
    <a href="https://github.com/Rea-bla/SporSalonuYonetim/stargazers">
      <img src="https://img.shields.io/github/stars/Rea-bla/SporSalonuYonetim?style=for-the-badge&color=yellow" alt="Stars">
    </a>
    <a href="https://github.com/Rea-bla/SporSalonuYonetim/network/members">
      <img src="https://img.shields.io/github/forks/Rea-bla/SporSalonuYonetim?style=for-the-badge&color=orange" alt="Forks">
    </a>
    <a href="https://github.com/Rea-bla/SporSalonuYonetim/issues">
      <img src="https://img.shields.io/github/issues/Rea-bla/SporSalonuYonetim?style=for-the-badge&color=blue" alt="Issues">
    </a>
    <a href="https://github.com/Rea-bla/SporSalonuYonetim/blob/main/LICENSE">
      <img src="https://img.shields.io/github/license/Rea-bla/SporSalonuYonetim?style=for-the-badge&color=green" alt="License">
    </a>
  </p>
</div>

---

## 📋 Proje Hakkında

**SporSalonuYonetim**, spor salonu işletmecilerinin üyeleri, antrenman programlarını, ödemeleri ve personeli tek bir platformdan yönetmesini sağlayan kapsamlı bir yazılım çözümüdür. 

Proje iki ana bileşenden oluşur:
1.  **Mobil Uygulama:** Üyeler ve yöneticiler için Flutter ile geliştirilmiş kullanıcı dostu arayüz.
2.  **Backend API:** Veri yönetimi ve iş mantığı için .NET Core üzerinde çalışan, Dockerize edilmiş RESTful API.

---

## 📸 Ekran Görüntüleri

Projenin arayüzünden ve API yapısından örnekler:

<div align="center">
  <table>
    <tr>
      <td align="center"><b>📱 Mobil Giriş</b></td>
      <td align="center"><b>📑 Üye Yönetimi</b></td>
      <td align="center"><b>⚙️ Swagger API Dokümantasyonu</b></td>
    </tr>
    <tr>
      <td><img src="https://via.placeholder.com/250x500?text=Mobil+Giris" alt="Mobil Giriş" width="250"></td>
      <td><img src="https://github.com/user-attachments/assets/2ee90865-2a90-4035-a701-550470a6dd86" alt="Üye Listesi" width="250"></td>
      <td><img src="https://via.placeholder.com/400x300?text=Swagger+UI" alt="Swagger UI" width="400"></td>
    </tr>
  </table>
</div>

---

## 🛠️ Teknoloji Yığını (Tech Stack)

Projede kullanılan modern teknolojiler, kütüphaneler ve geliştirme araçları:

### 📱 Mobil (Frontend)
<div align="left">
  <img src="https://img.shields.io/badge/Flutter-02569B?style=for-the-badge&logo=flutter&logoColor=white" alt="Flutter" />
  <img src="https://img.shields.io/badge/Dart-0175C2?style=for-the-badge&logo=dart&logoColor=white" alt="Dart" />
  <img src="https://img.shields.io/badge/Android_Studio-3DDC84?style=for-the-badge&logo=android-studio&logoColor=white" alt="Android Studio" />
  <img src="https://img.shields.io/badge/Material_Design-757575?style=for-the-badge&logo=material-design&logoColor=white" alt="Material Design" />
</div>

### 🔙 Backend & API
<div align="left">
  <img src="https://img.shields.io/badge/.NET_Core_API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET Core" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="EF Core" />
  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black" alt="Swagger" />
</div>

### 🗄️ Veritabanı
<div align="left">
  <img src="https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="MSSQL" />
  <img src="https://img.shields.io/badge/SQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white" alt="SQL" />
</div>

### ⚙️ DevOps & Araçlar
<div align="left">
  <img src="https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white" alt="Docker" />
  <img src="https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white" alt="Postman" />
  <img src="https://img.shields.io/badge/Visual_Studio_2022-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white" alt="VS 2022" />
  <img src="https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white" alt="Git" />
</div>

---

## 🚀 Kurulum ve Çalıştırma

Projeyi yerel ortamınızda (Localhost) çalıştırmak için aşağıdaki adımları izleyebilirsiniz.

### Ön Gereksinimler
* [Docker Desktop](https://www.docker.com/products/docker-desktop) (Database ve API containerları için)
* [Flutter SDK](https://docs.flutter.dev/get-started/install)
* [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [VS Code](https://code.visualstudio.com/)

### Adım 1: Repoyu Klonlayın
```bash
git clone [https://github.com/Rea-bla/SporSalonuYonetim.git](https://github.com/Rea-bla/SporSalonuYonetim.git)
cd SporSalonuYonetim
