# SelectingSortingPaging
Searching, Sorting and Paging with the Entity Framework in an ASP.NET MVC Application

----------

Yapılan birçok ASP.NET MVC projesinde veritabanı ve binlerce veri bulunur. Bu veritabanımızdaki verileri görüntülemek ve bu veriler üzerinde işlemler yapmak isteriz. Bunun için bir yönetim paneline ihtiyaç duyarız. Veriler herhangi bir sayfada listelendikten sonra bunları daha düzenli bir hale getirmek veriler üzerindeki hakimiyetimizi arttırır. Listelenen bu verileri düzene sokmak için, listelenen sayfaya Arama(Searching), Sıralama(Sorting) ve Sayfalama(Paging) özellikleri vermemiz gerekmektedir.

Bu projede, oluşturulan basit bir veritabanındaki veriler üzerinde Arama, Sıralama ve Sayfalama işlemleri yapılmıştır.

----------

# Models
Bu veritabanı oluşturulurken veritabanı modelleme yaklaşımlarından Code First yaklaşımı kullanılmıştır. ASP.NET MVC projelerinde Model sınıfları, Models klasörü içerisinde bulunur. Bu nedenle ilk olarak Models klasörü içerisine aynı zamanda veritabanı tablolarını oluşturacak Book ve Category sınıfları eklenmiştir. Oluşturulan bu sınıflar içerisine istenen özellikler eklenmiş ve modeller oluşturulmuştur.

1. Book
 - Id
 - CategoryId
 - Name
 - ISBN
 - Author
 - Publisher
 - PublicationDate
 - Price
 - ReducedPrice

2. Category
 - Id
 - Name

Ayrıca bu sınıflar içerisinde, modeller arasındaki ilişkiler üzerinden verilere erişim sağlamak için virtual olarak Category ve Books özellikleri tanımlanmıştır.

----------
