<div align="center">
  <img src="https://via.placeholder.com/1200x350?text=Proje+Banner+Gorseli" alt="Project Banner" width="100%" />

  <h1>🚀 SPOR SALONU YÖNETİM UYGULAMALARI 🚀</h1>

  <p>
    <b>Mobil uygulama ve güçlü bir Backend API altyapısı ile geliştirilmiş modern bir çözüm.</b>
  </p>

  <p>
    <a href="https://github.com/kullaniciadi/repoadi/stargazers">
      <img src="https://img.shields.io/github/stars/kullaniciadi/repoadi?style=for-the-badge&logo=starship&color=ffd700" alt="GitHub Stars" />
    </a>
    <a href="https://github.com/kullaniciadi/repoadi/network/members">
      <img src="https://img.shields.io/github/forks/kullaniciadi/repoadi?style=for-the-badge&logo=git&color=orange" alt="GitHub Forks" />
    </a>
    <a href="https://github.com/kullaniciadi/repoadi/graphs/contributors">
      <img src="https://img.shields.io/github/contributors/kullaniciadi/repoadi?style=for-the-badge&color=blue" alt="Contributors" />
    </a>
  </p>
</div>

---

## 📱 Proje Hakkında

Bu proje, **Flutter (Dart)** tabanlı bir mobil arayüz ve **.NET Core (C#)** ile geliştirilmiş, **MSSQL** veritabanı kullanan ölçeklenebilir bir API mimarisine sahiptir. Geliştirme sürecinde **Docker** konteynerizasyonu ve **Postman** ile kapsamlı API testleri kullanılmıştır.

---

## 📸 Ekran Görüntüleri (Görselleştirme)

<div align="center">
  <table>
    <tr>
      <td align="center"><b>Mobil Uygulama</b></td>
      <td align="center"><b>API / Swagger</b></td>
      <td align="center"><b>Veritabanı Şeması</b></td>
    </tr>
    <tr>
      <td><img src="https://via.placeholder.com/250x500?text=Mobile+App" width="250" /></td>
      <td><img src="https://via.placeholder.com/400x300?text=API+Swagger+UI" width="400" /></td>
      <td><img src="https://via.placeholder.com/400x300?text=DB+Schema" width="400" /></td>
    </tr>
  </table>
</div>

---

## 🛠️ Teknoloji Yığını (Tech Stack)

Projede kullanılan diller, framework'ler ve geliştirme ortamları aşağıda detaylandırılmıştır.

### 💻 Mobil ve Frontend
<div align="left">
  <img src="https://img.shields.io/badge/Dart-0175C2?style=for-the-badge&logo=dart&logoColor=white" alt="Dart" />
  <img src="https://img.shields.io/badge/Flutter-02569B?style=for-the-badge&logo=flutter&logoColor=white" alt="Flutter" />
  <img src="https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white" alt="HTML5" />
  <img src="https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white" alt="CSS3" />
</div>

### 🔙 Backend ve Veritabanı
<div align="left">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET Core" />
  <img src="https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="MSSQL" />
  <img src="https://img.shields.io/badge/SQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white" alt="SQL" />
</div>

### ⚙️ DevOps, Test ve Araçlar
<div align="left">
  <img src="https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white" alt="Docker" />
  <img src="https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white" alt="Postman" />
  <img src="https://img.shields.io/badge/C++-00599C?style=for-the-badge&logo=c%2B%2B&logoColor=white" alt="C++" />
  <img src="https://img.shields.io/badge/CMake-064F8C?style=for-the-badge&logo=cmake&logoColor=white" alt="CMake" />
</div>

### 🖥️ Geliştirme Ortamları (IDE)
<div align="left">
  <img src="https://img.shields.io/badge/Visual_Studio_2022-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white" alt="VS 2022" />
  <img src="https://img.shields.io/badge/Android_Studio-3DDC84?style=for-the-badge&logo=android-studio&logoColor=white" alt="Android Studio" />
</div>

---

## 🚀 Kurulum ve Çalıştırma

Projeyi yerel ortamınızda ayağa kaldırmak için aşağıdaki adımları izleyin.

### Ön Gereksinimler
* [Docker Desktop](https://www.docker.com/products/docker-desktop)
* [Visual Studio 2022](https://visualstudio.microsoft.com/)
* [Flutter SDK](https://flutter.dev/docs/get-started/install)

### 1. API ve Veritabanı (Docker & .NET)

```bash
# Repoyu klonlayın
git clone [https://github.com/kullaniciadi/repoadi.git](https://github.com/kullaniciadi/repoadi.git)

# Docker konteynerlerini ayağa kaldırın (MSSQL ve API için)
docker-compose up -d --build
