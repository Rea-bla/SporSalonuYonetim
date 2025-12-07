import 'dart:convert';
import 'package:http/http.dart' as http;
import '../config/api_config.dart';
import '../models/member_model.dart';

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
}
