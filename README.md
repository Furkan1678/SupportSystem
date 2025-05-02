# SupportSystem

**SupportSystem**, kullanıcıların destek taleplerini kolayca oluşturup yönetebileceği, hızlı ve güvenilir bir destek yönetim platformudur. Modern teknolojilerle geliştirilen bu sistem, kullanıcı dostu bir arayüz ve güvenli veri yönetimi sunarak hem bireysel kullanıcıların hem de ekiplerin iş akışını kolaylaştırmayı hedefler. Destek taleplerini kategorize etme, durum takibi yapma ve bildirimlerle anlık iletişim kurma gibi özelliklerle her ölçekte organizasyon için ideal bir çözüm sunar.

---

### **Değişiklikler ve Eklenenler**
**Geliştirmeler**:
✅ Sistemin temelini oluşturan Domain katmanında varlıkların, enum'ların ve arayüzlerin tanımlanması tamamlandı.



✅ Sistem için gereken veritabanı eklendi.



✅ Uygulama katmanında CQRS desenine uygun olarak aşağıdaki özellikler geliştirildi:





•Kimlik Doğrulama (Auth): Kullanıcı girişi, kaydı ve çıkış işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.



•Bildirim (Notification): Bildirim gönderme ve alma işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.



•Destek Kategorisi (SupportCategory): Kategori oluşturma, güncelleme ve silme işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.



•Destek Talebi (SupportRequest): Destek talebi oluşturma, güncelleme ve kapatma işlemleri için komutlar, sorgular, DTO'lar ve işleyiciler tamamlandı.



✅ API katmanında CQRS desenine uygun olarak aşağıdaki kontrolörler geliştirildi:





•AuthController: Kimlik doğrulama işlemleri için API uç noktaları (login, register, logout, user, token).



•NotificationController: Bildirim işlemleri için API uç noktaları (send, list, detail).



## Özellikler
- **Destek Talebi Yönetimi**: Kullanıcılar, taleplerini kolayca oluşturabilir, güncelleyebilir ve takip edebilir.
- **Kategorizasyon ve Türler**: Talepler, kategorilere ve türlere ayrılarak daha düzenli bir yönetim sağlar.
- **Bildirim Sistemi**: Gerçek zamanlı bildirimlerle kullanıcılar her zaman bilgilendirilir.
- **Rol Tabanlı Erişim**: Admin, SuperAdmin ve kullanıcı rolleri ile yetkilendirme.
- **Dosya Yükleme**: Taleplere ek dosya yükleme desteği.
- **Yorum Sistemi**: Destek taleplerine yorum ekleyerek iletişim güçlendirilir.

**Geliştiricilerin Sosyal Medya Hesapları**: