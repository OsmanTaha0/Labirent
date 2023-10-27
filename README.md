# Labirent Oyunu Readme

## Giriş

Bu konsol tabanlı labirent oyunu, C# dilinde yazılmış basit ancak zorlu bir programdır. Oyuncular, zorluk seviyesi artan rastgele oluşturulan labirentlerde gezinirler. Hedef, engelleri temsil eden '#' sembollerinden kaçınarak çıkışa ('O') ulaşmaktır. Oyun, gizli labirent görünümü, seviye ilerlemesi ve arka plan renginin değişmesi gibi özellikler sunmaktadır.

## Nasıl Oynanır

1. Programı çalıştırın.
2. Labirent içinde gezinmek için şu kontrolleri kullanın:
   - 'w': Yukarı hareket et
   - 's': Aşağı hareket et
   - 'a': Sola hareket et
   - 'd': Sağa hareket et
3. Labirentin gizli görünümünü açmak veya gizlemek için 'h' tuşuna basın.
4. Mevcut seviyeyi yeniden başlatmak için 'r' tuşuna basın.
5. İpucu almak için 'i' tuşuna basın; bu, çıkışa giden yolu gösterir.
6. Çıkışa ('O') ulaşarak seviyeyi tamamlayın ve bir sonrakine geçin.

## Ek Özellikler

- **Arka Plan Rengi**: Arka plan rengi her 25 seviyede bir değişir, ilerlemenin görsel bir göstergesini sağlar.
- **Zorluk Seviyeleri**: Labirentin boyutu ve karmaşıklığı seviye ilerledikçe artar.
- **Renk Kodlu Mesafe**: Çıkışa olan mesafe, yakınlığa bağlı olarak kırmızı ('Sıcak') veya mavi ('Soğuk') olarak gösterilir.
- **Rastgele Engeller**: Labirentte bazı hücreler rastgele engel ('#') olarak belirlenir, her seviyeye çeşitlilik ekler.

## İpuçları

- 'h' tuşunu kullanarak gizli labirent görünümünü açın ve yolunuzu stratejik bir şekilde planlayın.
- Sıkışırsanız, çıkışa yönlendiren bir ipucu almak için 'i' tuşuna basın.
- Labirenti zor buluyorsanız, 'r' tuşuna basarak bir seviyeyi yeniden başlatın.

## Geliştirme

Oyun, C# dilinde yazılmış olup konsol tabanlı giriş ve çıkışı kullanır. Labirent oluşturma, oyuncu hareketi gibi işlevselliği içerir ve rastgele engeller ekleyerek her seviyeye değişkenlik katar.
