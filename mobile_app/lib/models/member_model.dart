class Member {
  final String tcNo;
  final String ad;
  final String soyad;
  final String telefon;
  final String kanGrubu;
  final String cinsiyet;
  final int boy;
  final double kilo;
  final DateTime? dogumTarihi;
  final DateTime? bitisTarihi;
  final String odeme;
  final int secilenUyelikID;
  final bool? isActive;

  Member({
    required this.tcNo,
    required this.ad,
    required this.soyad,
    required this.telefon,
    required this.kanGrubu,
    required this.cinsiyet,
    required this.boy,
    required this.kilo,
    this.dogumTarihi,
    this.bitisTarihi,
    required this.odeme,
    required this.secilenUyelikID,
    this.isActive,
  });

  factory Member.fromJson(Map<String, dynamic> json) {
    return Member(
      tcNo: json['tcNo'] ?? json['TCNo'] ?? '',
      ad: json['ad'] ?? json['Ad'] ?? '',
      soyad: json['soyad'] ?? json['Soyad'] ?? '',
      telefon: json['telefon'] ?? json['Telefon'] ?? '',
      kanGrubu: json['kanGrubu'] ?? json['KanGrubu'] ?? '',
      cinsiyet: json['cinsiyet'] ?? json['Cinsiyet'] ?? '',
      boy: json['boy'] ?? json['Boy'] ?? 0,
      kilo: (json['kilo'] ?? json['Kilo'] ?? 0).toDouble(),
      dogumTarihi: json['dogumTarihi'] != null || json['DogumTarihi'] != null
          ? DateTime.tryParse(json['dogumTarihi'] ?? json['DogumTarihi'])
          : null,
      bitisTarihi: json['bitisTarihi'] != null || json['BitisTarihi'] != null
          ? DateTime.tryParse(json['bitisTarihi'] ?? json['BitisTarihi'])
          : null,
      odeme: json['odeme'] ?? json['Odeme'] ?? '',
      secilenUyelikID: json['secilenUyelikID'] ?? json['SecilenUyelikID'] ?? 0,
      isActive: json['isActive'] ?? json['IsActive'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'tcNo': tcNo,
      'ad': ad,
      'soyad': soyad,
      'telefon': telefon,
      'kanGrubu': kanGrubu,
      'cinsiyet': cinsiyet,
      'boy': boy,
      'kilo': kilo,
      'dogumTarihi': dogumTarihi?.toIso8601String(),
      'bitisTarihi': bitisTarihi?.toIso8601String(),
      'odeme': odeme,
      'secilenUyelikID': secilenUyelikID,
    };
  }

  String get fullName => '$ad $soyad';

  bool get membershipActive {
    if (bitisTarihi == null) return false;
    return bitisTarihi!.isAfter(DateTime.now());
  }

  int get daysRemaining {
    if (bitisTarihi == null) return 0;
    return bitisTarihi!.difference(DateTime.now()).inDays;
  }
}