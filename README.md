# SupportSystem

**SupportSystem**, kullanıcıların destek taleplerini kolayca oluşturup yönetebileceği, hızlı ve güvenilir bir destek yönetim platformudur. Modern teknolojilerle geliştirilen bu sistem, kullanıcı dostu bir arayüz ve güvenli veri yönetimi sunarak hem bireysel kullanıcıların hem de ekiplerin iş akışını kolaylaştırmayı hedefler. Destek taleplerini kategorize etme, durum takibi yapma ve bildirimlerle anlık iletişim kurma gibi özelliklerle her ölçekte organizasyon için ideal bir çözüm sunar.

---

### **Değişiklikler ve Eklenenler**
**Geliştirmeler**:




✅ Sistemin temelini oluşturan Domain katmanında varlıkların, enum'ların ve arayüzlerin tanımlanması tamamlandı.



✅ Sistem için gereken veritabanı eklendi.



✅ Uygulama katmanında CQRS desenine uygun olarak aşağıdaki özellikler geliştirildi:





- **Kimlik Doğrulama (Auth)**: Kullanıcı girişi, kaydı ve çıkış işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.




- **Bildirim (Notification)**: Bildirim gönderme ve alma işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.




- **Destek Kategorisi (SupportCategory)**: Kategori oluşturma, güncelleme ve silme işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.




- **Destek Talebi (SupportRequest)**: Destek talebi oluşturma, güncelleme ve kapatma işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.




- **Destek Türü (SupportType)**: Tür oluşturma, güncelleme ve silme işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.




- **Destek Talebi Yorumları (SupportRequestComment)**: Yorum ekleme ve listeleme işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.




- **Kullanıcı Yönetimi (User)**: Kullanıcı oluşturma, güncelleme, silme ve role göre sorgulama işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.




✅ Infrastructure katmanında aşağıdaki geliştirmeler yapıldı:



- **FileUploadService** eklendi: Dosya yükleme işlemlerini asenkron bir şekilde işlemek ve depolamak için servis geliştirildi.

- **BackgroundService** eklendi: Dosya yükleme ve diğer arka plan işlemlerini yönetmek için **FileUploadService** implementasyonu tamamlandı.

- **JwtTokenService** eklendi: Kimlik doğrulama için JWT token üretimi ve yönetimi sağlayan servis implemente edildi.

- **LoggingService** eklendi: Hata mesajlarını kaydetmek ve sistem izlenebilirliğini artırmak için loglama servisi geliştirildi.




✅ API katmanında CQRS desenine uygun olarak aşağıdaki kontrolörler geliştirildi:





- **AuthController**: Kimlik doğrulama işlemleri için API uç noktaları (login, register, logout, user, token).



- **NotificationController**: Bildirim işlemleri için API uç noktaları (send, list, detail).



- **SupportTypeController**: Destek türlerini oluşturma, güncelleme, silme ve listeleme işlemleri için **/api/SupportType** uç noktaları.



- **SupportCategoryController**: Destek kategorilerini oluşturma, güncelleme, silme ve listeleme işlemleri için **/api/SupportCategory** uç noktaları.



- **SupportRequestController**: Destek talebi oluşturma, güncelleme, listeleme ve durum değiştirme işlemleri için **/api/SupportRequest** uç noktaları.



- **FileController**: Dosya yükleme işlemleri için **/api/File** uç noktası implemente edildi.



- **UserController**: Kullanıcı oluşturma ve yönetimi için **/api/User** uç noktaları geliştirildi.



- **SupportRequestCommentController**: Destek taleplerine yorum ekleme ve listeleme işlemleri için **/api/SupportRequestComment** uç noktaları tamamlandı.




✅ SupportSystem ℱrontend ✅


 **✔Özellikler✔**: 


- **Destek Talebi Yönetimi**: Talepleri oluşturma, güncelleme ve takip etme.


- **Kategorizasyon ve Türler**: Talepleri kategorilere ve türlere ayırma.


- **Bildirim Sistemi**: Gerçek zamanlı bildirimler.


- **Rol Tabanlı Erişim**: Admin, SuperAdmin ve kullanıcı rolleri.


- **Dosya Yükleme**: Taleplere ek dosya desteği.


- **Yorum Sistemi**: Taleplere yorum ekleme.


- **Responsive Tasarım**: Mobil ve masaüstü uyumluluğu.


- **Animasyonlu Arayüz**: Akıcı geçişler ve görsel efektler.


**✔Kullanılan Teknolojiler✔**


- **React**: Bileşen tabanlı ön yüz geliştirme.


- **Styled Components**: Dinamik stil yönetimi.


- **Framer Motion**: Animasyonlar ve geçiş efektleri.


- **React Router**: Sayfa yönlendirme.


- **Axios**: API iletişimi.


- **JWT**: Kimlik doğrulama.


- **React Toastify**: Bildirimler.


- **Fira Code**: Modern yazı tipi.


## Özellikler
- **Destek Talebi Yönetimi**: Kullanıcılar, taleplerini kolayca oluşturabilir, güncelleyebilir ve takip edebilir.
- **Kategorizasyon ve Türler**: Talepler, kategorilere ve türlere ayrılarak daha düzenli bir yönetim sağlar.
- **Bildirim Sistemi**: Gerçek zamanlı bildirimlerle kullanıcılar her zaman bilgilendirilir.
- **Rol Tabanlı Erişim**: Admin, SuperAdmin ve kullanıcı rolleri ile yetkilendirme.
- **Dosya Yükleme**: Taleplere ek dosya yükleme desteği.
- **Yorum Sistemi**: Destek taleplerine yorum ekleyerek iletişim güçlendirilir.

**Geliştiricilerin Sosyal Medya Hesapları**:

