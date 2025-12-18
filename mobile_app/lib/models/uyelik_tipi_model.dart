class UyelikTipi {
  final int uyelikTipId;
  final String ad;
  final double fiyat;

  UyelikTipi({
    required this.uyelikTipId,
    required this.ad,
    required this.fiyat,
  });

  factory UyelikTipi.fromJson(Map<String, dynamic> json) {
    return UyelikTipi(
      uyelikTipId: json['uyelikTipId'] as int,
      ad: json['ad'] as String,
      fiyat: (json['fiyat'] as num).toDouble(),
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'uyelikTipId': uyelikTipId,
      'ad': ad,
      'fiyat': fiyat,
    };
  }

  @override
  String toString() {
    return 'UyelikTipi(uyelikTipId: $uyelikTipId, ad: $ad, fiyat: $fiyat)';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;
    return other is UyelikTipi &&
        other.uyelikTipId == uyelikTipId &&
        other.ad == ad &&
        other.fiyat == fiyat;
  }

  @override
  int get hashCode => Object.hash(uyelikTipId, ad, fiyat);

  // Yardımcı metodlar
  UyelikTipi copyWith({
    int? uyelikTipId,
    String? ad,
    double? fiyat,
  }) {
    return UyelikTipi(
      uyelikTipId: uyelikTipId ?? this.uyelikTipId,
      ad: ad ?? this.ad,
      fiyat: fiyat ?? this.fiyat,
    );
  }

  // Formatlanmış fiyat string'i döndürür
  String get formattedPrice => '${fiyat.toStringAsFixed(2)} ₺';
}