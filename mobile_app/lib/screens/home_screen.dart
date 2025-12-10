import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'dart:ui';
import '../models/member_model.dart';
import 'membership_info_screen.dart';
import 'personal_info_screen.dart';
import 'qr_code_screen.dart';
import 'change_password_screen.dart';
import 'login_screen.dart';

// MenuItemData class - defined outside the widget
class MenuItemData {
  final IconData icon;
  final String title;
  final List<Color> gradient;
  final VoidCallback onTap;

  MenuItemData({
    required this.icon,
    required this.title,
    required this.gradient,
    required this.onTap,
  });
}

class HomeScreen extends StatefulWidget {
  final Member member;

  const HomeScreen({super.key, required this.member});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> with SingleTickerProviderStateMixin {
  late AnimationController _animationController;
  late Animation<double> _fadeAnimation;
  late Animation<Offset> _slideAnimation;

  @override
  void initState() {
    super.initState();
    _animationController = AnimationController(
      vsync: this,
      duration: const Duration(milliseconds: 1200),
    );
    _fadeAnimation = Tween<double>(begin: 0.0, end: 1.0).animate(
      CurvedAnimation(parent: _animationController, curve: Curves.easeInOut),
    );
    _slideAnimation = Tween<Offset>(
      begin: const Offset(0, 0.3),
      end: Offset.zero,
    ).animate(CurvedAnimation(parent: _animationController, curve: Curves.easeOutCubic));
    _animationController.forward();
  }

  @override
  void dispose() {
    _animationController.dispose();
    super.dispose();
  }

  // Check if payment is unpaid
  bool isPaymentUnpaid() {
    final odeme = widget.member.odeme.toLowerCase().trim();
    return odeme == 'ödenmedi' || odeme == 'odenmedi';
  }

  // Check if membership should be active
  bool isMembershipActive() {
    // If payment is unpaid, membership is not active
    if (isPaymentUnpaid()) {
      return false;
    }

    // Check expiration date
    if (widget.member.bitisTarihi != null) {
      return widget.member.bitisTarihi!.isAfter(DateTime.now());
    }

    return widget.member.membershipActive;
  }

  Future<void> _logout(BuildContext context) async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.clear();

    if (!context.mounted) return;

    Navigator.of(context).pushReplacement(
      MaterialPageRoute(builder: (context) => const LoginScreen()),
    );
  }

  @override
  Widget build(BuildContext context) {
    final membershipActive = isMembershipActive();
    final paymentUnpaid = isPaymentUnpaid();

    return Scaffold(
      body: Container(
        decoration: const BoxDecoration(
          gradient: LinearGradient(
            begin: Alignment.topLeft,
            end: Alignment.bottomRight,
            colors: [
              Color(0xFF6B4CE6),
              Color(0xFF9B6CE6),
              Color(0xFFD946EF),
              Color(0xFFEC4899),
            ],
            stops: [0.0, 0.3, 0.7, 1.0],
          ),
        ),
        child: SafeArea(
          child: Stack(
            children: [
              // Animated background circles
              Positioned(
                top: -80,
                right: -80,
                child: Container(
                  width: 250,
                  height: 250,
                  decoration: BoxDecoration(
                    shape: BoxShape.circle,
                    gradient: RadialGradient(
                      colors: [
                        Colors.white.withOpacity(0.15),
                        Colors.transparent,
                      ],
                    ),
                  ),
                ),
              ),
              Positioned(
                bottom: -100,
                left: -100,
                child: Container(
                  width: 300,
                  height: 300,
                  decoration: BoxDecoration(
                    shape: BoxShape.circle,
                    gradient: RadialGradient(
                      colors: [
                        Colors.white.withOpacity(0.15),
                        Colors.transparent,
                      ],
                    ),
                  ),
                ),
              ),

              // Main content
              Column(
                children: [
                  // Custom App Bar
                  _buildCustomAppBar(paymentUnpaid),

                  // Content
                  Expanded(
                    child: FadeTransition(
                      opacity: _fadeAnimation,
                      child: SlideTransition(
                        position: _slideAnimation,
                        child: SingleChildScrollView(
                          padding: const EdgeInsets.all(20.0),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              // Payment Warning Banner (if unpaid)
                              if (paymentUnpaid) ...[
                                _buildPaymentWarningBanner(),
                                const SizedBox(height: 20),
                              ],

                              // Welcome Card
                              _buildWelcomeCard(membershipActive),
                              const SizedBox(height: 30),

                              // Menu Grid
                              _buildMenuGrid(),
                            ],
                          ),
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildCustomAppBar(bool hasUnpaidPayment) {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 15),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          const Text(
            'Ana Sayfa',
            style: TextStyle(
              fontSize: 28,
              fontWeight: FontWeight.bold,
              color: Colors.white,
              shadows: [
                Shadow(
                  color: Colors.black26,
                  offset: Offset(0, 2),
                  blurRadius: 4,
                ),
              ],
            ),
          ),
          Row(
            children: [
              // Notification bell with badge
              if (hasUnpaidPayment)
                Padding(
                  padding: const EdgeInsets.only(right: 10),
                  child: Stack(
                    clipBehavior: Clip.none,
                    children: [
                      ClipRRect(
                        borderRadius: BorderRadius.circular(15),
                        child: BackdropFilter(
                          filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
                          child: Container(
                            decoration: BoxDecoration(
                              color: Colors.white.withOpacity(0.2),
                              borderRadius: BorderRadius.circular(15),
                              border: Border.all(
                                color: Colors.white.withOpacity(0.3),
                                width: 1,
                              ),
                            ),
                            child: IconButton(
                              icon: const Icon(Icons.notifications_active_rounded, color: Colors.white),
                              onPressed: () {},
                            ),
                          ),
                        ),
                      ),
                      Positioned(
                        right: 8,
                        top: 8,
                        child: Container(
                          width: 10,
                          height: 10,
                          decoration: BoxDecoration(
                            color: const Color(0xFFEF4444),
                            shape: BoxShape.circle,
                            border: Border.all(color: Colors.white, width: 2),
                            boxShadow: [
                              BoxShadow(
                                color: const Color(0xFFEF4444).withOpacity(0.5),
                                blurRadius: 4,
                                spreadRadius: 1,
                              ),
                            ],
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              // Logout button
              ClipRRect(
                borderRadius: BorderRadius.circular(15),
                child: BackdropFilter(
                  filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
                  child: Container(
                    decoration: BoxDecoration(
                      color: Colors.white.withOpacity(0.2),
                      borderRadius: BorderRadius.circular(15),
                      border: Border.all(
                        color: Colors.white.withOpacity(0.3),
                        width: 1,
                      ),
                    ),
                    child: IconButton(
                      icon: const Icon(Icons.logout_rounded, color: Colors.white),
                      onPressed: () => _logout(context),
                      tooltip: 'Çıkış Yap',
                    ),
                  ),
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }

  Widget _buildPaymentWarningBanner() {
    return TweenAnimationBuilder<double>(
      tween: Tween(begin: 0.0, end: 1.0),
      duration: const Duration(milliseconds: 800),
      curve: Curves.elasticOut,
      builder: (context, value, child) {
        return Transform.scale(
          scale: value,
          child: child,
        );
      },
      child: ClipRRect(
        borderRadius: BorderRadius.circular(20),
        child: BackdropFilter(
          filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
          child: Container(
            padding: const EdgeInsets.all(20),
            decoration: BoxDecoration(
              gradient: LinearGradient(
                begin: Alignment.topLeft,
                end: Alignment.bottomRight,
                colors: [
                  const Color(0xFFEF4444).withOpacity(0.9),
                  const Color(0xFFDC2626).withOpacity(0.8),
                ],
              ),
              borderRadius: BorderRadius.circular(20),
              border: Border.all(
                color: Colors.red.withOpacity(0.4),
                width: 1.5,
              ),
              boxShadow: [
                BoxShadow(
                  color: const Color(0xFFEF4444).withOpacity(0.3),
                  blurRadius: 20,
                  offset: const Offset(0, 8),
                ),
              ],
            ),
            child: Column(
              children: [
                Row(
                  children: [
                    Container(
                      padding: const EdgeInsets.all(12),
                      decoration: BoxDecoration(
                        color: Colors.white.withOpacity(0.2),
                        borderRadius: BorderRadius.circular(12),
                      ),
                      child: const Icon(
                        Icons.warning_rounded,
                        color: Colors.white,
                        size: 28,
                      ),
                    ),
                    const SizedBox(width: 15),
                    Expanded(
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          const Text(
                            'Ödeme Yapılmadı!',
                            style: TextStyle(
                              color: Colors.white,
                              fontSize: 18,
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                          const SizedBox(height: 4),
                          Text(
                            'Üyeliğiniz aktif değil',
                            style: TextStyle(
                              color: Colors.white.withOpacity(0.9),
                              fontSize: 14,
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
                const SizedBox(height: 15),
                Container(
                  padding: const EdgeInsets.all(12),
                  decoration: BoxDecoration(
                    color: Colors.white.withOpacity(0.15),
                    borderRadius: BorderRadius.circular(12),
                  ),
                  child: const Row(
                    children: [
                      Icon(
                        Icons.info_outline_rounded,
                        color: Colors.white,
                        size: 18,
                      ),
                      SizedBox(width: 10),
                      Expanded(
                        child: Text(
                          'Lütfen ödemenizi tamamlamak için resepsiyonla iletişime geçin.',
                          style: TextStyle(
                            color: Colors.white,
                            fontSize: 13,
                            height: 1.4,
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _buildWelcomeCard(bool membershipActive) {
    return ClipRRect(
      borderRadius: BorderRadius.circular(25),
      child: BackdropFilter(
        filter: ImageFilter.blur(sigmaX: 15, sigmaY: 15),
        child: Container(
          width: double.infinity,
          padding: const EdgeInsets.all(24),
          decoration: BoxDecoration(
            gradient: LinearGradient(
              begin: Alignment.topLeft,
              end: Alignment.bottomRight,
              colors: [
                Colors.white.withOpacity(0.3),
                Colors.white.withOpacity(0.2),
              ],
            ),
            borderRadius: BorderRadius.circular(25),
            border: Border.all(
              color: Colors.white.withOpacity(0.3),
              width: 1.5,
            ),
            boxShadow: [
              BoxShadow(
                color: Colors.black.withOpacity(0.1),
                blurRadius: 20,
                spreadRadius: 5,
              ),
            ],
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Row(
                children: [
                  Container(
                    padding: const EdgeInsets.all(12),
                    decoration: BoxDecoration(
                      color: Colors.white.withOpacity(0.3),
                      borderRadius: BorderRadius.circular(15),
                    ),
                    child: const Icon(
                      Icons.person,
                      color: Colors.white,
                      size: 28,
                    ),
                  ),
                  const SizedBox(width: 15),
                  Expanded(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          'Hoş Geldiniz,',
                          style: TextStyle(
                            color: Colors.white.withOpacity(0.9),
                            fontSize: 14,
                            fontWeight: FontWeight.w500,
                          ),
                        ),
                        const SizedBox(height: 4),
                        Text(
                          widget.member.fullName,
                          style: const TextStyle(
                            color: Colors.white,
                            fontSize: 22,
                            fontWeight: FontWeight.bold,
                          ),
                          overflow: TextOverflow.ellipsis,
                        ),
                      ],
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 20),
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 10),
                decoration: BoxDecoration(
                  gradient: LinearGradient(
                    colors: membershipActive
                        ? [const Color(0xFF10B981), const Color(0xFF059669)]
                        : [const Color(0xFFEF4444), const Color(0xFFDC2626)],
                  ),
                  borderRadius: BorderRadius.circular(15),
                  boxShadow: [
                    BoxShadow(
                      color: (membershipActive
                          ? const Color(0xFF10B981)
                          : const Color(0xFFEF4444))
                          .withOpacity(0.4),
                      blurRadius: 12,
                      offset: const Offset(0, 6),
                    ),
                  ],
                ),
                child: Row(
                  mainAxisSize: MainAxisSize.min,
                  children: [
                    Icon(
                      membershipActive
                          ? Icons.check_circle_rounded
                          : Icons.cancel_rounded,
                      color: Colors.white,
                      size: 20,
                    ),
                    const SizedBox(width: 8),
                    Text(
                      membershipActive
                          ? 'Üyelik Aktif'
                          : 'Üyelik Aktif Değil',
                      style: const TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.bold,
                        fontSize: 14,
                      ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildMenuGrid() {
    final menuItems = [
      MenuItemData(
        icon: Icons.card_membership_rounded,
        title: 'Üyelik\nBilgileri',
        gradient: const [Color(0xFF8B5CF6), Color(0xFF6D28D9)],
        onTap: () => Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => MembershipInfoScreen(member: widget.member),
          ),
        ),
      ),
      MenuItemData(
        icon: Icons.person_rounded,
        title: 'Kişisel\nBilgiler',
        gradient: const [Color(0xFFF59E0B), Color(0xFFD97706)],
        onTap: () => Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => PersonalInfoScreen(member: widget.member),
          ),
        ),
      ),
      MenuItemData(
        icon: Icons.qr_code_rounded,
        title: 'QR\nKodum',
        gradient: const [Color(0xFF10B981), Color(0xFF059669)],
        onTap: () => Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => QRCodeScreen(member: widget.member),
          ),
        ),
      ),
      MenuItemData(
        icon: Icons.lock_reset_rounded,
        title: 'Şifre\nDeğiştir',
        gradient: const [Color(0xFFEF4444), Color(0xFFDC2626)],
        onTap: () => Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => ChangePasswordScreen(tcNo: widget.member.tcNo),
          ),
        ),
      ),
    ];

    return GridView.builder(
      shrinkWrap: true,
      physics: const NeverScrollableScrollPhysics(),
      gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
        crossAxisCount: 2,
        crossAxisSpacing: 15,
        mainAxisSpacing: 15,
        childAspectRatio: 1.0,
      ),
      itemCount: menuItems.length,
      itemBuilder: (context, index) {
        return _buildMenuCard(menuItems[index], index);
      },
    );
  }

  Widget _buildMenuCard(MenuItemData item, int index) {
    return TweenAnimationBuilder<double>(
      tween: Tween(begin: 0.0, end: 1.0),
      duration: Duration(milliseconds: 600 + (index * 100)),
      curve: Curves.easeOutBack,
      builder: (context, value, child) {
        return Transform.scale(
          scale: value,
          child: child,
        );
      },
      child: ClipRRect(
        borderRadius: BorderRadius.circular(20),
        child: BackdropFilter(
          filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
          child: Container(
            decoration: BoxDecoration(
              gradient: LinearGradient(
                begin: Alignment.topLeft,
                end: Alignment.bottomRight,
                colors: [
                  Colors.white.withOpacity(0.25),
                  Colors.white.withOpacity(0.15),
                ],
              ),
              borderRadius: BorderRadius.circular(20),
              border: Border.all(
                color: Colors.white.withOpacity(0.3),
                width: 1.5,
              ),
              boxShadow: [
                BoxShadow(
                  color: Colors.black.withOpacity(0.1),
                  blurRadius: 15,
                  spreadRadius: 2,
                ),
              ],
            ),
            child: Material(
              color: Colors.transparent,
              child: InkWell(
                onTap: item.onTap,
                borderRadius: BorderRadius.circular(20),
                splashColor: Colors.white.withOpacity(0.2),
                highlightColor: Colors.white.withOpacity(0.1),
                child: Padding(
                  padding: const EdgeInsets.all(20),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Container(
                        padding: const EdgeInsets.all(16),
                        decoration: BoxDecoration(
                          gradient: LinearGradient(
                            colors: item.gradient,
                          ),
                          borderRadius: BorderRadius.circular(18),
                          boxShadow: [
                            BoxShadow(
                              color: item.gradient[0].withOpacity(0.4),
                              blurRadius: 15,
                              offset: const Offset(0, 8),
                            ),
                          ],
                        ),
                        child: Icon(
                          item.icon,
                          size: 40,
                          color: Colors.white,
                        ),
                      ),
                      const SizedBox(height: 15),
                      Text(
                        item.title,
                        textAlign: TextAlign.center,
                        style: const TextStyle(
                          color: Colors.white,
                          fontSize: 15,
                          fontWeight: FontWeight.bold,
                          height: 1.3,
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}