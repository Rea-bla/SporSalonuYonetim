class ApiConfig {
  // ⭐ CHANGE THIS TO YOUR COMPUTER'S IP ADDRESS
  // Example: 'http://192.168.1.100:5096'
  static const String baseUrl = 'http://10.0.2.2:5096';

  // API Endpoints
  static const String loginEndpoint = '/api/MemberAuth/login';
  static const String getMemberEndpoint = '/api/Member';
  static const String updateMemberEndpoint = '/api/Member/update';
  static const String verifyEntryEndpoint = '/api/Member/verify-entry';
  static const String changePasswordEndpoint = '/api/Member/change-password';
  static const String uyelikTipleriEndpoint = '/api/UyelikTipleri'; // YENİ

  // Full URLs
  static String get loginUrl => '$baseUrl$loginEndpoint';
  static String get updateMemberUrl => '$baseUrl$updateMemberEndpoint';
  static String get verifyEntryUrl => '$baseUrl$verifyEntryEndpoint';
  static String get changePasswordUrl => '$baseUrl$changePasswordEndpoint';
  static String get uyelikTipleriUrl => '$baseUrl$uyelikTipleriEndpoint'; // YENİ

  static String getMemberUrl(String tcNo) => '$baseUrl$getMemberEndpoint/$tcNo';
  static String getUyelikTipiUrl(int id) => '$baseUrl$uyelikTipleriEndpoint/$id'; // YENİ
}
