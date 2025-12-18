import 'dart:convert';
import 'package:http/http.dart' as http;
import '../config/api_config.dart';
import '../models/member_model.dart';
import '../models/uyelik_tipi_model.dart';

class ApiService {
  // Login
  static Future<Map<String, dynamic>> login(String tcNo, String password) async {
    try {
      final response = await http.post(
        Uri.parse(ApiConfig.loginUrl),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'tcNo': tcNo,
          'sifre': password,
        }),
      );

      final data = jsonDecode(response.body);

      if (response.statusCode == 200) {
        return {
          'success': true,
          'member': Member.fromJson(data['data']),
          'message': data['message'],
        };
      } else {
        return {
          'success': false,
          'message': data['message'] ?? 'Giriş başarısız',
        };
      }
    } catch (e) {
      return {
        'success': false,
        'message': 'Bağlantı hatası: $e',
      };
    }
  }

  // Get Member Info
  static Future<Map<String, dynamic>> getMemberInfo(String tcNo) async {
    try {
      final response = await http.get(
        Uri.parse(ApiConfig.getMemberUrl(tcNo)),
        headers: {'Content-Type': 'application/json'},
      );

      final data = jsonDecode(response.body);

      if (response.statusCode == 200) {
        return {
          'success': true,
          'member': Member.fromJson(data['data']),
        };
      } else {
        return {
          'success': false,
          'message': data['message'] ?? 'Üye bilgisi alınamadı',
        };
      }
    } catch (e) {
      return {
        'success': false,
        'message': 'Bağlantı hatası: $e',
      };
    }
  }

  // Update Member Info
  static Future<Map<String, dynamic>> updateMemberInfo({
    required String tcNo,
    required String telefon,
    required String kanGrubu,
    required int boy,
    required double kilo,
  }) async {
    try {
      final response = await http.put(
        Uri.parse(ApiConfig.updateMemberUrl),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'tcNo': tcNo,
          'telefon': telefon,
          'kanGrubu': kanGrubu,
          'boy': boy,
          'kilo': kilo,
        }),
      );

      final data = jsonDecode(response.body);

      return {
        'success': data['success'] ?? false,
        'message': data['message'] ?? 'Güncelleme başarısız',
      };
    } catch (e) {
      return {
        'success': false,
        'message': 'Bağlantı hatası: $e',
      };
    }
  }

  // Change Password
  static Future<Map<String, dynamic>> changePassword({
    required String tcNo,
    required String oldPassword,
    required String newPassword,
  }) async {
    try {
      final response = await http.put(
        Uri.parse(ApiConfig.changePasswordUrl),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'tcNo': tcNo,
          'oldSifre': oldPassword,
          'newSifre': newPassword,
        }),
      );

      final data = jsonDecode(response.body);

      return {
        'success': data['success'] ?? false,
        'message': data['message'] ?? 'Şifre değiştirme başarısız',
      };
    } catch (e) {
      return {
        'success': false,
        'message': 'Bağlantı hatası: $e',
      };
    }
  }

  // Verify Entry
  static Future<Map<String, dynamic>> verifyEntry(String tcNo) async {
    try {
      final response = await http.post(
        Uri.parse(ApiConfig.verifyEntryUrl),
        headers: {'Content-Type': 'application/json'},
        body: jsonEncode({
          'tcNo': tcNo,
        }),
      );

      final data = jsonDecode(response.body);

      return {
        'success': data['success'] ?? false,
        'isActive': data['isActive'] ?? false,
        'memberName': data['memberName'] ?? '',
        'message': data['message'] ?? '',
      };
    } catch (e) {
      return {
        'success': false,
        'message': 'Bağlantı hatası: $e',
      };
    }
  }

  // Tüm üyelik tiplerini getir
  static Future<List<UyelikTipi>> getUyelikTipleri() async {
    try {
      final response = await http.get(
        Uri.parse(ApiConfig.uyelikTipleriUrl),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        final List<dynamic> data = jsonDecode(response.body);
        return data.map((json) => UyelikTipi.fromJson(json)).toList();
      } else {
        throw Exception('Üyelik tipleri yüklenemedi');
      }
    } catch (e) {
      throw Exception('Bağlantı hatası: $e');
    }
  }

  // ID'ye göre üyelik tipini getir - YENİ EKLENEN METOD 👇
  static Future<UyelikTipi> getUyelikTipiById(int id) async {
    try {
      final response = await http.get(
        Uri.parse(ApiConfig.getUyelikTipiUrl(id)),
        headers: {'Content-Type': 'application/json'},
      );

      if (response.statusCode == 200) {
        return UyelikTipi.fromJson(jsonDecode(response.body));
      } else {
        throw Exception('Üyelik tipi bulunamadı');
      }
    } catch (e) {
      throw Exception('Bağlantı hatası: $e');
    }
  }

  // Belirli bir üyelik tipinin fiyatını getir (isme göre)
  static Future<double> getUyelikFiyati(String uyelikAdi) async {
    try {
      final uyelikler = await getUyelikTipleri();
      final uyelik = uyelikler.firstWhere(
            (u) => u.ad.toLowerCase() == uyelikAdi.toLowerCase(),
        orElse: () => throw Exception('Üyelik tipi bulunamadı'),
      );
      return uyelik.fiyat;
    } catch (e) {
      throw Exception('Fiyat alınamadı: $e');
    }
  }
}