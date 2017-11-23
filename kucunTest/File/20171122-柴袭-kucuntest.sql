/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50711
Source Host           : localhost:3306
Source Database       : kucuntest

Target Server Type    : MYSQL
Target Server Version : 50711
File Encoding         : 65001

Date: 2017-11-22 19:58:44
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `banzu`
-- ----------------------------
DROP TABLE IF EXISTS `banzu`;
CREATE TABLE `banzu` (
  `xh` int(20) NOT NULL AUTO_INCREMENT COMMENT '序号主键',
  `banzumingcheng` varchar(50) DEFAULT NULL COMMENT '班组名称',
  `shengchanxianmingcheng` varchar(50) DEFAULT NULL COMMENT '所属生产线名称',
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of banzu
-- ----------------------------
INSERT INTO `banzu` VALUES ('1', '机一车间_1204后箱班', '1204后箱班生产线');
INSERT INTO `banzu` VALUES ('2', '机一车间_80减速器班', '80减速器班生产线');
INSERT INTO `banzu` VALUES ('3', '机一车间_89减速器班', '89减速器班生产线');
INSERT INTO `banzu` VALUES ('4', '机一车间_100前箱班', '100前箱班生产线');
INSERT INTO `banzu` VALUES ('5', '机一车间_前托架班', '前托架班生产线');
INSERT INTO `banzu` VALUES ('6', '机一车间_综加班', '综加班生产线');

-- ----------------------------
-- Table structure for `celiangcanshu`
-- ----------------------------
DROP TABLE IF EXISTS `celiangcanshu`;
CREATE TABLE `celiangcanshu` (
  `xh` int(10) NOT NULL AUTO_INCREMENT,
  `djid` varchar(50) NOT NULL,
  `clsj` datetime DEFAULT NULL,
  `djzjxddsl` varchar(20) DEFAULT NULL,
  `dqgjbmccd` varchar(20) DEFAULT NULL,
  `yqgjbmccd` varchar(20) DEFAULT NULL,
  `djsysm` varchar(20) DEFAULT NULL,
  `djbjsjz` varchar(20) DEFAULT NULL,
  `djcdsjz` varchar(20) DEFAULT NULL,
  `djzpj` varchar(20) DEFAULT NULL,
  `djfpj` varchar(20) DEFAULT NULL,
  `djyhbj` varchar(20) DEFAULT NULL,
  `djdmtd` varchar(20) DEFAULT NULL,
  `djjxtd` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of celiangcanshu
-- ----------------------------
INSERT INTO `celiangcanshu` VALUES ('1', 'ZT-0001', '2017-07-27 23:15:05', '6', '40um', '50um', '200', '1.5', '2.0', '40', '20', '12', '0.005', '0.0025');
INSERT INTO `celiangcanshu` VALUES ('4', 'ZT-0001', '2017-07-28 14:50:48', '3', '40um', '50um', '200', '1.5', '2.0', '40', '20', '12', '0.005', '0.0025');
INSERT INTO `celiangcanshu` VALUES ('5', 'ZT-0002', '2017-07-28 15:44:18', '8', '1.56', '', '50', '', '', '30', '25', '', '', '');
INSERT INTO `celiangcanshu` VALUES ('6', 'ZT-0001', '2017-08-09 21:07:11', '4', '40um', '50um', '200', '1.5', '2.0', '40', '20', '12', '0.005', '0.0025');
INSERT INTO `celiangcanshu` VALUES ('7', 'ZT-0001', '2017-11-20 13:36:12', '3', '40um', '50um', '200', '1.5', '2.0', '40', '20', '12', '0.005', '0.0025');

-- ----------------------------
-- Table structure for `daoju`
-- ----------------------------
DROP TABLE IF EXISTS `daoju`;
CREATE TABLE `daoju` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `djxh` varchar(50) DEFAULT NULL,
  `djlx` varchar(50) DEFAULT NULL,
  `djgg` varchar(50) DEFAULT NULL,
  `djtp` blob,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=225 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daoju
-- ----------------------------
INSERT INTO `daoju` VALUES ('1', 'Φ10.4 钻头(T38)', '钻头', 'Φ10.4', null);
INSERT INTO `daoju` VALUES ('2', 'φ20.5 钻头(T52)', '钻头', 'φ20.5', null);
INSERT INTO `daoju` VALUES ('3', 'Φ22 钻头(T49)', '钻头', 'Φ22', null);
INSERT INTO `daoju` VALUES ('4', 'φ14.5 钻头(T202)', '钻头', 'φ14.5', null);
INSERT INTO `daoju` VALUES ('5', 'φ10.5 钻头(T57)', '钻头', 'φ10.5', null);
INSERT INTO `daoju` VALUES ('6', 'Φ26 钻头(T118)', '钻头', 'Φ26', null);
INSERT INTO `daoju` VALUES ('7', 'Φ10.7 钻头(T140)', '钻头', 'Φ10.7', null);
INSERT INTO `daoju` VALUES ('8', 'Φ10.7 钻头(T141)', '钻头', 'Φ10.7', null);
INSERT INTO `daoju` VALUES ('9', 'Φ6 钻头(T148)', '钻头', 'Φ6', null);
INSERT INTO `daoju` VALUES ('10', 'Φ12.5 钻头(T144)', '钻头', 'Φ12.5', null);
INSERT INTO `daoju` VALUES ('11', 'Φ15.7 钻头(T149)', '钻头', 'Φ15.7', null);
INSERT INTO `daoju` VALUES ('12', 'φ20.5 钻头(T116)', '钻头', 'φ20.5', null);
INSERT INTO `daoju` VALUES ('13', 'Φ26 钻(T111)', '钻头', 'Φ26', null);
INSERT INTO `daoju` VALUES ('14', 'φ16 中心钻(T117)', '中心钻', 'φ16', null);
INSERT INTO `daoju` VALUES ('15', 'Φ10.4 直槽钻(T39)', '直槽钻', 'Φ10.4', null);
INSERT INTO `daoju` VALUES ('16', 'Φ18.5 直槽钻(T59)', '直槽钻', 'Φ18.5', null);
INSERT INTO `daoju` VALUES ('17', 'φ6.8 直槽钻(T79)', '直槽钻', 'φ6.8', null);
INSERT INTO `daoju` VALUES ('18', 'φ17.5 直槽钻(T81)', '直槽钻', 'φ17.5', null);
INSERT INTO `daoju` VALUES ('19', 'Φ100玉米铣(T1055)', '玉米铣', 'Φ100', null);
INSERT INTO `daoju` VALUES ('20', 'Φ44玉米铣(T1055)', '玉米铣', 'Φ44', null);
INSERT INTO `daoju` VALUES ('21', 'φ32玉米铣T1104', '玉米铣', 'φ32', null);
INSERT INTO `daoju` VALUES ('22', 'Φ8.65 硬钻(T1028)', '硬钻', 'Φ8.65', null);
INSERT INTO `daoju` VALUES ('23', 'Φ27 硬钻(T1047)', '硬钻', 'Φ27', null);
INSERT INTO `daoju` VALUES ('24', 'Φ12硬钻（T1009)', '硬钻', 'Φ12', null);
INSERT INTO `daoju` VALUES ('25', 'Φ10.8硬钻（T1010)', '硬钻', 'Φ10.8', null);
INSERT INTO `daoju` VALUES ('26', 'φ13 硬钻(T131)', '硬钻', 'φ13', null);
INSERT INTO `daoju` VALUES ('27', 'φ6.8 硬钻(T116)', '硬钻', 'φ6.8', null);
INSERT INTO `daoju` VALUES ('28', 'φ19.7硬钻(T119)', '硬钻', 'φ19.7', null);
INSERT INTO `daoju` VALUES ('29', 'φ8.7 硬钻(T35)', '硬钻', 'φ8.7', null);
INSERT INTO `daoju` VALUES ('30', 'φ13 硬钻(T77)', '硬钻', 'φ13', null);
INSERT INTO `daoju` VALUES ('31', 'φ11 硬钻(T40)', '硬钻', 'φ11', null);
INSERT INTO `daoju` VALUES ('32', 'φ15.7 硬钻(T45)', '硬钻', 'φ15.7', null);
INSERT INTO `daoju` VALUES ('33', 'φ12.5 硬钻(T46)', '硬钻', 'φ12.5', null);
INSERT INTO `daoju` VALUES ('34', 'φ10.7 硬钻(T47)', '硬钻', 'φ10.7', null);
INSERT INTO `daoju` VALUES ('35', 'Φ10.7 硬钻(T49)', '硬钻', 'Φ10.7', null);
INSERT INTO `daoju` VALUES ('36', 'Φ6.05 硬钻(T59)', '硬钻', 'Φ6.05', null);
INSERT INTO `daoju` VALUES ('37', 'Φ6.05 硬钻(T60)', '硬钻', 'Φ6.05', null);
INSERT INTO `daoju` VALUES ('38', 'Φ13 硬钻(T114)', '硬钻', 'Φ13', null);
INSERT INTO `daoju` VALUES ('39', 'Φ17.5 硬钻(T82)', '硬钻', 'Φ17.5', null);
INSERT INTO `daoju` VALUES ('40', 'Φ8.7 硬钻(T86)', '硬钻', 'Φ8.7', null);
INSERT INTO `daoju` VALUES ('41', 'Φ11 硬钻(T88)', '硬钻', 'Φ11', null);
INSERT INTO `daoju` VALUES ('42', 'Φ11.7 硬钻(T89)', '硬钻', 'Φ11.7', null);
INSERT INTO `daoju` VALUES ('43', 'Φ13 硬钻(T90)', '硬钻', 'Φ13', null);
INSERT INTO `daoju` VALUES ('44', 'Φ20铣刀（立）(T53)', '铣刀（立）', 'Φ20', null);
INSERT INTO `daoju` VALUES ('45', 'Φ100 铣刀(T1001)', '铣刀', 'Φ100', null);
INSERT INTO `daoju` VALUES ('46', 'Φ100 铣刀(T1009)', '铣刀', 'Φ100', null);
INSERT INTO `daoju` VALUES ('47', 'Φ84 铣刀(T1015)', '铣刀', 'Φ84', null);
INSERT INTO `daoju` VALUES ('48', 'Φ80 铣刀（T1035）', '铣刀', 'Φ80', null);
INSERT INTO `daoju` VALUES ('49', 'Φ50铣刀(T1054)', '铣刀', 'Φ50', null);
INSERT INTO `daoju` VALUES ('50', 'Φ100铣刀(T1002)', '铣刀', 'Φ100', null);
INSERT INTO `daoju` VALUES ('51', 'Φ25铣刀(T1017)', '铣刀', 'Φ25', null);
INSERT INTO `daoju` VALUES ('52', 'Φ100铣刀(T1028)', '铣刀', 'Φ100', null);
INSERT INTO `daoju` VALUES ('53', 'Φ80铣刀(T1058)', '铣刀', 'Φ80', null);
INSERT INTO `daoju` VALUES ('54', 'D80 铣刀(T185)', '铣刀', 'D80', null);
INSERT INTO `daoju` VALUES ('55', 'D63 铣刀(T101)', '铣刀', 'D63', null);
INSERT INTO `daoju` VALUES ('56', 'Φ30 铣刀(T102)', '铣刀', 'Φ30', null);
INSERT INTO `daoju` VALUES ('57', 'D25 铣刀(T132)', '铣刀', 'D25', null);
INSERT INTO `daoju` VALUES ('58', 'φ20 铣刀(T137)', '铣刀', 'φ20', null);
INSERT INTO `daoju` VALUES ('59', 'Φ32 铣刀(T64)', '铣刀', 'Φ32', null);
INSERT INTO `daoju` VALUES ('60', 'Φ40 铣刀(T130)', '铣刀', 'Φ40', null);
INSERT INTO `daoju` VALUES ('61', 'D125 铣刀(T20)', '铣刀', 'D125', null);
INSERT INTO `daoju` VALUES ('62', 'Φ20 铣刀(T50)', '铣刀', 'Φ20', null);
INSERT INTO `daoju` VALUES ('63', 'Φ34 铣刀(T120)', '铣刀', 'Φ34', null);
INSERT INTO `daoju` VALUES ('64', 'D63/C30 铣刀（T169)', '铣刀', 'D63/C30', null);
INSERT INTO `daoju` VALUES ('65', 'Φ63 铣槽刀(T78)', '铣槽刀', 'Φ63', null);
INSERT INTO `daoju` VALUES ('66', 'Φ31.5 镗刀(T1032)', '镗刀', 'Φ31.5', null);
INSERT INTO `daoju` VALUES ('67', 'Φ15镗刀（T1008)', '镗刀', 'Φ15', null);
INSERT INTO `daoju` VALUES ('68', 'Φ12 镗刀(T1013)', '镗刀', 'Φ12', null);
INSERT INTO `daoju` VALUES ('69', 'Φ42 镗刀(T1021)', '镗刀', 'Φ42', null);
INSERT INTO `daoju` VALUES ('70', 'Φ20 镗刀(T1023)', '镗刀', 'Φ20', null);
INSERT INTO `daoju` VALUES ('71', 'Φ15镗刀(T1054)', '镗刀', 'Φ15', null);
INSERT INTO `daoju` VALUES ('72', 'φ35.72 镗刀(T177)', '镗刀', 'φ35.72', null);
INSERT INTO `daoju` VALUES ('73', 'M10×1 丝锥(T1003)', '丝锥', 'M10×1', null);
INSERT INTO `daoju` VALUES ('74', 'M8 丝锥(T1005)', '丝锥', 'M8', null);
INSERT INTO `daoju` VALUES ('75', 'M22x1.5 丝锥(T1011)', '丝锥', 'M22x1.5', null);
INSERT INTO `daoju` VALUES ('76', 'M12×6H 丝锥（T1013)', '丝锥', 'M12×6H', null);
INSERT INTO `daoju` VALUES ('77', 'M20 丝锥(T1022)', '丝锥', 'M20', null);
INSERT INTO `daoju` VALUES ('78', 'M12×1.25 丝锥(T1025)', '丝锥', 'M12×1.25', null);
INSERT INTO `daoju` VALUES ('79', 'M10x1 丝锥(T1030)', '丝锥', 'M10x1', null);
INSERT INTO `daoju` VALUES ('80', 'M16x1.5 丝锥(T1038)', '丝锥', 'M16x1.5', null);
INSERT INTO `daoju` VALUES ('81', 'M10×1.5丝锥(T1113)', '丝锥', 'M10×1.5', null);
INSERT INTO `daoju` VALUES ('82', 'M16×1.5丝锥（T1005)', '丝锥', 'M16×1.5', null);
INSERT INTO `daoju` VALUES ('83', 'M12×1.25丝锥（T1011)', '丝锥', 'M12×1.25', null);
INSERT INTO `daoju` VALUES ('84', 'M10×1.25丝锥(T1016)', '丝锥', 'M10×1.25', null);
INSERT INTO `daoju` VALUES ('85', 'M22×1.5丝锥(T1019)', '丝锥', 'M22×1.5', null);
INSERT INTO `daoju` VALUES ('86', 'M8丝锥(T1042)', '丝锥', 'M8', null);
INSERT INTO `daoju` VALUES ('87', 'M10×1丝锥(T1045)', '丝锥', 'M10×1', null);
INSERT INTO `daoju` VALUES ('88', 'M6丝锥(T1047)', '丝锥', 'M6', null);
INSERT INTO `daoju` VALUES ('89', 'M18×1.5丝锥(T1049)', '丝锥', 'M18×1.5', null);
INSERT INTO `daoju` VALUES ('90', 'M22*1.5丝锥(T1101)', '丝锥', 'M22*1.5', null);
INSERT INTO `daoju` VALUES ('91', 'M8*1.25丝锥(T118)', '丝锥', 'M8*1.25', null);
INSERT INTO `daoju` VALUES ('92', 'M10*1.25 丝锥(T36)', '丝锥', 'M10*1.25', null);
INSERT INTO `daoju` VALUES ('93', 'M14*1.5 丝锥(T50)', '丝锥', 'M14*1.5', null);
INSERT INTO `daoju` VALUES ('94', 'M12*1.25 丝锥(T51)', '丝锥', 'M12*1.25', null);
INSERT INTO `daoju` VALUES ('95', 'M22*1.5 丝锥(T134)', '丝锥', 'M22*1.5', null);
INSERT INTO `daoju` VALUES ('96', 'M12*1.5 丝锥(T58)', '丝锥', 'M12*1.5', null);
INSERT INTO `daoju` VALUES ('97', 'M20*1.5 丝锥(T61)', '丝锥', 'M20*1.5', null);
INSERT INTO `daoju` VALUES ('98', 'M8*1.25 丝锥(T80)', '丝锥', 'M8*1.25', null);
INSERT INTO `daoju` VALUES ('99', 'M10*1.25 丝锥(T92)', '丝锥', 'M10*1.25', null);
INSERT INTO `daoju` VALUES ('100', 'M22*1.5 丝锥(T117)', '丝锥', 'M22*1.5', null);
INSERT INTO `daoju` VALUES ('101', 'M12*1.25 丝锥(T142)', '丝锥', 'M12*1.25', null);
INSERT INTO `daoju` VALUES ('102', 'M14*1.5 丝锥(T147)', '丝锥', 'M14*1.5', null);
INSERT INTO `daoju` VALUES ('103', 'Φ20H9 枪钻(T1046)', '枪钻', 'Φ20H9', null);
INSERT INTO `daoju` VALUES ('104', 'M39螺纹铣刀（T1103）', '螺纹铣刀', 'M39', null);
INSERT INTO `daoju` VALUES ('105', 'D16*2 螺纹铣刀(T53)', '螺纹铣刀', 'D16*2', null);
INSERT INTO `daoju` VALUES ('106', 'M16*1.5 螺纹铣刀(T56)', '螺纹铣刀', 'M16*1.5', null);
INSERT INTO `daoju` VALUES ('107', '  Φ12立铣刀 (T1052)', '立铣刀', 'Φ13', null);
INSERT INTO `daoju` VALUES ('108', 'Φ16立铣刀(T1056)', '立铣刀', 'Φ16', null);
INSERT INTO `daoju` VALUES ('109', 'Φ25 立铣刀(T86)', '立铣刀', 'Φ25', null);
INSERT INTO `daoju` VALUES ('110', 'Φ11 立铣刀(T87)', '立铣刀', 'Φ11', null);
INSERT INTO `daoju` VALUES ('111', 'φ11.7 扩孔钻(T41)', '扩孔钻', 'φ11.7', null);
INSERT INTO `daoju` VALUES ('112', 'Φ26.5 扩孔钻(T67)', '扩孔钻', 'Φ26.5', null);
INSERT INTO `daoju` VALUES ('113', 'Φ29.5 扩孔钻(T60)', '扩孔钻', 'Φ29.5', null);
INSERT INTO `daoju` VALUES ('114', 'Φ25 扩孔钻(T1034)', '扩孔钻', 'Φ25', null);
INSERT INTO `daoju` VALUES ('115', 'Φ250*15 宽精铣刀（T225）', '宽精铣刀', 'Φ250*15', null);
INSERT INTO `daoju` VALUES ('116', 'Φ250*15 宽精铣刀（T225)', '宽精铣刀', 'Φ250*15', null);
INSERT INTO `daoju` VALUES ('117', 'D63 精铣(T76)', '精铣', 'D63', null);
INSERT INTO `daoju` VALUES ('118', 'D80 精铣(T201)', '精铣', 'D80', null);
INSERT INTO `daoju` VALUES ('119', 'D80 精铣(T199)', '精铣', 'D80', null);
INSERT INTO `daoju` VALUES ('120', 'D25 精铣(T110)', '精铣', 'D25', null);
INSERT INTO `daoju` VALUES ('121', 'Φ120 精镗刀', '精镗刀', 'Φ121', null);
INSERT INTO `daoju` VALUES ('122', 'Φ32 精镗(T1033)', '精镗', 'Φ32', null);
INSERT INTO `daoju` VALUES ('123', 'Φ15R8 精镗(T1040)', '精镗', 'Φ15R8', null);
INSERT INTO `daoju` VALUES ('124', 'Φ15F9 精镗(T1041)', '精镗', 'Φ15F9', null);
INSERT INTO `daoju` VALUES ('125', 'Φ18F9 精镗(T1044)', '精镗', 'Φ18F9', null);
INSERT INTO `daoju` VALUES ('126', 'Φ30精镗(T1049)', '精镗', 'Φ30', null);
INSERT INTO `daoju` VALUES ('127', 'Φ110/Φ130精镗(T1050)', '精镗', 'Φ110/Φ130', null);
INSERT INTO `daoju` VALUES ('128', 'Φ120精镗(T1051)', '精镗', 'Φ120', null);
INSERT INTO `daoju` VALUES ('129', 'Φ38精镗(T1053)', '精镗', 'Φ38', null);
INSERT INTO `daoju` VALUES ('130', 'Φ130精镗(T1057)', '精镗', 'Φ130', null);
INSERT INTO `daoju` VALUES ('131', 'Φ120精镗(T1056)', '精镗', 'Φ120', null);
INSERT INTO `daoju` VALUES ('132', 'Φ68精镗(T73)', '精镗', 'Φ68', null);
INSERT INTO `daoju` VALUES ('133', 'Φ85精镗(T74)', '精镗', 'Φ85', null);
INSERT INTO `daoju` VALUES ('134', 'Φ30精镗(T75)', '精镗', 'Φ30', null);
INSERT INTO `daoju` VALUES ('135', 'Φ80 精镗 (T37)', '精镗', 'Φ80', null);
INSERT INTO `daoju` VALUES ('136', 'Φ72 精镗 (T66)', '精镗', 'Φ72', null);
INSERT INTO `daoju` VALUES ('137', 'Φ396 精镗(T13)', '精镗', 'Φ396', null);
INSERT INTO `daoju` VALUES ('138', 'Φ190 精镗(T235)', '精镗', 'Φ190', null);
INSERT INTO `daoju` VALUES ('139', 'Φ90 精镗(T175)', '精镗', 'Φ90', null);
INSERT INTO `daoju` VALUES ('140', 'Φ85 精镗(T176)', '精镗', 'Φ85', null);
INSERT INTO `daoju` VALUES ('141', 'Φ30 精镗(T62)', '精镗', 'Φ30', null);
INSERT INTO `daoju` VALUES ('142', 'Φ29 阶梯钻(T1031)', '阶梯钻', 'Φ29', null);
INSERT INTO `daoju` VALUES ('143', 'Φ6.8阶梯钻(T1041)', '阶梯钻', 'Φ6.8', null);
INSERT INTO `daoju` VALUES ('144', 'Φ20阶梯钻(T1043)', '阶梯钻', 'Φ20', null);
INSERT INTO `daoju` VALUES ('145', 'Φ9阶梯钻(T1044)', '阶梯钻', 'Φ9', null);
INSERT INTO `daoju` VALUES ('146', 'Φ5阶梯钻(T1046)', '阶梯钻', 'Φ5', null);
INSERT INTO `daoju` VALUES ('147', 'Φ16.5阶梯钻(T1048)', '阶梯钻', 'Φ16.5', null);
INSERT INTO `daoju` VALUES ('148', 'Φ11.8阶梯钻(T1050)', '阶梯钻', 'Φ11.8', null);
INSERT INTO `daoju` VALUES ('149', 'Φ17阶梯钻(T1063)', '阶梯钻', 'Φ17', null);
INSERT INTO `daoju` VALUES ('150', 'Φ12F9-铰刀 (T1051)', '铰刀', 'Φ12F9-', null);
INSERT INTO `daoju` VALUES ('151', 'Φ18R8铰刀(T79)', '铰刀', 'Φ18R8', null);
INSERT INTO `daoju` VALUES ('152', 'Φ20H9铰刀(T80)', '铰刀', 'Φ20H9', null);
INSERT INTO `daoju` VALUES ('153', 'Φ12R8 铰刀(T42)', '铰刀', 'Φ12R8', null);
INSERT INTO `daoju` VALUES ('154', 'Φ16F9 铰刀(T56)', '铰刀', 'Φ16F9', null);
INSERT INTO `daoju` VALUES ('155', 'Φ28 铰刀(T58)', '铰刀', 'Φ28', null);
INSERT INTO `daoju` VALUES ('156', 'Φ26.82 铰刀(T68)', '铰刀', 'Φ26.82', null);
INSERT INTO `daoju` VALUES ('157', 'Φ12R8 铰刀(T93)', '铰刀', 'Φ12R8', null);
INSERT INTO `daoju` VALUES ('158', 'Φ13.2H7 铰刀(T143)', '铰刀', 'Φ13.2H7', null);
INSERT INTO `daoju` VALUES ('159', 'Φ16F9 铰刀(T151)', '铰刀', 'Φ16F9', null);
INSERT INTO `daoju` VALUES ('160', 'Φ17.7锪孔钻(T115)', '锪孔钻', 'Φ17.7', null);
INSERT INTO `daoju` VALUES ('161', 'Φ120反精镗刀(T30)', '反精镗刀', 'Φ120', null);
INSERT INTO `daoju` VALUES ('162', 'Φ200 反精镗(T17)', '反精镗', 'Φ200', null);
INSERT INTO `daoju` VALUES ('163', 'Φ17.5/Φ40 反划(T83)', '反划', 'Φ17.5/Φ40', null);
INSERT INTO `daoju` VALUES ('164', 'φ12 倒角钻(T71)', '倒角钻', 'φ12', null);
INSERT INTO `daoju` VALUES ('165', 'Φ21-Φ35 倒角钻(T52)', '倒角钻', 'Φ21-Φ35', null);
INSERT INTO `daoju` VALUES ('166', 'φ20 倒角钻(T200)', '倒角钻', 'φ20', null);
INSERT INTO `daoju` VALUES ('167', 'Φ50 倒角铣刀(T1020)', '倒角铣刀', 'Φ50', null);
INSERT INTO `daoju` VALUES ('168', 'Φ32.5-48.2倒角铣(T105)', '倒角铣', 'Φ32.5-48.2', null);
INSERT INTO `daoju` VALUES ('169', 'Φ42 倒角铣(T110)', '倒角铣', 'Φ42', null);
INSERT INTO `daoju` VALUES ('170', 'D40/C45 倒角铣(T180)', '倒角铣', 'D40/C45', null);
INSERT INTO `daoju` VALUES ('171', 'D63/C30 倒角刀(T81)', '倒角刀', 'D63/C30', null);
INSERT INTO `daoju` VALUES ('172', 'Φ21-Φ35倒角(T113)', '倒角', 'Φ21-Φ35', null);
INSERT INTO `daoju` VALUES ('173', 'D80 粗铣(T63)', '粗铣', 'D80', null);
INSERT INTO `daoju` VALUES ('174', 'D25 粗铣(T109)', '粗铣', 'D25', null);
INSERT INTO `daoju` VALUES ('175', 'Φ63 粗镗刀(T103)', '粗镗刀', 'Φ63', null);
INSERT INTO `daoju` VALUES ('176', 'φ75 粗镗刀(T136)', '粗镗刀', 'φ75', null);
INSERT INTO `daoju` VALUES ('177', 'φ180 粗镗刀', '粗镗刀', 'φ180', null);
INSERT INTO `daoju` VALUES ('178', 'φ416 粗镗刀', '粗镗刀', 'φ416', null);
INSERT INTO `daoju` VALUES ('179', 'Φ170 粗镗刀', '粗镗刀', 'Φ170', null);
INSERT INTO `daoju` VALUES ('180', 'Φ37.5粗镗(T1052)', '粗镗', 'Φ37.5', null);
INSERT INTO `daoju` VALUES ('181', 'Φ101 粗镗(T106)', '粗镗', 'Φ101', null);
INSERT INTO `daoju` VALUES ('182', 'Φ106 粗镗(T107)', '粗镗', 'Φ106', null);
INSERT INTO `daoju` VALUES ('183', 'Φ80 粗镗(T108)', '粗镗', 'Φ80', null);
INSERT INTO `daoju` VALUES ('184', 'Φ29.7 粗镗(T112)', '粗镗', 'Φ29.7', null);
INSERT INTO `daoju` VALUES ('185', 'Φ115 粗镗(T22)', '粗镗', 'Φ115', null);
INSERT INTO `daoju` VALUES ('186', 'Φ67 粗镗 (T61)', '粗镗', 'Φ67', null);
INSERT INTO `daoju` VALUES ('187', 'Φ189.5 粗镗(T229)', '粗镗', 'Φ189.5', null);
INSERT INTO `daoju` VALUES ('188', 'Φ391 粗镗(T8)', '粗镗', 'Φ391', null);
INSERT INTO `daoju` VALUES ('189', 'φ395.5 粗镗(T2)', '粗镗', 'φ395.5', null);
INSERT INTO `daoju` VALUES ('190', 'Φ33.7 粗镗(T145)', '粗镗', 'Φ33.7', null);
INSERT INTO `daoju` VALUES ('191', 'φ88.5 粗镗(T170)', '粗镗', 'φ88.5', null);
INSERT INTO `daoju` VALUES ('192', 'φ80 粗镗(T172)', '粗镗', 'φ80', null);
INSERT INTO `daoju` VALUES ('193', 'Φ20.2*3.5 槽铣刀（T150)', '槽铣刀', 'Φ20.2*3.5', null);
INSERT INTO `daoju` VALUES ('194', 'φ63*3.15 槽铣刀(T174)', '槽铣刀', 'φ63*3.15', null);
INSERT INTO `daoju` VALUES ('195', 'Φ29.5 半精镗(T1048)', '半精镗', 'Φ29.5', null);
INSERT INTO `daoju` VALUES ('196', 'Φ67.7半精镗(T104)', '半精镗', 'Φ67.7', null);
INSERT INTO `daoju` VALUES ('197', 'φ84.7半精镗(T109)', '半精镗', 'φ84.7', null);
INSERT INTO `daoju` VALUES ('198', 'Φ119.7半精镗(T20)', '半精镗', 'Φ119.7', null);
INSERT INTO `daoju` VALUES ('199', 'Φ79.7 半精镗(T34)', '半精镗', 'Φ79.7', null);
INSERT INTO `daoju` VALUES ('200', 'Φ27.7 半精镗(T57)', '半精镗', 'Φ27.7', null);
INSERT INTO `daoju` VALUES ('201', 'Φ71.7 半精镗(T62)', '半精镗', 'Φ71.7', null);
INSERT INTO `daoju` VALUES ('202', 'Φ27.7 半精镗(T119)', '半精镗', 'Φ27.7', null);
INSERT INTO `daoju` VALUES ('203', 'φ35.4 半精镗(T146)', '半精镗', 'φ35.4', null);
INSERT INTO `daoju` VALUES ('204', 'φ89.7 半精镗(T171)', '半精镗', 'φ89.7', null);
INSERT INTO `daoju` VALUES ('205', 'φ84.7 半精镗(T173)', '半精镗', 'φ84.7', null);
INSERT INTO `daoju` VALUES ('206', 'Φ25U钻(T1057)', 'U钻', 'Φ25', null);
INSERT INTO `daoju` VALUES ('207', 'Φ20.5U钻(T1100)', 'U钻', 'Φ20.5', null);
INSERT INTO `daoju` VALUES ('208', 'φ37U钻（T1102）', 'U钻', 'φ37', null);
INSERT INTO `daoju` VALUES ('210', 'φ520 钻头', '钻头', 'φ520', null);
INSERT INTO `daoju` VALUES ('211', 'φ21.2 中心钻', '中心钻', 'φ21.2', null);
INSERT INTO `daoju` VALUES ('212', 'φ520 中心钻', '中心钻', 'φ520', null);
INSERT INTO `daoju` VALUES ('214', 'φ520 铣槽刀', '铣槽刀', 'φ520', null);
INSERT INTO `daoju` VALUES ('216', 'φ520H212 枪钻', '枪钻', 'φ520H212', null);
INSERT INTO `daoju` VALUES ('224', '212-测试刀具', '212lab', '112', '');

-- ----------------------------
-- Table structure for `daojubaofei`
-- ----------------------------
DROP TABLE IF EXISTS `daojubaofei`;
CREATE TABLE `daojubaofei` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL,
  `djzt` int(2) DEFAULT NULL,
  `sqbz` varchar(20) NOT NULL,
  `sqr` varchar(10) NOT NULL,
  `sqsb` varchar(20) NOT NULL,
  `sqsj` date NOT NULL,
  `jglj` varchar(20) NOT NULL,
  `gx` varchar(20) NOT NULL,
  `djlx` char(50) NOT NULL,
  `djgg` char(20) NOT NULL,
  `djcd` char(10) DEFAULT NULL,
  `djid` char(20) DEFAULT NULL,
  `bfyy` text NOT NULL,
  `spld` varchar(20) NOT NULL,
  `spyj` text NOT NULL,
  `spsj` date NOT NULL,
  `jbr` varchar(10) NOT NULL,
  `bfzcwz` varchar(50) DEFAULT NULL,
  `jtwz` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `danhao` (`danhao`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojubaofei
-- ----------------------------

-- ----------------------------
-- Table structure for `daojugenghuan`
-- ----------------------------
DROP TABLE IF EXISTS `daojugenghuan`;
CREATE TABLE `daojugenghuan` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL,
  `djzt` int(2) DEFAULT NULL,
  `sqbz` varchar(20) NOT NULL,
  `sqr` varchar(10) NOT NULL,
  `sqsb` varchar(20) NOT NULL,
  `sqsj` date NOT NULL,
  `jglj` varchar(20) NOT NULL,
  `gx` varchar(20) NOT NULL,
  `ydjlx` char(50) NOT NULL,
  `ydjgg` char(20) NOT NULL,
  `ydjcd` char(10) DEFAULT NULL,
  `ydjid` char(20) DEFAULT NULL,
  `xdjlx` char(50) NOT NULL,
  `xdjgg` char(20) NOT NULL,
  `xdjcd` char(10) DEFAULT NULL,
  `xdjid` char(20) DEFAULT NULL,
  `ghly` text NOT NULL,
  `spld` varchar(20) NOT NULL,
  `spyj` text NOT NULL,
  `spsj` date NOT NULL,
  `jbr` varchar(10) NOT NULL,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `danhao` (`danhao`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojugenghuan
-- ----------------------------

-- ----------------------------
-- Table structure for `daojugui`
-- ----------------------------
DROP TABLE IF EXISTS `daojugui`;
CREATE TABLE `daojugui` (
  `xh` int(10) NOT NULL AUTO_INCREMENT,
  `djgbm` int(10) NOT NULL,
  `djgmc` varchar(50) NOT NULL,
  `djglx` char(20) NOT NULL,
  `cjbm` int(10) DEFAULT NULL,
  `djglxid` int(10) DEFAULT NULL,
  `bz` tinytext,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `daojugui_ix1` (`djgbm`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojugui
-- ----------------------------
INSERT INTO `daojugui` VALUES ('1', '1001', 'kardex 1号柜', 'Kardex柜', null, null, null);
INSERT INTO `daojugui` VALUES ('2', '1002', 'kardex 2号柜', 'Kardex柜', null, null, null);
INSERT INTO `daojugui` VALUES ('3', '1003', '箱式 1号柜', '立式柜', null, null, null);
INSERT INTO `daojugui` VALUES ('4', '1004', '箱式 2号柜', '立式柜', null, null, null);
INSERT INTO `daojugui` VALUES ('5', '1005', 'kardex 3号柜', 'Kardex柜', null, null, null);
INSERT INTO `daojugui` VALUES ('6', '1006', '刃磨报废暂存柜', '立式柜', null, null, null);

-- ----------------------------
-- Table structure for `daojuguicengshu`
-- ----------------------------
DROP TABLE IF EXISTS `daojuguicengshu`;
CREATE TABLE `daojuguicengshu` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `djgmc` char(20) CHARACTER SET utf8 NOT NULL,
  `djgcs` char(20) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=40 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of daojuguicengshu
-- ----------------------------
INSERT INTO `daojuguicengshu` VALUES ('1', 'kardex 1号柜', '1层');
INSERT INTO `daojuguicengshu` VALUES ('2', 'kardex 1号柜', '2层');
INSERT INTO `daojuguicengshu` VALUES ('3', 'kardex 1号柜', '3层');
INSERT INTO `daojuguicengshu` VALUES ('4', 'kardex 1号柜', '4层');
INSERT INTO `daojuguicengshu` VALUES ('5', 'kardex 1号柜', '5层');
INSERT INTO `daojuguicengshu` VALUES ('6', 'kardex 1号柜', '6层');
INSERT INTO `daojuguicengshu` VALUES ('7', 'kardex 1号柜', '7层');
INSERT INTO `daojuguicengshu` VALUES ('8', 'kardex 1号柜', '8层');
INSERT INTO `daojuguicengshu` VALUES ('9', 'kardex 1号柜', '9层');
INSERT INTO `daojuguicengshu` VALUES ('10', 'kardex 1号柜', '10层');
INSERT INTO `daojuguicengshu` VALUES ('11', 'kardex 1号柜', '11层');
INSERT INTO `daojuguicengshu` VALUES ('12', 'kardex 1号柜', '12层');
INSERT INTO `daojuguicengshu` VALUES ('13', 'kardex 2号柜', '1层');
INSERT INTO `daojuguicengshu` VALUES ('14', 'kardex 2号柜', '2层');
INSERT INTO `daojuguicengshu` VALUES ('15', 'kardex 2号柜', '3层');
INSERT INTO `daojuguicengshu` VALUES ('16', 'kardex 2号柜', '4层');
INSERT INTO `daojuguicengshu` VALUES ('17', 'kardex 2号柜', '5层');
INSERT INTO `daojuguicengshu` VALUES ('18', 'kardex 2号柜', '6层');
INSERT INTO `daojuguicengshu` VALUES ('19', 'kardex 2号柜', '7层');
INSERT INTO `daojuguicengshu` VALUES ('20', 'kardex 2号柜', '8层');
INSERT INTO `daojuguicengshu` VALUES ('21', 'kardex 2号柜', '9层');
INSERT INTO `daojuguicengshu` VALUES ('22', 'kardex 2号柜', '10层');
INSERT INTO `daojuguicengshu` VALUES ('23', '箱式 1号柜', '1层');
INSERT INTO `daojuguicengshu` VALUES ('24', '箱式 1号柜', '2层');
INSERT INTO `daojuguicengshu` VALUES ('25', '箱式 1号柜', '3层');
INSERT INTO `daojuguicengshu` VALUES ('26', '箱式 1号柜', '4层');
INSERT INTO `daojuguicengshu` VALUES ('27', '箱式 1号柜', '5层');
INSERT INTO `daojuguicengshu` VALUES ('28', '箱式 2号柜', '1层');
INSERT INTO `daojuguicengshu` VALUES ('29', '箱式 2号柜', '2层');
INSERT INTO `daojuguicengshu` VALUES ('30', '箱式 2号柜', '3层');
INSERT INTO `daojuguicengshu` VALUES ('31', '箱式 2号柜', '4层');
INSERT INTO `daojuguicengshu` VALUES ('32', '箱式 2号柜', '5层');
INSERT INTO `daojuguicengshu` VALUES ('33', '箱式 2号柜', '6层');
INSERT INTO `daojuguicengshu` VALUES ('34', '箱式 2号柜', '7层');
INSERT INTO `daojuguicengshu` VALUES ('35', 'kardex 3号柜', '1层');
INSERT INTO `daojuguicengshu` VALUES ('36', 'kardex 3号柜', '2层');
INSERT INTO `daojuguicengshu` VALUES ('37', 'kardex 3号柜', '3层');
INSERT INTO `daojuguicengshu` VALUES ('38', 'kardex 3号柜', '4层');
INSERT INTO `daojuguicengshu` VALUES ('39', 'kardex 3号柜', '5层');

-- ----------------------------
-- Table structure for `daojulingbujian`
-- ----------------------------
DROP TABLE IF EXISTS `daojulingbujian`;
CREATE TABLE `daojulingbujian` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `daojuleixing` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '刀具类型',
  `djxh` varchar(50) CHARACTER SET utf8 NOT NULL COMMENT '刀具型号',
  `lbjmc` varchar(50) CHARACTER SET utf8 NOT NULL COMMENT '零部件名称',
  `lbjxh` varchar(50) CHARACTER SET utf8 NOT NULL COMMENT '零部件型号',
  `lbjgg` varchar(50) CHARACTER SET utf8 NOT NULL COMMENT '零部件规格',
  `sl` int(10) NOT NULL COMMENT '数量',
  `dw` varchar(10) CHARACTER SET utf8 DEFAULT NULL COMMENT '单位',
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=669 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of daojulingbujian
-- ----------------------------
INSERT INTO `daojulingbujian` VALUES ('263', null, 'M10×1 丝锥(T1003)', '主刀柄', 'C4-390.410-100 090A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('264', null, 'M10×1 丝锥(T1003)', '接杆', 'C4-391.01-40 080A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('265', null, 'M10×1 丝锥(T1003)', '弹簧夹头', 'C4-391.14-20 052', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('266', null, 'M10×1 丝锥(T1003)', '夹心', 'ER20-GB Φ7.0-Φ5.5', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('267', null, 'M10×1 丝锥(T1003)', '丝锥', 'E447M10', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('268', null, 'M10×1 丝锥(T1003)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('269', null, 'M8 丝锥(T1005)', '主刀柄', 'C6-390.410-100 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('270', null, 'M8 丝锥(T1005)', '接杆', 'C6-391.01-63 140A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('271', null, 'M8 丝锥(T1005)', '弹簧夹头', 'C6-391.14-40 130', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('272', null, 'M8 丝锥(T1005)', '夹心', 'ER40-GB', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('273', null, 'M8 丝锥(T1005)', '丝锥', 'E446M8', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('274', null, 'M8 丝锥(T1005)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('275', null, 'Φ30精镗(T1049)', '主刀柄', 'C3-390.410-100 080A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('276', null, 'Φ30精镗(T1049)', '精镗单元', 'C3-R825A-AAB072A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('277', null, 'Φ30精镗(T1049)', '刀夹', 'R825A-AF11STUC06T1A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('278', null, 'Φ30精镗(T1049)', '刀片', 'TCMT06 T1 04-KF     3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('279', null, 'Φ30精镗(T1049)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('280', null, 'Φ110/Φ130精镗(T1050)', '主刀柄', '345-11-9093S-53619(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('281', null, 'Φ110/Φ130精镗(T1050)', '镗刀杆', '890450232R58429(看不到）', 'L585', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('282', null, 'Φ110/Φ130精镗(T1050)', '刀片', 'TCMT 11 03 04-KF    3005', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('283', null, 'Φ110/Φ130精镗(T1050)', '镗刀头', '无型号', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('284', null, 'Φ110/Φ130精镗(T1050)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('285', null, 'Φ120精镗(T1051)', '主刀柄', '345-11-9093S-53619', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('286', null, 'Φ120精镗(T1051)', '镗刀杆', '890450232R58430', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('287', null, 'Φ120精镗(T1051)', '刀片', 'TCMT 11 03 04-KF    3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('288', null, 'Φ120精镗(T1051)', '镗刀头', '无型号', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('289', null, 'Φ120精镗(T1051)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('290', null, 'Φ37.5粗镗(T1052)', '主刀柄', 'C3-390.410-100 080A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('291', null, 'Φ37.5粗镗(T1052)', '镗刀接柄', 'C3-391.68A-2-026084B', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('292', null, 'Φ37.5粗镗(T1052)', '滑块', '391.68A-2-03813C06B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('293', null, 'Φ37.5粗镗(T1052)', '刀片', 'CCMT 06 02 04-KM     3005', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('294', null, 'Φ37.5粗镗(T1052)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('295', null, 'Φ38精镗(T1053)', '主刀柄', 'C4-390.410-100 090A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('296', null, 'Φ38精镗(T1053)', '精镗单元', 'C4-R825A-AAB084A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('297', null, 'Φ38精镗(T1053)', '刀夹', 'R825A-AF11STUC06T1A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('298', null, 'Φ38精镗(T1053)', '刀片', 'TCMT06 T1 04-KF     3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('299', null, 'Φ38精镗(T1053)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('300', null, 'Φ50铣刀(T1054)', '主刀柄', 'C5-390.410-100 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('301', null, 'Φ50铣刀(T1054)', '铣刀盘', 'M10×1.5', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('302', null, 'Φ50铣刀(T1054)', '刀片', 'R390-11 T3 08M-KM    1020', '', '12', '个');
INSERT INTO `daojulingbujian` VALUES ('303', null, 'Φ50铣刀(T1054)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('304', null, 'Φ100玉米铣(T1055)', '主刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('305', null, 'Φ100玉米铣(T1055)', '刀盘', 'R390-100C8-71M', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('306', null, 'Φ100玉米铣(T1055)', '刀片', 'R390-180608M-KM', '', '20', '个');
INSERT INTO `daojulingbujian` VALUES ('307', null, 'Φ100玉米铣(T1055)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('308', null, 'Φ130精镗(T1057)', '主刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('309', null, 'Φ130精镗(T1057)', '精镗单元', 'C8-R825C-AAH077A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('310', null, 'Φ130精镗(T1057)', '刀片', 'TCMT110304-KF', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('311', null, 'Φ130精镗(T1057)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('312', null, 'Φ120精镗(T1056)', '主刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('313', null, 'Φ120精镗(T1056)', '精镗单元', 'C8-R825C-AAH077A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('314', null, 'Φ120精镗(T1056)', '刀片', 'TCMT110304-KF', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('315', null, 'Φ120精镗(T1056)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('316', null, 'M10×1.5丝锥(T1113)', '主刀柄', 'A10.022.32', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('317', null, 'M10×1.5丝锥(T1113)', '夹心', '393.14-32 100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('318', null, 'M10×1.5丝锥(T1113)', '丝锥', 'E615M10', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('319', null, 'M10×1.5丝锥(T1113)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('320', null, 'Φ100铣刀(T1002)', '主刀柄', 'S945-563916(890800100N60566)', 'L=200', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('321', null, 'Φ100铣刀(T1002)', '刀盘', 'R590-100Q32A-11M', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('322', null, 'Φ100铣刀(T1002)', '刀片', 'R590-1105H-ZC2-KL  CB50', '', '6', '个');
INSERT INTO `daojulingbujian` VALUES ('323', null, 'Φ100铣刀(T1002)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('324', null, 'M16×1.5丝锥（T1005)', '主刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('325', null, 'M16×1.5丝锥（T1005)', '接杆1', 'C8-391.01-80 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('326', null, 'M16×1.5丝锥（T1005)', '接杆2', 'C8-391.01-80 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('327', null, 'M16×1.5丝锥（T1005)', '接杆3', 'C8-391.14-32 070', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('328', null, 'M16×1.5丝锥（T1005)', '夹心', '393.14-40D120×090', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('329', null, 'M16×1.5丝锥（T1005)', '丝锥', 'ES13KM16×1.5', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('330', null, 'M16×1.5丝锥（T1005)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('331', null, 'Φ15镗刀（T1008)', '主刀柄', 'C6-390.410-100 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('332', null, 'Φ15镗刀（T1008)', '接杆1', 'C6-391.37A-16 075A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('333', null, 'Φ15镗刀（T1008)', '镗刀杆(非标）', '无号(看不见）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('334', null, 'Φ15镗刀（T1008)', '刀片', 'TCMT 06 T1 04-KF  3215', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('335', null, 'Φ15镗刀（T1008)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('336', null, 'Φ12硬钻（T1009)', '刀柄', '392.41014-100 32 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('337', null, 'Φ12硬钻（T1009)', '夹心', '393.15-40 12', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('338', null, 'Φ12硬钻（T1009)', '硬钻', 'R840-1200-70-A1A  1220', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('339', null, 'Φ12硬钻（T1009)', ' 水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('340', null, 'Φ10.8硬钻（T1010)', '主刀柄', 'C6-390.410-100 110A', 'L=180', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('341', null, 'Φ10.8硬钻（T1010)', '刀杆', 'C6-391.14-40 130', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('342', null, 'Φ10.8硬钻（T1010)', '夹心', '393.15-40 12', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('343', null, 'Φ10.8硬钻（T1010)', '硬钻', 'R840-1080-50-A1A  1220', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('344', null, 'Φ10.8硬钻（T1010)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('345', null, 'M12×1.25丝锥（T1011)', '主刀柄', 'C6-390.410-100 110A', 'L=180', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('346', null, 'M12×1.25丝锥（T1011)', '刀杆', 'C6-391.14-40 130', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('347', null, 'M12×1.25丝锥（T1011)', '夹心', 'ER40GB Φ9.0', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('348', null, 'M12×1.25丝锥（T1011)', '丝锥', 'EP11M12×1.25', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('349', null, 'M12×1.25丝锥（T1011)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('350', null, 'Φ12 镗刀(T1013)', '主刀柄', 'C6-390.410-100 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('351', null, 'Φ12 镗刀(T1013)', '接杆1', 'C6-391.02-50 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('352', null, 'Φ12 镗刀(T1013)', '接杆2', 'C5-391.37A-12 048B', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('353', null, 'Φ12 镗刀(T1013)', '刀杆', 'R492.90-11-033-06-AC(看不见）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('354', null, 'Φ12 镗刀(T1013)', '刀片', 'TCMT 06 T1 04-KF  3215', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('355', null, 'Φ12 镗刀(T1013)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('356', null, 'M10×1.25丝锥(T1016)', '主刀柄', 'C6-390.410-100 110A', 'L=180', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('357', null, 'M10×1.25丝锥(T1016)', '接杆1', 'C6-391.14-32 130', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('358', null, 'M10×1.25丝锥(T1016)', '夹心', 'ER32GBΦ7.0', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('359', null, 'M10×1.25丝锥(T1016)', '丝锥', 'ES13KM10×1.25', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('360', null, 'M10×1.25丝锥(T1016)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('361', null, 'Φ25铣刀(T1017)', '主刀柄', '930-HA10-HD-25-106', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('362', null, 'Φ25铣刀(T1017)', '铣刀盘', '看不见', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('363', null, 'Φ25铣刀(T1017)', '刀片', 'R390-17 04 08M-KM   1020', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('364', null, 'Φ25铣刀(T1017)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('365', null, 'M22×1.5丝锥(T1019)', '主刀柄', 'C6-390.410-100 110A', 'L=180', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('366', null, 'M22×1.5丝锥(T1019)', '接杆1', 'C6-391.14-40 130', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('367', null, 'M22×1.5丝锥(T1019)', '夹心', '393.14-40D180×145', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('368', null, 'M22×1.5丝锥(T1019)', '丝锥', 'EP11KM22×1.5', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('369', null, 'M22×1.5丝锥(T1019)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('370', null, 'Φ42 镗刀(T1021)', '主刀柄', 'C4-390.410-100 40 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('371', null, 'Φ42 镗刀(T1021)', '接杆', 'C4-R825B-AAC066A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('372', null, 'Φ42 镗刀(T1021)', '镗刀夹', 'R-AF17STUC0902', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('373', null, 'Φ42 镗刀(T1021)', '刀片', 'TCMT 09 02 04-KF    3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('374', null, 'Φ42 镗刀(T1021)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('375', null, 'Φ20 镗刀(T1023)', '主刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('376', null, 'Φ20 镗刀(T1023)', '接杆1', 'C8-391.02-63 080A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('377', null, 'Φ20 镗刀(T1023)', '接杆2', 'C6-391.37A-16 075A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('378', null, 'Φ20 镗刀(T1023)', '刀杆', 'R429U-A16-17056 TC09A（看不见）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('379', null, 'Φ20 镗刀(T1023)', '刀片', 'TCMT 09 02 04-KF    3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('380', null, 'Φ20 镗刀(T1023)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('381', null, 'Φ100铣刀(T1028)', '主刀柄', '345-11-9003-206344', 'L=275', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('382', null, 'Φ100铣刀(T1028)', '接杆', 'C8-391.05CD-32 320', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('383', null, 'Φ100铣刀(T1028)', '铣刀盘', 'R390-100Q32-17M', 'Φ100,z=7', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('384', null, 'Φ100铣刀(T1028)', '刀片 ', 'R390-17 04 08M-KM  1020', '', '7', '个');
INSERT INTO `daojulingbujian` VALUES ('385', null, 'Φ100铣刀(T1028)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('386', null, 'Φ6.8阶梯钻(T1041)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('387', null, 'Φ6.8阶梯钻(T1041)', '刀柄', '392.41014-100 32 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('388', null, 'Φ6.8阶梯钻(T1041)', '夹心', 'ER40-DCB 10.0-9.5', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('389', null, 'Φ6.8阶梯钻(T1041)', '非标钻头', 'ST0766 Φ6.8×20×120°×Φ10×103', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('390', null, 'M8丝锥(T1042)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('391', null, 'M8丝锥(T1042)', '刀柄', '392.41014-100 32 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('392', null, 'M8丝锥(T1042)', '钢性夹心', '05.027.964', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('393', null, 'M8丝锥(T1042)', '丝锥', 'E446M8', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('394', null, 'Φ20阶梯钻(T1043)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('395', null, 'Φ20阶梯钻(T1043)', '主柄', 'C6-390.410-100 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('396', null, 'Φ20阶梯钻(T1043)', '接杆', 'C6-391.14-40 130', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('397', null, 'Φ20阶梯钻(T1043)', '夹心 ', '393.15-32 20', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('398', null, 'Φ20阶梯钻(T1043)', '非标钻头', 'ST0759 Φ20×78×Φ20×131', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('399', null, 'Φ9阶梯钻(T1044)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('400', null, 'Φ9阶梯钻(T1044)', '刀柄', '392.41014-100 32 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('401', null, 'Φ9阶梯钻(T1044)', '夹心', '393.15-32 12', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('402', null, 'Φ9阶梯钻(T1044)', '非标钻头', 'ST0767 Φ9×20×120°×Φ12×103', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('403', null, 'M10×1丝锥(T1045)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('404', null, 'M10×1丝锥(T1045)', '刀柄', '392.41014-100 32 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('405', null, 'M10×1丝锥(T1045)', '钢性夹心', 'ER32-GB  Φ7.0-5.5', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('406', null, 'M10×1丝锥(T1045)', '丝锥', 'ES13KM10×1.0', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('407', null, 'Φ5阶梯钻(T1046)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('408', null, 'Φ5阶梯钻(T1046)', '刀柄', '392.41014-100 32 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('409', null, 'Φ5阶梯钻(T1046)', '夹心', '393.15-32 10', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('410', null, 'Φ5阶梯钻(T1046)', '复合钻头', 'ST0768 Φ5×20×120°×Φ10×122', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('411', null, 'M6丝锥(T1047)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('412', null, 'M6丝锥(T1047)', '刀柄', '392.41014-100 32 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('413', null, 'M6丝锥(T1047)', '钢性夹心', '05.027.862(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('414', null, 'M6丝锥(T1047)', '丝锥', 'E616M6', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('415', null, 'Φ16.5阶梯钻(T1048)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('416', null, 'Φ16.5阶梯钻(T1048)', '钢性夹头', 'G25 25000A10.022.40', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('417', null, 'Φ16.5阶梯钻(T1048)', '夹心', '393.15-40 20', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('418', null, 'Φ16.5阶梯钻(T1048)', '复合钻头', 'ST0762 Φ16.5×42×120°×Φ20×153', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('419', null, 'M18×1.5丝锥(T1049)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('420', null, 'M18×1.5丝锥(T1049)', '钢性夹头', 'G25 2500 0A10.022.40', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('421', null, 'M18×1.5丝锥(T1049)', '钢性夹心', '393.14-40 D140×112', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('422', null, 'M18×1.5丝锥(T1049)', '丝锥', 'LS-SP M18×1.5', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('423', null, 'Φ11.8阶梯钻(T1050)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('424', null, 'Φ11.8阶梯钻(T1050)', '刀柄', '392.41014-100 40 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('425', null, 'Φ11.8阶梯钻(T1050)', '夹心', '393.15-40 14', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('426', null, 'Φ11.8阶梯钻(T1050)', '复合钻头', 'ST0769 Φ11.8×14×120°×Φ14×120', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('427', null, 'Φ12F9-铰刀 (T1051)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('428', null, 'Φ12F9-铰刀 (T1051)', '刀柄', '392.41014-100 40 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('429', null, 'Φ12F9-铰刀 (T1051)', '夹心', '393.15-40 12', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('430', null, 'Φ12F9-铰刀 (T1051)', '铰刀', 'TM435.B-XF-435-XF.12', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('431', null, 'Φ12立铣刀 (T1052)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('432', null, 'Φ12立铣刀 (T1052)', '刀柄', '392.41014-100 40 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('433', null, 'Φ12立铣刀 (T1052)', '夹心', '393.15-40 12', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('434', null, 'Φ12立铣刀 (T1052)', '立铣刀', '2P340-1200-PA       1630', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('435', null, 'Φ15镗刀(T1054)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('436', null, 'Φ15镗刀(T1054)', '主刀柄', 'C5-390.410-100 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('437', null, 'Φ15镗刀(T1054)', '接柄', 'C5-391.37A-12 048B', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('438', null, 'Φ15镗刀(T1054)', '镗刀杆', 'R429.90-14-040-09（看不见）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('439', null, 'Φ15镗刀(T1054)', '刀片', 'TPMT090204-KF', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('440', null, 'Φ44玉米铣(T1055)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('441', null, 'Φ44玉米铣(T1055)', '主刀柄', 'C4-390.410-100 090A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('442', null, 'Φ44玉米铣(T1055)', '刀盘', 'R390-044C4-45M', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('443', null, 'Φ44玉米铣(T1055)', '刀片', 'R390-11T308M-KM', '', '15', '个');
INSERT INTO `daojulingbujian` VALUES ('444', null, 'Φ16立铣刀(T1056)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('445', null, 'Φ16立铣刀(T1056)', '主刀柄', 'G25 25000 A10.022.32', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('446', null, 'Φ16立铣刀(T1056)', '夹心', 'ER32-16', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('447', null, 'Φ16立铣刀(T1056)', '立铣刀', '2P340-1600-PA', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('448', null, 'Φ25U钻(T1057)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('449', null, 'Φ25U钻(T1057)', '主刀柄', 'C5-390.410-100 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('450', null, 'Φ25U钻(T1057)', '接杆', 'C5-391.01-50 100A', '', '3', '个');
INSERT INTO `daojulingbujian` VALUES ('451', null, 'Φ25U钻(T1057)', '侧压夹头', 'C5-391.27-25 071', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('452', null, 'Φ25U钻(T1057)', 'U钻', '880-D2500L25-05', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('453', null, 'Φ25U钻(T1057)', '中心刀片', '880-050305H-C-GM', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('454', null, 'Φ25U钻(T1057)', '周边刀片', '880-0503W05H-P-GM', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('455', null, 'Φ80铣刀(T1058)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('456', null, 'Φ80铣刀(T1058)', '主刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('457', null, 'Φ80铣刀(T1058)', '接杆', 'C8-391.06-27 320', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('458', null, 'Φ80铣刀(T1058)', '铣刀盘', 'R390-080Q27-17M', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('459', null, 'Φ80铣刀(T1058)', '刀片', 'R390-170408M-KM 3040', '', '6', '个');
INSERT INTO `daojulingbujian` VALUES ('460', null, 'Φ17阶梯钻(T1063)', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('461', null, 'Φ17阶梯钻(T1063)', '主刀柄', 'C6-390.410-100 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('462', null, 'Φ17阶梯钻(T1063)', '侧压夹头', 'C6-391.27-25 070A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('463', null, 'Φ17阶梯钻(T1063)', '刀杆', 'TM870.2.1-553751（看不见）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('464', null, 'Φ17阶梯钻(T1063)', '刀片', '870-1700-17-KM 3234', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('465', null, 'Φ20.5U钻(T1100)', '水嘴', '5692-022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('466', null, 'Φ20.5U钻(T1100)', '主刀柄', 'C6-390.410-100 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('467', null, 'Φ20.5U钻(T1100)', '接杆', 'C6-391.01-63 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('468', null, 'Φ20.5U钻(T1100)', '阶梯接杆', 'C6-391.27-32 075', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('469', null, 'Φ20.5U钻(T1100)', 'U钻刀杆', '880-D2050L25-05', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('470', null, 'Φ20.5U钻(T1100)', '中心刀片', '880-030305H-C-GM', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('471', null, 'Φ20.5U钻(T1100)', '周边刀片', '880-0303W05H-P-GM', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('472', null, 'M22*1.5丝锥(T1101)', '水嘴', '5692-022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('473', null, 'M22*1.5丝锥(T1101)', '主刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('474', null, 'M22*1.5丝锥(T1101)', '阶梯接杆', 'C8-391.02-63 080A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('475', null, 'M22*1.5丝锥(T1101)', '接杆', 'C6-391.02-50 110A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('476', null, 'M22*1.5丝锥(T1101)', '刚性夹头', 'C5-391.14-40 060', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('477', null, 'M22*1.5丝锥(T1101)', '夹心', '393.14-40D180X145', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('478', null, 'M22*1.5丝锥(T1101)', '丝锥', 'EP11M22X1.5', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('479', null, 'φ37U钻（T1102）', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('480', null, 'φ37U钻（T1102）', '主刀柄', '392.41020-100 40 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('481', null, 'φ37U钻（T1102）', 'U钻刀杆', '880-D3700L40-05', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('482', null, 'φ37U钻（T1102）', '中心刀片', '880-070406H-C-GM', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('483', null, 'φ37U钻（T1102）', '周边刀片', '880-0704W06H-P-GM', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('484', null, 'M39螺纹铣刀（T1103）', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('485', null, 'M39螺纹铣刀（T1103）', '主刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('486', null, 'M39螺纹铣刀（T1103）', '阶梯接杆', 'C8-391.02-50 080A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('487', null, 'M39螺纹铣刀（T1103）', '侧压夹头', 'C5-391.27-25 071', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('488', null, 'M39螺纹铣刀（T1103）', '刀杆', 'SR0021H21', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('489', null, 'M39螺纹铣刀（T1103）', '螺纹刀片', '21I2.0ISO MT7', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('490', null, 'φ32玉米铣T1104', '水嘴', '5692 022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('491', null, 'φ32玉米铣T1104', '主刀柄', 'C5-390.410-100 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('492', null, 'φ32玉米铣T1104', '接杆', 'C5-391.01-50 080A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('493', null, 'φ32玉米铣T1104', '铣刀盘', 'R390-032C5-36L', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('494', null, 'φ32玉米铣T1104', '刀片', 'R390-11T308M-KM', '', '8', '个');
INSERT INTO `daojulingbujian` VALUES ('495', null, 'D80 铣刀(T185)', '方肩铣刀7刃', 'R220.96-0080-08-7A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('496', null, 'D80 铣刀(T185)', '刀片', 'XNEX080608TR-MD15.MK2050', '', '7', '个');
INSERT INTO `daojulingbujian` VALUES ('497', null, 'D80 铣刀(T185)', 'HSKA100铣刀刀柄', 'E9306552527160', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('498', null, 'D80 铣刀(T185)', 'HSKA100冷却液管', '20E9306', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('499', null, 'D63 铣刀(T101)', '方肩铣刀6刃', 'R220.96-0063-08-6A-27', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('500', null, 'D63 铣刀(T101)', '刀片', 'XNEX080608TR-MD15.MK2050', '', '6', '个');
INSERT INTO `daojulingbujian` VALUES ('501', null, 'D63 铣刀(T101)', 'HSKA100铣刀刀柄', 'E9306552527100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('502', null, 'D63 铣刀(T101)', 'HSKA100冷却液管', '20E9306', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('503', null, 'Φ30 铣刀(T102)', '非标立铣刀', 'D30*D32*126', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('504', null, 'Φ30 铣刀(T102)', '热胀刀柄', '4736 32.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('505', null, 'Φ30 铣刀(T102)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('506', null, 'Φ63 粗镗刀(T103)', 'HSK Capto刀柄', 'C5-390.410-100100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('507', null, 'Φ63 粗镗刀(T103)', '接柄', 'C5-391.68A-5-050 044B', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('508', null, 'Φ63 粗镗刀(T103)', '车刀片', 'TCMT16T308-KM3215', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('509', null, 'Φ63 粗镗刀(T103)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('510', null, 'Φ63 粗镗刀(T103)', '滑块', '391.68A-5-070 26T16B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('511', null, 'Φ67.7半精镗(T104)', 'HSKCapto刀柄', 'C5-390.410-100100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('512', null, 'Φ67.7半精镗(T104)', '接柄', 'C5-391.68A-5-050 044B', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('513', null, 'Φ67.7半精镗(T104)', '车刀片', 'TCMT16T308-KM3215', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('514', null, 'Φ67.7半精镗(T104)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('515', null, 'Φ67.7半精镗(T104)', '滑块', '391.68A-5-070 26T16B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('516', null, 'Φ32.5-48.2倒角铣(T105)', '英制倒角立铣刀', 'RA215.64-32M32-4512', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('517', null, 'Φ32.5-48.2倒角铣(T105)', 'KSK 英制侧固刀柄', 'A932.41020-100 31 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('518', null, 'Φ32.5-48.2倒角铣(T105)', 'Waveline铣刀片', 'SPMT120408-WH4030', '', '3', '个');
INSERT INTO `daojulingbujian` VALUES ('519', null, 'Φ32.5-48.2倒角铣(T105)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('520', null, 'Φ101 粗镗(T106)', '接柄', 'C6-391.68A-7-096 060', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('521', null, 'Φ101 粗镗(T106)', 'HSK Capto刀柄', 'C6-390.410-1001 10A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('522', null, 'Φ101 粗镗(T106)', '车刀片', 'TCMT16T308-KM3215', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('523', null, 'Φ101 粗镗(T106)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('524', null, 'Φ101 粗镗(T106)', '滑块', '391.68A-7-125 40T16B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('525', null, 'Φ106 粗镗(T107)', '接柄', 'C6-391.68A-7-096 060', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('526', null, 'Φ106 粗镗(T107)', 'HSK Capto刀柄', 'C6-390.410-1001 10A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('527', null, 'Φ106 粗镗(T107)', '车刀片', 'TCMT16T308-KM3215', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('528', null, 'Φ106 粗镗(T107)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('529', null, 'Φ106 粗镗(T107)', '滑块', '391.68A-7-125 40T16B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('530', null, 'Φ80 粗镗(T108)', '接柄', 'C6-391.68A-6-063 045C', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('531', null, 'Φ80 粗镗(T108)', 'HSK Capto刀柄', 'C6-390.410-1001 10HD', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('532', null, 'Φ80 粗镗(T108)', '车刀片', 'TCMT16T308-KM3215', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('533', null, 'Φ80 粗镗(T108)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('534', null, 'Φ80 粗镗(T108)', '滑块', '391.68A-7-125 40T16B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('535', null, 'φ84.7半精镗(T109)', '接柄', 'C6-391.68A-6-063 045C', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('536', null, 'φ84.7半精镗(T109)', 'HSK Capto刀柄', 'C6-390.410-1001 10A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('537', null, 'φ84.7半精镗(T109)', '车刀片', 'TCMT16T308-KM3215', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('538', null, 'φ84.7半精镗(T109)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('539', null, 'φ84.7半精镗(T109)', '滑块', '391.68A-7-125 40T16B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('540', null, 'Φ42 倒角铣(T110)', 'HSK Capto刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('541', null, 'Φ42 倒角铣(T110)', '英制倒角立铣刀', 'RA215.64-36M32-6012', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('542', null, 'Φ42 倒角铣(T110)', 'Capto英制组合接柄', 'C8-A391.23-31 080', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('543', null, 'Φ42 倒角铣(T110)', 'Waveline铣刀片', 'SPMT120408-WH4030', '', '3', '个');
INSERT INTO `daojulingbujian` VALUES ('544', null, 'Φ42 倒角铣(T110)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('545', null, 'Φ26 钻(T111)', '刀杆', '4108 26.000(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('546', null, 'Φ26 钻(T111)', '刀片', '4113 26.0', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('547', null, 'Φ26 钻(T111)', '侧固刀柄', 'GM3004334 32.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('548', null, 'Φ26 钻(T111)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('549', null, 'Φ29.7 粗镗(T112)', '刀体', '4H0987239', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('550', null, 'Φ29.7 粗镗(T112)', 'HSK钻头接柄', '392.41027-100 32 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('551', null, 'Φ29.7 粗镗(T112)', 'Tum107菱形80°', 'CCMT09T308-KM3210', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('552', null, 'Φ29.7 粗镗(T112)', '冷却液套管', '56692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('553', null, 'Φ21-Φ35倒角(T113)', 'Check Product Codel', 'S912-552083', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('554', null, 'Φ21-Φ35倒角(T113)', 'Tum107菱形80°', 'CCMT09T308-KM3210', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('555', null, 'Φ21-Φ35倒角(T113)', ' HSK钻头接柄', '392.41027-100 32 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('556', null, 'Φ21-Φ35倒角(T113)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('557', null, 'φ13 硬钻(T131)', '整体硬钻', '5510 13.0(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('558', null, 'φ13 硬钻(T131)', '热胀刀柄', '4736 14.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('559', null, 'φ13 硬钻(T131)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('560', null, 'Φ17.7锪孔钻(T115)', '非标HM扩孔钻', 'D17.7*D22*D20*105(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('561', null, 'Φ17.7锪孔钻(T115)', '热胀刀柄', '4736 20.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('562', null, 'Φ17.7锪孔钻(T115)', '冷却导管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('563', null, 'φ6.8 硬钻(T116)', '整体硬钻', '5510 6.800(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('564', null, 'φ6.8 硬钻(T116)', '热胀刀柄', 'GM3004736 108.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('565', null, 'φ6.8 硬钻(T116)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('566', null, 'φ16 中心钻(T117)', '中心钻', '723 16.0(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('567', null, 'φ16 中心钻(T117)', '热胀刀柄', 'GM3004736 116.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('568', null, 'φ16 中心钻(T117)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('569', null, 'M8*1.25丝锥(T118)', '丝锥', '931 8.000(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('570', null, 'M8*1.25丝锥(T118)', '弹簧夹头刀柄', 'FA:14103955', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('571', null, 'M8*1.25丝锥(T118)', '螺母', '4306 IC16，100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('572', null, 'M8*1.25丝锥(T118)', '弹簧夹套', '4308 16.016(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('573', null, 'M8*1.25丝锥(T118)', '密封环', '4335 6.016(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('574', null, 'M8*1.25丝锥(T118)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('575', null, 'φ19.7硬钻(T119)', '整体合金钻', '2477 19.7(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('576', null, 'φ19.7硬钻(T119)', '热胀刀柄', '4736 120.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('577', null, 'φ19.7硬钻(T119)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('578', null, 'φ12 倒角钻(T71)', '合金倒角钻', '6711 12.000(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('579', null, 'φ12 倒角钻(T71)', '延长杆', '4719 12.125', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('580', null, 'φ12 倒角钻(T71)', '热胀刀柄', 'GM3004736 25.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('581', null, 'φ12 倒角钻(T71)', '冷却导管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('582', null, 'Φ63 铣槽刀(T78)', '槽铣刀（5齿）', 'R335.15-063-03.22-5', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('583', null, 'Φ63 铣槽刀(T78)', '刀片', 'R335.15-13265FG-M10,F40M', '', '5', '个');
INSERT INTO `daojulingbujian` VALUES ('584', null, 'Φ63 铣槽刀(T78)', 'HSKA100铣刀刀柄', 'E9306Y552522160', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('585', null, 'Φ63 铣槽刀(T78)', 'HSKA100冷却液管', '20E9306', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('586', null, 'Φ115 粗镗(T22)', '接柄', 'C8-391.68A-7-080 060D', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('587', null, 'Φ115 粗镗(T22)', 'HSK Capto刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('588', null, 'Φ115 粗镗(T22)', '车刀片', 'TCMT16T308-KM3215', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('589', null, 'Φ115 粗镗(T22)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('590', null, 'Φ115 粗镗(T22)', '滑块', '391.68A-7-125 40T16B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('591', null, 'Φ119.7半精镗(T20)', '接柄', 'C8-391.68A-7-080 060D', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('592', null, 'Φ119.7半精镗(T20)', 'HSK Capto刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('593', null, 'Φ119.7半精镗(T20)', '车刀片', 'TCMT16T308-KM3215', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('594', null, 'Φ119.7半精镗(T20)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('595', null, 'Φ119.7半精镗(T20)', '滑块', '391.68A-7-125 40T16B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('596', null, 'Φ18R8铰刀(T79)', '非标硬质合金铰刀', 'D18/100(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('597', null, 'Φ18R8铰刀(T79)', '液压刀柄', '4299 18，100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('598', null, 'Φ18R8铰刀(T79)', '冷却导管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('599', null, 'Φ20H9铰刀(T80)', '非标硬质合金铰刀', 'D20*105(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('600', null, 'Φ20H9铰刀(T80)', '液压刀柄', '4299 20.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('601', null, 'Φ20H9铰刀(T80)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('602', null, 'Φ68精镗(T73)', 'HSK Capto刀柄', 'C6-390.410-1001 10A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('603', null, 'Φ68精镗(T73)', '整体式精镗刀', 'C6-R825C-AAE 097A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('604', null, 'Φ68精镗(T73)', '107车刀片', 'TCMT110304-KF3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('605', null, 'Φ68精镗(T73)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('606', null, 'Φ68精镗(T73)', '鹰嘴', 'C-AF23STVC 1103', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('607', null, 'Φ85精镗(T74)', 'HSK Capto刀柄', 'C6-390.410-1001 10A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('608', null, 'Φ85精镗(T74)', '整体式精镗刀', 'C6-R825C-AAE 055A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('609', null, 'Φ85精镗(T74)', '车刀片', 'TCMT110304-KF3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('610', null, 'Φ85精镗(T74)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('611', null, 'Φ85精镗(T74)', '鹰嘴', 'C-AF23STVC 1103', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('612', null, 'Φ30精镗(T75)', '高精度液压夹头', '930-HA10-HD-25-106', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('613', null, 'Φ30精镗(T75)', '车刀片', 'TCMT06T104-KF3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('614', null, 'Φ30精镗(T75)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('615', null, 'Φ30精镗(T75)', '鹰嘴', 'A-AF11STVC 0671', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('616', null, 'Φ30精镗(T75)', '精镗杆', 'A25-R825A-AB146-RA', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('617', null, 'Φ120反精镗刀(T30)', '精镗头', 'R331103', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('618', null, 'Φ120反精镗刀(T30)', '车刀片', 'TCMT110304-KF3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('619', null, 'Φ120反精镗刀(T30)', 'HSK Capto刀柄', 'C8-390.410-100 120A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('620', null, 'Φ120反精镗刀(T30)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('621', null, 'Φ120反精镗刀(T30)', '接柄', '890 450232R57661', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('622', null, 'Φ20铣刀（立）(T53)', '立铣刀', '4736.120.100(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('623', null, 'Φ20铣刀（立）(T53)', '热胀刀柄', 'HSK100A 20.00', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('624', null, 'Φ20铣刀（立）(T53)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('625', null, 'D63 精铣(T76)', '方肩铣刀（7刃）', 'R220.96-0063-08-7A-27', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('626', null, 'D63 精铣(T76)', '刀片', 'XNEX080608TR-M13.MK1500', '', '7', '个');
INSERT INTO `daojulingbujian` VALUES ('627', null, 'D63 精铣(T76)', 'HSKA100铣刀刀柄', 'E9306Y552527160', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('628', null, 'D63 精铣(T76)', 'HSKA100冷却液管', '20E9306', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('629', null, 'Φ10.4 钻头(T38)', '引导钻', '5510 10.4', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('630', null, 'Φ10.4 钻头(T38)', '热胀刀柄', '4736 112.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('631', null, 'Φ10.4 钻头(T38)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('632', null, 'φ13 硬钻(T77)', '整体硬钻', 'D13*D14*168', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('633', null, 'φ13 硬钻(T77)', '热胀刀柄', 'GM3004736 14.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('634', null, 'φ13 硬钻(T77)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('635', null, 'φ11.7 扩孔钻(T41)', '标准合金扩孔钻', '5510-11.7', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('636', null, 'φ11.7 扩孔钻(T41)', '热胀刀柄', 'GM3004736 12.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('637', null, 'φ11.7 扩孔钻(T41)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('638', null, 'D25 铣刀(T132)', '粗铣刀', '2P340-2500-PB1630(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('639', null, 'D25 铣刀(T132)', '测固刀柄', '391.41020-100 25 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('640', null, 'D25 铣刀(T132)', '冷却导管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('641', null, 'Φ28 铰刀(T58)', '非标焊硬质合金铰', 'D28*D25*130', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('642', null, 'Φ28 铰刀(T58)', '热胀刀柄', 'GM3004736 25.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('643', null, 'Φ28 铰刀(T58)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('644', null, 'Φ6.05 硬钻(T59)', '非标整体硬钻', 'D6.05*D8*65', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('645', null, 'Φ6.05 硬钻(T59)', '热胀刀柄', 'GM3004736 308.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('646', null, 'Φ6.05 硬钻(T59)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('647', null, 'Φ6.05 硬钻(T60)', '非标整体硬钻', 'D6.05*D8*108', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('648', null, 'Φ6.05 硬钻(T60)', '热胀刀柄', 'GM3004736 308.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('649', null, 'Φ6.05 硬钻(T60)', '冷却管', '4949 24.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('650', null, 'Φ67 粗镗 (T61)', 'HSK Capto刀柄', 'C6-390.410-1001 10HD', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('651', null, 'Φ67 粗镗 (T61)', 'Captp缩径接杆', 'C6-391.02-50 080A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('652', null, 'Φ67 粗镗 (T61)', '接柄', 'C5-391.68A-5-050 044B', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('653', null, 'Φ67 粗镗 (T61)', '车刀片', 'TCMT16T308-KM3215', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('654', null, 'Φ67 粗镗 (T61)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('655', null, 'Φ67 粗镗 (T61)', '滑块', '391.68A-5-070 26T16B', '', '2', '个');
INSERT INTO `daojulingbujian` VALUES ('656', null, 'Φ32 铣刀(T64)', '高精度液压夹头', '930-HA10-HD-32-110', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('657', null, 'Φ32 铣刀(T64)', '防震铣刀（4齿）', 'R390D-032A32-11M(看不到）', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('658', null, 'Φ32 铣刀(T64)', '铣刀片', 'R390-11T308M-KL1020', '', '3', '个');
INSERT INTO `daojulingbujian` VALUES ('659', null, 'Φ32 铣刀(T64)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('660', null, 'Φ72 精镗 (T66)', '接柄', 'C6-R825C-AAF 055A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('661', null, 'Φ72 精镗 (T66)', 'CAPto加长接杆', 'C6-391.01-63 100A', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('662', null, 'Φ72 精镗 (T66)', 'HSK Capto刀柄', 'C6-390.410-100110HD', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('663', null, 'Φ72 精镗 (T66)', '车刀片', 'TCMT110304-KF3005', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('664', null, 'Φ72 精镗 (T66)', '冷却液套管', '5692022-06', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('665', null, 'Φ72 精镗 (T66)', '鹰嘴', 'C-AF23 STUC 1103', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('666', null, 'Φ11 硬钻(T88)', '整体硬钻', '5510 11.100看不到', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('667', null, 'Φ11 硬钻(T88)', '热胀刀柄', '4736 12.100', '', '1', '个');
INSERT INTO `daojulingbujian` VALUES ('668', null, 'Φ11 硬钻(T88)', '冷却管', '4949 24.100', '', '1', '个');

-- ----------------------------
-- Table structure for `daojulingyong`
-- ----------------------------
DROP TABLE IF EXISTS `daojulingyong`;
CREATE TABLE `daojulingyong` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `chucangdanhao` char(20) NOT NULL,
  `chucangleixing` varchar(20) DEFAULT NULL,
  `lingyongbanzu` varchar(20) DEFAULT NULL,
  `lingyongshebei` varchar(20) DEFAULT NULL,
  `lingyongren` varchar(20) DEFAULT NULL,
  `jiagonggongyi` char(20) DEFAULT NULL,
  `chucangriqi` date DEFAULT NULL,
  `beizhu` tinytext,
  `caozuoyuan` varchar(20) DEFAULT NULL,
  `danjuzhuangtai` int(2) NOT NULL,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `daojuchucang_ix1` (`chucangdanhao`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojulingyong
-- ----------------------------
INSERT INTO `daojulingyong` VALUES ('23', 'DJCC_171002001', '常规领用', '先锋一班', 'FMS-2#机', '123', '12', '2017-10-02', '', '赵经手', '0');

-- ----------------------------
-- Table structure for `daojulingyongmingxi`
-- ----------------------------
DROP TABLE IF EXISTS `daojulingyongmingxi`;
CREATE TABLE `daojulingyongmingxi` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `chucangdanhao` char(20) NOT NULL,
  `daojuleixing` varchar(50) NOT NULL,
  `daojuguige` char(20) DEFAULT NULL,
  `changdu` char(10) DEFAULT NULL,
  `daojuid` char(20) NOT NULL,
  `shuliang` int(11) NOT NULL,
  `jiliangdanwei` varchar(10) DEFAULT '套',
  `weizhibiaoshi` char(10) DEFAULT 'M',
  `jichuangbianma` char(20) DEFAULT NULL,
  `daotaohao` char(20) DEFAULT NULL,
  `beizhu` tinytext,
  PRIMARY KEY (`xh`)
) ENGINE=InnoDB AUTO_INCREMENT=148 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojulingyongmingxi
-- ----------------------------
INSERT INTO `daojulingyongmingxi` VALUES ('147', 'DJCC_171002001', '钻头', 'Φ10.4', '', 'ZT-0014', '1', '套', 'M', 'FMS-1#机', 'T05', '');

-- ----------------------------
-- Table structure for `daojuliushui`
-- ----------------------------
DROP TABLE IF EXISTS `daojuliushui`;
CREATE TABLE `daojuliushui` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) DEFAULT NULL,
  `dhlx` varchar(10) DEFAULT NULL,
  `djlx` varchar(20) DEFAULT NULL,
  `djgg` char(20) DEFAULT NULL,
  `djid` char(20) DEFAULT NULL,
  `zsl` int(2) DEFAULT NULL,
  `fsl` int(2) DEFAULT NULL,
  `dskysl` int(2) DEFAULT NULL,
  `wzbm` varchar(20) DEFAULT NULL,
  `jtwz` varchar(20) DEFAULT NULL,
  `czsj` datetime DEFAULT NULL,
  `jbr` varchar(10) DEFAULT NULL,
  `bz` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=91 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojuliushui
-- ----------------------------
INSERT INTO `daojuliushui` VALUES ('87', null, '刀具装配', '钻头', 'Φ10.4', 'ZT-0015', '1', '0', '10', 'kardex 1号柜', '1层', '2017-11-20 14:17:23', null, null);
INSERT INTO `daojuliushui` VALUES ('88', null, '刀具装配', '钻头', 'Φ10.4', 'ZT-0016', '1', '0', '11', 'kardex 1号柜', '1层', '2017-11-20 14:43:49', null, null);
INSERT INTO `daojuliushui` VALUES ('89', null, '刀具拆卸', '钻头', 'Φ10.4', 'ZT-0016', '0', '1', '10', null, null, '2017-11-20 14:54:32', null, null);
INSERT INTO `daojuliushui` VALUES ('90', null, '刀具拆卸', '钻头', 'Φ10.4', 'ZT-0015', '0', '1', '9', null, null, '2017-11-20 14:55:47', null, null);

-- ----------------------------
-- Table structure for `daojutemp`
-- ----------------------------
DROP TABLE IF EXISTS `daojutemp`;
CREATE TABLE `daojutemp` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `daojuid` char(20) NOT NULL,
  `daojuxinghao` char(20) NOT NULL,
  `daojuguige` char(20) NOT NULL,
  `daojuleixing` varchar(20) NOT NULL,
  `daojushouming` int(10) NOT NULL,
  `weizhi` char(20) NOT NULL,
  `cengshu` char(20) NOT NULL,
  `weizhibiaoshi` char(4) NOT NULL,
  `type` char(20) NOT NULL,
  `kcsl` int(10) NOT NULL,
  `zuixiaokucun` int(10) DEFAULT NULL,
  `zuidakucun` int(10) DEFAULT NULL,
  `zzdj` char(20) NOT NULL,
  `beizhu` tinytext,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `daojutemp_ix1` (`daojuid`)
) ENGINE=InnoDB AUTO_INCREMENT=226 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojutemp
-- ----------------------------
INSERT INTO `daojutemp` VALUES ('1', 'ZT-0001', 'Φ10.4 钻头(T38)', 'Φ10.4', '钻头', '100', '外借', '工艺部', 'T', '刀具', '1', '1', '1', '', 'T39');
INSERT INTO `daojutemp` VALUES ('2', 'ZT-0002', 'φ20.5 钻头(T52)', 'φ20.5', '钻头', '20', '12584', '1254', 'T', '刀具', '1', '1', '1', '', 'T53');
INSERT INTO `daojutemp` VALUES ('3', 'ZT-0003', 'Φ22 钻头(T49)', 'Φ22', '钻头', '180', 'FMS-1#机', 'T06', 'M', '刀具', '1', '1', '1', '', 'T50');
INSERT INTO `daojutemp` VALUES ('4', 'ZT-0004', 'φ14.5 钻头(T202)', 'φ14.5', '钻头', '200', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T203');
INSERT INTO `daojutemp` VALUES ('5', 'ZT-0005', 'φ10.5 钻头(T57)', 'φ10.5', '钻头', '200', 'FMS-1#机', 'T08', 'M', '刀具', '1', '1', '1', '', 'T58');
INSERT INTO `daojutemp` VALUES ('6', 'ZT-0006', 'Φ26 钻头(T118)', 'Φ26', '钻头', '30', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T119');
INSERT INTO `daojutemp` VALUES ('7', 'ZT-0007', 'Φ10.7 钻头(T140)', 'Φ10.7', '钻头', '88', 'FMS-1#机', 'T11', 'M', '刀具', '1', '1', '1', '', 'T141');
INSERT INTO `daojutemp` VALUES ('8', 'ZT-0008', 'Φ10.7 钻头(T141)', 'Φ10.7', '钻头', '120', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T142');
INSERT INTO `daojutemp` VALUES ('9', 'ZT-0009', 'Φ6 钻头(T148)', 'Φ6', '钻头', '50', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T149');
INSERT INTO `daojutemp` VALUES ('10', 'ZT-0010', 'Φ12.5 钻头(T144)', 'Φ12.5', '钻头', '110', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T145');
INSERT INTO `daojutemp` VALUES ('11', 'ZT-0011', 'Φ15.7 钻头(T149)', 'Φ15.7', '钻头', '20', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T150');
INSERT INTO `daojutemp` VALUES ('12', 'ZT-0012', 'φ20.5 钻头(T116)', 'φ20.5', '钻头', '70', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T117');
INSERT INTO `daojutemp` VALUES ('13', 'ZT-0013', 'Φ26 钻(T111)', 'Φ26', '钻头', '30', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T112');
INSERT INTO `daojutemp` VALUES ('14', 'ZXZ-0001', 'φ16 中心钻(T117)', 'φ16', '中心钻', '200', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T118');
INSERT INTO `daojutemp` VALUES ('15', 'ZCZ-0001', 'Φ10.4 直槽钻(T39)', 'Φ10.4', '直槽钻', '200', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T40');
INSERT INTO `daojutemp` VALUES ('16', 'ZCZ-0002', 'Φ18.5 直槽钻(T59)', 'Φ18.5', '直槽钻', '200', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T60');
INSERT INTO `daojutemp` VALUES ('17', 'ZCZ-0003', 'φ6.8 直槽钻(T79)', 'φ6.8', '直槽钻', '200', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T80');
INSERT INTO `daojutemp` VALUES ('18', 'ZCZ-0004', 'φ17.5 直槽钻(T81)', 'φ17.5', '直槽钻', '200', 'kardex 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T82');
INSERT INTO `daojutemp` VALUES ('19', 'YMX-0001', 'Φ100玉米铣(T1055)', 'Φ100', '玉米铣', '200', '北车床线', 'T12', 'M', '刀具', '1', '1', '1', '', 'T1056');
INSERT INTO `daojutemp` VALUES ('20', 'YMX-0002', 'Φ44玉米铣(T1055)', 'Φ44', '玉米铣', '200', 'FMS-2#机', 'T16', 'M', '刀具', '1', '1', '1', '', 'T1056');
INSERT INTO `daojutemp` VALUES ('21', 'YMX-0003', 'φ32玉米铣T1104', 'φ32', '玉米铣', '200', 'kardex 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1105');
INSERT INTO `daojutemp` VALUES ('22', 'YZ-0001', 'Φ8.65 硬钻(T1028)', 'Φ8.65', '硬钻', '200', 'FMS-2#机', 'T02', 'M', '刀具', '1', '1', '1', '', 'T1029');
INSERT INTO `daojutemp` VALUES ('23', 'YZ-0002', 'Φ27 硬钻(T1047)', 'Φ27', '硬钻', '200', '南车床线', 'T09', 'M', '刀具', '1', '1', '1', '', 'T1048');
INSERT INTO `daojutemp` VALUES ('24', 'YZ-0003', 'Φ12硬钻（T1009)', 'Φ12', '硬钻', '200', 'kardex 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1010');
INSERT INTO `daojutemp` VALUES ('25', 'YZ-0004', 'Φ10.8硬钻（T1010)', 'Φ10.8', '硬钻', '200', 'OP20T01', 'T30', 'M', '刀具', '1', '1', '1', '', 'T1011');
INSERT INTO `daojutemp` VALUES ('26', 'YZ-0005', 'φ13 硬钻(T131)', 'φ13', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T131');
INSERT INTO `daojutemp` VALUES ('27', 'YZ-0006', 'φ6.8 硬钻(T116)', 'φ6.8', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T117');
INSERT INTO `daojutemp` VALUES ('28', 'YZ-0007', 'φ19.7硬钻(T119)', 'φ19.7', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T120');
INSERT INTO `daojutemp` VALUES ('29', 'YZ-0008', 'φ8.7 硬钻(T35)', 'φ8.7', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T36');
INSERT INTO `daojutemp` VALUES ('30', 'YZ-0009', 'φ13 硬钻(T77)', 'φ13', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T78');
INSERT INTO `daojutemp` VALUES ('31', 'YZ-0010', 'φ11 硬钻(T40)', 'φ11', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T41');
INSERT INTO `daojutemp` VALUES ('32', 'YZ-0011', 'φ15.7 硬钻(T45)', 'φ15.7', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T46');
INSERT INTO `daojutemp` VALUES ('33', 'YZ-0012', 'φ12.5 硬钻(T46)', 'φ12.5', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T47');
INSERT INTO `daojutemp` VALUES ('34', 'YZ-0013', 'φ10.7 硬钻(T47)', 'φ10.7', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T47');
INSERT INTO `daojutemp` VALUES ('35', 'YZ-0014', 'Φ10.7 硬钻(T49)', 'Φ10.7', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T49');
INSERT INTO `daojutemp` VALUES ('36', 'YZ-0015', 'Φ6.05 硬钻(T59)', 'Φ6.05', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T59');
INSERT INTO `daojutemp` VALUES ('37', 'YZ-0016', 'Φ6.05 硬钻(T60)', 'Φ6.05', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T60');
INSERT INTO `daojutemp` VALUES ('38', 'YZ-0017', 'Φ13 硬钻(T114)', 'Φ13', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T115');
INSERT INTO `daojutemp` VALUES ('39', 'YZ-0018', 'Φ17.5 硬钻(T82)', 'Φ17.5', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T83');
INSERT INTO `daojutemp` VALUES ('40', 'YZ-0019', 'Φ8.7 硬钻(T86)', 'Φ8.7', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T87');
INSERT INTO `daojutemp` VALUES ('41', 'YZ-0020', 'Φ11 硬钻(T88)', 'Φ11', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T89');
INSERT INTO `daojutemp` VALUES ('42', 'YZ-0021', 'Φ11.7 硬钻(T89)', 'Φ11.7', '硬钻', '200', 'kardex 1号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T90');
INSERT INTO `daojutemp` VALUES ('43', 'YZ-0022', 'Φ13 硬钻(T90)', 'Φ13', '硬钻', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T91');
INSERT INTO `daojutemp` VALUES ('44', 'XD-0001', 'Φ20铣刀（立）(T53)', 'Φ20', '铣刀（立）', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T54');
INSERT INTO `daojutemp` VALUES ('45', 'XD-0002', 'Φ100 铣刀(T1001)', 'Φ100', '铣刀', '200', '南车床线', 'T03', 'M', '刀具', '1', '1', '1', '', 'T1002');
INSERT INTO `daojutemp` VALUES ('46', 'XD-0003', 'Φ100 铣刀(T1009)', 'Φ100', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T1010');
INSERT INTO `daojutemp` VALUES ('47', 'XD-0004', 'Φ84 铣刀(T1015)', 'Φ84', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T1016');
INSERT INTO `daojutemp` VALUES ('48', 'XD-0005', 'Φ80 铣刀（T1035）', 'Φ80', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T1037');
INSERT INTO `daojutemp` VALUES ('49', 'XD-0006', 'Φ50铣刀(T1054)', 'Φ50', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T1055');
INSERT INTO `daojutemp` VALUES ('50', 'XD-0007', 'Φ100铣刀(T1002)', 'Φ100', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T1003');
INSERT INTO `daojutemp` VALUES ('51', 'XD-0008', 'Φ25铣刀(T1017)', 'Φ25', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T1018');
INSERT INTO `daojutemp` VALUES ('52', 'XD-0009', 'Φ100铣刀(T1028)', 'Φ100', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T1029');
INSERT INTO `daojutemp` VALUES ('53', 'XD-0010', 'Φ80铣刀(T1058)', 'Φ80', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T1059');
INSERT INTO `daojutemp` VALUES ('54', 'XD-0011', 'D80 铣刀(T185)', 'D80', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T186');
INSERT INTO `daojutemp` VALUES ('55', 'XD-0012', 'D63 铣刀(T101)', 'D63', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T102');
INSERT INTO `daojutemp` VALUES ('56', 'XD-0013', 'Φ30 铣刀(T102)', 'Φ30', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T103');
INSERT INTO `daojutemp` VALUES ('57', 'XD-0014', 'D25 铣刀(T132)', 'D25', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T133');
INSERT INTO `daojutemp` VALUES ('58', 'XD-0015', 'φ20 铣刀(T137)', 'φ20', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T138');
INSERT INTO `daojutemp` VALUES ('59', 'XD-0016', 'Φ32 铣刀(T64)', 'Φ32', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T65');
INSERT INTO `daojutemp` VALUES ('60', 'XD-0017', 'Φ40 铣刀(T130)', 'Φ40', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T131');
INSERT INTO `daojutemp` VALUES ('61', 'XD-0018', 'D125 铣刀(T20)', 'D125', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T21');
INSERT INTO `daojutemp` VALUES ('62', 'XD-0019', 'Φ20 铣刀(T50)', 'Φ20', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T51');
INSERT INTO `daojutemp` VALUES ('63', 'XD-0020', 'Φ34 铣刀(T120)', 'Φ34', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T121');
INSERT INTO `daojutemp` VALUES ('64', 'XD-0021', 'D63/C30 铣刀（T169)', 'D63/C30', '铣刀', '200', 'kardex 1号柜', '04层', 'S', '刀具', '1', '1', '1', '', 'T171');
INSERT INTO `daojutemp` VALUES ('65', 'XCD-0001', 'Φ63 铣槽刀(T78)', 'Φ63', '铣槽刀', '200', 'FMS-3#机', 'T01', 'M', '刀具', '1', '1', '1', '', 'T79');
INSERT INTO `daojutemp` VALUES ('66', 'TD-0001', 'Φ31.5 镗刀(T1032)', 'Φ31.5', '镗刀', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1033');
INSERT INTO `daojutemp` VALUES ('67', 'TD-0002', 'Φ15镗刀（T1008)', 'Φ15', '镗刀', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1009');
INSERT INTO `daojutemp` VALUES ('68', 'TD-0003', 'Φ12 镗刀(T1013)', 'Φ12', '镗刀', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1014');
INSERT INTO `daojutemp` VALUES ('69', 'TD-0004', 'Φ42 镗刀(T1021)', 'Φ42', '镗刀', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1022');
INSERT INTO `daojutemp` VALUES ('70', 'TD-0005', 'Φ20 镗刀(T1023)', 'Φ20', '镗刀', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1024');
INSERT INTO `daojutemp` VALUES ('71', 'TD-0006', 'Φ15镗刀(T1054)', 'Φ15', '镗刀', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1055');
INSERT INTO `daojutemp` VALUES ('72', 'TD-0007', 'φ35.72 镗刀(T177)', 'φ35.72', '镗刀', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T178');
INSERT INTO `daojutemp` VALUES ('73', 'SZ-0001', 'M10×1 丝锥(T1003)', 'M10×1', '丝锥', '200', 'FMS-2#机', 'T10', 'M', '刀具', '1', '1', '1', '', 'T1004');
INSERT INTO `daojutemp` VALUES ('74', 'SZ-0002', 'M8 丝锥(T1005)', 'M8', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1006');
INSERT INTO `daojutemp` VALUES ('75', 'SZ-0003', 'M22x1.5 丝锥(T1011)', 'M22x1.5', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1012');
INSERT INTO `daojutemp` VALUES ('76', 'SZ-0004', 'M12×6H 丝锥（T1013)', 'M12×6H', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1014');
INSERT INTO `daojutemp` VALUES ('77', 'SZ-0005', 'M20 丝锥(T1022)', 'M20', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1023');
INSERT INTO `daojutemp` VALUES ('78', 'SZ-0006', 'M12×1.25 丝锥(T1025)', 'M12×1.25', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1026');
INSERT INTO `daojutemp` VALUES ('79', 'SZ-0007', 'M10x1 丝锥(T1030)', 'M10x1', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1031');
INSERT INTO `daojutemp` VALUES ('80', 'SZ-0008', 'M16x1.5 丝锥(T1038)', 'M16x1.5', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1039');
INSERT INTO `daojutemp` VALUES ('81', 'SZ-0009', 'M10×1.5丝锥(T1113)', 'M10×1.5', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1114');
INSERT INTO `daojutemp` VALUES ('82', 'SZ-0010', 'M16×1.5丝锥（T1005)', 'M16×1.5', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1006');
INSERT INTO `daojutemp` VALUES ('83', 'SZ-0011', 'M12×1.25丝锥（T1011)', 'M12×1.25', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1012');
INSERT INTO `daojutemp` VALUES ('84', 'SZ-0012', 'M10×1.25丝锥(T1016)', 'M10×1.25', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1017');
INSERT INTO `daojutemp` VALUES ('85', 'SZ-0013', 'M22×1.5丝锥(T1019)', 'M22×1.5', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1020');
INSERT INTO `daojutemp` VALUES ('86', 'SZ-0014', 'M8丝锥(T1042)', 'M8', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1043');
INSERT INTO `daojutemp` VALUES ('87', 'SZ-0015', 'M10×1丝锥(T1045)', 'M10×1', '丝锥', '200', 'FMS-3#机', 'T05', 'M', '刀具', '1', '1', '1', '', 'T1046');
INSERT INTO `daojutemp` VALUES ('88', 'SZ-0016', 'M6丝锥(T1047)', 'M6', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1048');
INSERT INTO `daojutemp` VALUES ('89', 'SZ-0017', 'M18×1.5丝锥(T1049)', 'M18×1.5', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1050');
INSERT INTO `daojutemp` VALUES ('90', 'SZ-0018', 'M22*1.5丝锥(T1101)', 'M22*1.5', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1102');
INSERT INTO `daojutemp` VALUES ('91', 'SZ-0019', 'M8*1.25丝锥(T118)', 'M8*1.25', '丝锥', '200', 'kardex 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T119');
INSERT INTO `daojutemp` VALUES ('92', 'SZ-0020', 'M10*1.25 丝锥(T36)', 'M10*1.25', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T37');
INSERT INTO `daojutemp` VALUES ('93', 'SZ-0021', 'M14*1.5 丝锥(T50)', 'M14*1.5', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T51');
INSERT INTO `daojutemp` VALUES ('94', 'SZ-0022', 'M12*1.25 丝锥(T51)', 'M12*1.25', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T52');
INSERT INTO `daojutemp` VALUES ('95', 'SZ-0023', 'M22*1.5 丝锥(T134)', 'M22*1.5', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T135');
INSERT INTO `daojutemp` VALUES ('96', 'SZ-0024', 'M12*1.5 丝锥(T58)', 'M12*1.5', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T59');
INSERT INTO `daojutemp` VALUES ('97', 'SZ-0025', 'M20*1.5 丝锥(T61)', 'M20*1.5', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T62');
INSERT INTO `daojutemp` VALUES ('98', 'SZ-0026', 'M8*1.25 丝锥(T80)', 'M8*1.25', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T81');
INSERT INTO `daojutemp` VALUES ('99', 'SZ-0027', 'M10*1.25 丝锥(T92)', 'M10*1.25', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T93');
INSERT INTO `daojutemp` VALUES ('100', 'SZ-0028', 'M22*1.5 丝锥(T117)', 'M22*1.5', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T118');
INSERT INTO `daojutemp` VALUES ('101', 'SZ-0029', 'M12*1.25 丝锥(T142)', 'M12*1.25', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T143');
INSERT INTO `daojutemp` VALUES ('102', 'SZ-0030', 'M14*1.5 丝锥(T147)', 'M14*1.5', '丝锥', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T148');
INSERT INTO `daojutemp` VALUES ('103', 'QZ-0001', 'Φ20H9 枪钻(T1046)', 'Φ20H9', '枪钻', '200', 'FMS-2#机', 'T01', 'M', '刀具', '1', '1', '1', '', 'T1047');
INSERT INTO `daojutemp` VALUES ('104', 'LWXD-0001', 'M39螺纹铣刀（T1103）', 'M39', '螺纹铣刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1104');
INSERT INTO `daojutemp` VALUES ('105', 'LWXD-0002', 'D16*2 螺纹铣刀(T53)', 'D16*2', '螺纹铣刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T54');
INSERT INTO `daojutemp` VALUES ('106', 'LWXD-0003', 'M16*1.5 螺纹铣刀(T56)', 'M16*1.5', '螺纹铣刀', '200', 'OP20T238', 'T24', 'M', '刀具', '1', '1', '1', '', 'T57');
INSERT INTO `daojutemp` VALUES ('107', 'LXD-0001', '  Φ12立铣刀 (T1052)', 'Φ13', '立铣刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', '');
INSERT INTO `daojutemp` VALUES ('108', 'LXD-0002', 'Φ16立铣刀(T1056)', 'Φ16', '立铣刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1057');
INSERT INTO `daojutemp` VALUES ('109', 'LXD-0003', 'Φ25 立铣刀(T86)', 'Φ25', '立铣刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T87');
INSERT INTO `daojutemp` VALUES ('110', 'LXD-0004', 'Φ11 立铣刀(T87)', 'Φ11', '立铣刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T88');
INSERT INTO `daojutemp` VALUES ('111', 'KKZ-0001', 'φ11.7 扩孔钻(T41)', 'φ11.7', '扩孔钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T42');
INSERT INTO `daojutemp` VALUES ('112', 'KKZ-0002', 'Φ26.5 扩孔钻(T67)', 'Φ26.5', '扩孔钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T68');
INSERT INTO `daojutemp` VALUES ('113', 'KKZ-0003', 'Φ29.5 扩孔钻(T60)', 'Φ29.5', '扩孔钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T61');
INSERT INTO `daojutemp` VALUES ('114', 'KKZ-0004', 'Φ25 扩孔钻(T1034)', 'Φ25', '扩孔钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1035');
INSERT INTO `daojutemp` VALUES ('115', 'KJXD-0001', 'Φ250*15 宽精铣刀（T225）', 'Φ250*15', '宽精铣刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T227');
INSERT INTO `daojutemp` VALUES ('116', 'KJXD-0002', 'Φ250*15 宽精铣刀（T225)', 'Φ250*15', '宽精铣刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T227');
INSERT INTO `daojutemp` VALUES ('117', 'JX-0001', 'D63 精铣(T76)', 'D63', '精铣', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T77');
INSERT INTO `daojutemp` VALUES ('118', 'JX-0002', 'D80 精铣(T201)', 'D80', '精铣', '200', '北车床线', 'T15', 'M', '刀具', '1', '1', '1', '', 'T202');
INSERT INTO `daojutemp` VALUES ('119', 'JX-0003', 'D80 精铣(T199)', 'D80', '精铣', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T200');
INSERT INTO `daojutemp` VALUES ('120', 'JX-0004', 'D25 精铣(T110)', 'D25', '精铣', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T111');
INSERT INTO `daojutemp` VALUES ('121', 'JTD-0001', 'Φ120 精镗刀', 'Φ121', '精镗刀', '200', 'FMS-1#机', 'T07', 'M', '刀具', '1', '1', '1', '', '');
INSERT INTO `daojutemp` VALUES ('122', 'JTD-0002', 'Φ32 精镗(T1033)', 'Φ32', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1034');
INSERT INTO `daojutemp` VALUES ('123', 'JTD-0003', 'Φ15R8 精镗(T1040)', 'Φ15R8', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1041');
INSERT INTO `daojutemp` VALUES ('124', 'JTD-0004', 'Φ15F9 精镗(T1041)', 'Φ15F9', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1042');
INSERT INTO `daojutemp` VALUES ('125', 'JTD-0005', 'Φ18F9 精镗(T1044)', 'Φ18F9', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1045');
INSERT INTO `daojutemp` VALUES ('126', 'JTD-0006', 'Φ30精镗(T1049)', 'Φ30', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1050');
INSERT INTO `daojutemp` VALUES ('127', 'JTD-0007', 'Φ110/Φ130精镗(T1050)', 'Φ110/Φ130', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1051');
INSERT INTO `daojutemp` VALUES ('128', 'JTD-0008', 'Φ120精镗(T1051)', 'Φ120', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1052');
INSERT INTO `daojutemp` VALUES ('129', 'JTD-0009', 'Φ38精镗(T1053)', 'Φ38', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1054');
INSERT INTO `daojutemp` VALUES ('130', 'JTD-0010', 'Φ130精镗(T1057)', 'Φ130', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1058');
INSERT INTO `daojutemp` VALUES ('131', 'JTD-0011', 'Φ120精镗(T1056)', 'Φ120', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1057');
INSERT INTO `daojutemp` VALUES ('132', 'JTD-0012', 'Φ68精镗(T73)', 'Φ68', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T74');
INSERT INTO `daojutemp` VALUES ('133', 'JTD-0013', 'Φ85精镗(T74)', 'Φ85', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T75');
INSERT INTO `daojutemp` VALUES ('134', 'JTD-0014', 'Φ30精镗(T75)', 'Φ30', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T76');
INSERT INTO `daojutemp` VALUES ('135', 'JTD-0015', 'Φ80 精镗 (T37)', 'Φ80', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', '');
INSERT INTO `daojutemp` VALUES ('136', 'JTD-0016', 'Φ72 精镗 (T66)', 'Φ72', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', '');
INSERT INTO `daojutemp` VALUES ('137', 'JTD-0017', 'Φ396 精镗(T13)', 'Φ396', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T14');
INSERT INTO `daojutemp` VALUES ('138', 'JTD-0018', 'Φ190 精镗(T235)', 'Φ190', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T236');
INSERT INTO `daojutemp` VALUES ('139', 'JTD-0019', 'Φ90 精镗(T175)', 'Φ90', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T176');
INSERT INTO `daojutemp` VALUES ('140', 'JTD-0020', 'Φ85 精镗(T176)', 'Φ85', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T177');
INSERT INTO `daojutemp` VALUES ('141', 'JTD-0021', 'Φ30 精镗(T62)', 'Φ30', '精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T63');
INSERT INTO `daojutemp` VALUES ('142', 'JTZ-0001', 'Φ29 阶梯钻(T1031)', 'Φ29', '阶梯钻', '200', '北车床线', 'T17', 'M', '刀具', '1', '1', '1', '', 'T1032');
INSERT INTO `daojutemp` VALUES ('143', 'JTZ-0002', 'Φ6.8阶梯钻(T1041)', 'Φ6.8', '阶梯钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1042');
INSERT INTO `daojutemp` VALUES ('144', 'JTZ-0003', 'Φ20阶梯钻(T1043)', 'Φ20', '阶梯钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1044');
INSERT INTO `daojutemp` VALUES ('145', 'JTZ-0004', 'Φ9阶梯钻(T1044)', 'Φ9', '阶梯钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1045');
INSERT INTO `daojutemp` VALUES ('146', 'JTZ-0005', 'Φ5阶梯钻(T1046)', 'Φ5', '阶梯钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1047');
INSERT INTO `daojutemp` VALUES ('147', 'JTZ-0006', 'Φ16.5阶梯钻(T1048)', 'Φ16.5', '阶梯钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1049');
INSERT INTO `daojutemp` VALUES ('148', 'JTZ-0007', 'Φ11.8阶梯钻(T1050)', 'Φ11.8', '阶梯钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1051');
INSERT INTO `daojutemp` VALUES ('149', 'JTZ-0008', 'Φ17阶梯钻(T1063)', 'Φ17', '阶梯钻', '200', '北车床线', 'T18', 'M', '刀具', '1', '1', '1', '', 'T1064');
INSERT INTO `daojutemp` VALUES ('150', 'JD-0001', 'Φ12F9-铰刀 (T1051)', 'Φ12F9-', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1052');
INSERT INTO `daojutemp` VALUES ('151', 'JD-0002', 'Φ18R8铰刀(T79)', 'Φ18R8', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T80');
INSERT INTO `daojutemp` VALUES ('152', 'JD-0003', 'Φ20H9铰刀(T80)', 'Φ20H9', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T81');
INSERT INTO `daojutemp` VALUES ('153', 'JD-0004', 'Φ12R8 铰刀(T42)', 'Φ12R8', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T43');
INSERT INTO `daojutemp` VALUES ('154', 'JD-0005', 'Φ16F9 铰刀(T56)', 'Φ16F9', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T57');
INSERT INTO `daojutemp` VALUES ('155', 'JD-0006', 'Φ28 铰刀(T58)', 'Φ28', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T59');
INSERT INTO `daojutemp` VALUES ('156', 'JD-0007', 'Φ26.82 铰刀(T68)', 'Φ26.82', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T69');
INSERT INTO `daojutemp` VALUES ('157', 'JD-0008', 'Φ12R8 铰刀(T93)', 'Φ12R8', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T94');
INSERT INTO `daojutemp` VALUES ('158', 'JD-0009', 'Φ13.2H7 铰刀(T143)', 'Φ13.2H7', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T144');
INSERT INTO `daojutemp` VALUES ('159', 'JD-0010', 'Φ16F9 铰刀(T151)', 'Φ16F9', '铰刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T152');
INSERT INTO `daojutemp` VALUES ('160', 'HKZ-0001', 'Φ17.7锪孔钻(T115)', 'Φ17.7', '锪孔钻', '200', 'FMS-1#机', 'T02', 'M', '刀具', '1', '1', '1', '', 'T116');
INSERT INTO `daojutemp` VALUES ('161', 'FJTD-0001', 'Φ120反精镗刀(T30)', 'Φ120', '反精镗刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T31');
INSERT INTO `daojutemp` VALUES ('162', 'FJTD-0002', 'Φ200 反精镗(T17)', 'Φ200', '反精镗', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T18');
INSERT INTO `daojutemp` VALUES ('163', 'FH-0001', 'Φ17.5/Φ40 反划(T83)', 'Φ17.5/Φ40', '反划', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T84');
INSERT INTO `daojutemp` VALUES ('164', 'DJZ-0001', 'φ12 倒角钻(T71)', 'φ12', '倒角钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T72');
INSERT INTO `daojutemp` VALUES ('165', 'DJZ-0002', 'Φ21-Φ35 倒角钻(T52)', 'Φ21-Φ35', '倒角钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T53');
INSERT INTO `daojutemp` VALUES ('166', 'DJZ-0003', 'φ20 倒角钻(T200)', 'φ20', '倒角钻', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T201');
INSERT INTO `daojutemp` VALUES ('167', 'DJX-0001', 'Φ50 倒角铣刀(T1020)', 'Φ50', '倒角铣刀', '200', 'FMS-1#机', 'T04', 'M', '刀具', '1', '1', '1', '', 'T1021');
INSERT INTO `daojutemp` VALUES ('168', 'DJX-0002', 'Φ32.5-48.2倒角铣(T105)', 'Φ32.5-48.2', '倒角铣', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T106');
INSERT INTO `daojutemp` VALUES ('169', 'DJX-0003', 'Φ42 倒角铣(T110)', 'Φ42', '倒角铣', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T111');
INSERT INTO `daojutemp` VALUES ('170', 'DJX-0004', 'D40/C45 倒角铣(T180)', 'D40/C45', '倒角铣', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T181');
INSERT INTO `daojutemp` VALUES ('171', 'DJ-0001', 'D63/C30 倒角刀(T81)', 'D63/C30', '倒角刀', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T82');
INSERT INTO `daojutemp` VALUES ('172', 'DJ-0002', 'Φ21-Φ35倒角(T113)', 'Φ21-Φ35', '倒角', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T114');
INSERT INTO `daojutemp` VALUES ('173', 'CX-0001', 'D80 粗铣(T63)', 'D80', '粗铣', '200', 'kardex 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T64');
INSERT INTO `daojutemp` VALUES ('174', 'CX-0002', 'D25 粗铣(T109)', 'D25', '粗铣', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T110');
INSERT INTO `daojutemp` VALUES ('175', 'CT-0001', 'Φ63 粗镗刀(T103)', 'Φ63', '粗镗刀', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T104');
INSERT INTO `daojutemp` VALUES ('176', 'CT-0002', 'φ75 粗镗刀(T136)', 'φ75', '粗镗刀', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T137');
INSERT INTO `daojutemp` VALUES ('177', 'CT-0003', 'φ180 粗镗刀', 'φ180', '粗镗刀', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', '');
INSERT INTO `daojutemp` VALUES ('178', 'CT-0004', 'φ416 粗镗刀', 'φ416', '粗镗刀', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', '');
INSERT INTO `daojutemp` VALUES ('179', 'CT-0005', 'Φ170 粗镗刀', 'Φ170', '粗镗刀', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', '');
INSERT INTO `daojutemp` VALUES ('180', 'CT-0006', 'Φ37.5粗镗(T1052)', 'Φ37.5', '粗镗', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T1053');
INSERT INTO `daojutemp` VALUES ('181', 'CT-0007', 'Φ101 粗镗(T106)', 'Φ101', '粗镗', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T107');
INSERT INTO `daojutemp` VALUES ('182', 'CT-0008', 'Φ106 粗镗(T107)', 'Φ106', '粗镗', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T108');
INSERT INTO `daojutemp` VALUES ('183', 'CT-0009', 'Φ80 粗镗(T108)', 'Φ80', '粗镗', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T109');
INSERT INTO `daojutemp` VALUES ('184', 'CT-0010', 'Φ29.7 粗镗(T112)', 'Φ29.7', '粗镗', '200', '箱式 1号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T113');
INSERT INTO `daojutemp` VALUES ('185', 'CT-0011', 'Φ115 粗镗(T22)', 'Φ115', '粗镗', '200', 'OP20T40', '02层', 'S', '刀具', '1', '1', '1', '', 'T23');
INSERT INTO `daojutemp` VALUES ('186', 'CT-0012', 'Φ67 粗镗 (T61)', 'Φ67', '粗镗', '200', '箱式 1号柜', 'T08', 'M', '刀具', '1', '1', '1', '', '');
INSERT INTO `daojutemp` VALUES ('187', 'CT-0013', 'Φ189.5 粗镗(T229)', 'Φ189.5', '粗镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T230');
INSERT INTO `daojutemp` VALUES ('188', 'CT-0014', 'Φ391 粗镗(T8)', 'Φ391', '粗镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T9');
INSERT INTO `daojutemp` VALUES ('189', 'CT-0015', 'φ395.5 粗镗(T2)', 'φ395.5', '粗镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T3');
INSERT INTO `daojutemp` VALUES ('190', 'CT-0016', 'Φ33.7 粗镗(T145)', 'Φ33.7', '粗镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T146');
INSERT INTO `daojutemp` VALUES ('191', 'CT-0017', 'φ88.5 粗镗(T170)', 'φ88.5', '粗镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T171');
INSERT INTO `daojutemp` VALUES ('192', 'CT-0018', 'φ80 粗镗(T172)', 'φ80', '粗镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T173');
INSERT INTO `daojutemp` VALUES ('193', 'CXD-0001', 'Φ20.2*3.5 槽铣刀（T150)', 'Φ20.2*3.5', '槽铣刀', '200', 'FMS-3#机', 'T10', 'M', '刀具', '1', '1', '1', '', 'T152');
INSERT INTO `daojutemp` VALUES ('194', 'CXD-0002', 'φ63*3.15 槽铣刀(T174)', 'φ63*3.15', '槽铣刀', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T175');
INSERT INTO `daojutemp` VALUES ('195', 'BJT-0001', 'Φ29.5 半精镗(T1048)', 'Φ29.5', '半精镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T1049');
INSERT INTO `daojutemp` VALUES ('196', 'BJT-0002', 'Φ67.7半精镗(T104)', 'Φ67.7', '半精镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T105');
INSERT INTO `daojutemp` VALUES ('197', 'BJT-0003', 'φ84.7半精镗(T109)', 'φ84.7', '半精镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T110');
INSERT INTO `daojutemp` VALUES ('198', 'BJT-0004', 'Φ119.7半精镗(T20)', 'Φ119.7', '半精镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T21');
INSERT INTO `daojutemp` VALUES ('199', 'BJT-0005', 'Φ79.7 半精镗(T34)', 'Φ79.7', '半精镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T35');
INSERT INTO `daojutemp` VALUES ('200', 'BJT-0006', 'Φ27.7 半精镗(T57)', 'Φ27.7', '半精镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T58');
INSERT INTO `daojutemp` VALUES ('201', 'BJT-0007', 'Φ71.7 半精镗(T62)', 'Φ71.7', '半精镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T63');
INSERT INTO `daojutemp` VALUES ('202', 'BJT-0008', 'Φ27.7 半精镗(T119)', 'Φ27.7', '半精镗', '200', '箱式 1号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T120');
INSERT INTO `daojutemp` VALUES ('203', 'BJT-0009', 'φ35.4 半精镗(T146)', 'φ35.4', '半精镗', '200', '箱式 2号柜', '01层', 'S', '刀具', '1', '1', '1', '', 'T147');
INSERT INTO `daojutemp` VALUES ('204', 'BJT-0010', 'φ89.7 半精镗(T171)', 'φ89.7', '半精镗', '200', '箱式 2号柜', '02层', 'S', '刀具', '1', '1', '1', '', 'T172');
INSERT INTO `daojutemp` VALUES ('205', 'BJT-0011', 'φ84.7 半精镗(T173)', 'φ84.7', '半精镗', '200', '箱式 2号柜', '03层', 'S', '刀具', '1', '1', '1', '', 'T174');
INSERT INTO `daojutemp` VALUES ('206', 'UZ-0001', 'Φ25U钻(T1057)', 'Φ25', 'U钻', '200', 'FMS-1#机', 'T01', 'M', '刀具', '1', '1', '1', '', 'T1058');
INSERT INTO `daojutemp` VALUES ('207', 'UZ-0002', 'Φ20.5U钻(T1100)', 'Φ20.5', 'U钻', '200', '箱式 2号柜', '05层', 'S', '刀具', '1', '1', '1', '', 'T1101');
INSERT INTO `daojutemp` VALUES ('208', 'UZ-0003', 'φ37U钻（T1102）', 'φ37', 'U钻', '200', 'FMS-1#机', 'T03', 'M', '刀具', '1', '1', '1', '', 'T1103');
INSERT INTO `daojutemp` VALUES ('223', 'ZT-0014', 'Φ10.4 钻头(T38)', 'Φ10.4', '钻头', '2000', '箱式 2号柜', '01层', 'S', '刀具', '1', '1', '1', '组装刀', null);

-- ----------------------------
-- Table structure for `daojutuihuan`
-- ----------------------------
DROP TABLE IF EXISTS `daojutuihuan`;
CREATE TABLE `daojutuihuan` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL,
  `thbz` varchar(20) NOT NULL,
  `thr` varchar(10) NOT NULL,
  `thrq` date NOT NULL,
  `thyy` text,
  `jbr` varchar(10) NOT NULL,
  `jbrq` date NOT NULL,
  `djzt` int(2) DEFAULT NULL,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `danhao` (`danhao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojutuihuan
-- ----------------------------

-- ----------------------------
-- Table structure for `daojutuihuanmingxi`
-- ----------------------------
DROP TABLE IF EXISTS `daojutuihuanmingxi`;
CREATE TABLE `daojutuihuanmingxi` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL,
  `djlx` varchar(50) NOT NULL,
  `djgg` char(20) DEFAULT NULL,
  `djcd` char(10) DEFAULT NULL,
  `djid` char(20) NOT NULL,
  `djzt` varchar(20) DEFAULT NULL,
  `sl` int(11) NOT NULL,
  `jcbm` char(20) NOT NULL,
  `dth` char(20) NOT NULL,
  `djgbm` varchar(20) NOT NULL,
  `cfwz` varchar(20) DEFAULT NULL,
  `bz` tinytext,
  PRIMARY KEY (`xh`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojutuihuanmingxi
-- ----------------------------

-- ----------------------------
-- Table structure for `daojuwaijie`
-- ----------------------------
DROP TABLE IF EXISTS `daojuwaijie`;
CREATE TABLE `daojuwaijie` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL,
  `jydw` varchar(20) NOT NULL,
  `dwld` varchar(20) DEFAULT NULL,
  `jyr` varchar(20) NOT NULL,
  `lxdh` char(20) DEFAULT NULL,
  `jyyy` text NOT NULL,
  `spld` varchar(20) NOT NULL,
  `spyj` text NOT NULL,
  `jbr` varchar(20) NOT NULL,
  `jcsj` date NOT NULL,
  `ydghsj` date DEFAULT NULL,
  `djzt` int(2) DEFAULT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojuwaijie
-- ----------------------------

-- ----------------------------
-- Table structure for `daojuwaijiemingxi`
-- ----------------------------
DROP TABLE IF EXISTS `daojuwaijiemingxi`;
CREATE TABLE `daojuwaijiemingxi` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL,
  `djlx` char(50) NOT NULL,
  `djgg` char(20) NOT NULL,
  `djid` char(20) NOT NULL,
  `djzt` varchar(20) NOT NULL,
  `sl` int(6) NOT NULL,
  `jcbm` char(20) NOT NULL,
  `dth` char(10) NOT NULL,
  `bz` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of daojuwaijiemingxi
-- ----------------------------

-- ----------------------------
-- Table structure for `daojuxuyong`
-- ----------------------------
DROP TABLE IF EXISTS `daojuxuyong`;
CREATE TABLE `daojuxuyong` (
  `xh` int(20) NOT NULL AUTO_INCREMENT COMMENT '序号',
  `xydh` char(20) CHARACTER SET utf8 NOT NULL COMMENT '续用单号',
  `xybz` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '续用班组',
  `xyr` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '续用人',
  `xyrq` date DEFAULT NULL COMMENT '续用日期',
  `beizhu` tinytext CHARACTER SET utf8 COMMENT '备注',
  `spr` varchar(20) DEFAULT NULL COMMENT '审批人',
  `jbr` char(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '经办人',
  `djzt` int(2) DEFAULT NULL COMMENT '单据状态',
  PRIMARY KEY (`xh`),
  UNIQUE KEY `xuyongdanhao` (`xydh`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of daojuxuyong
-- ----------------------------

-- ----------------------------
-- Table structure for `daojuxuyongmingxi`
-- ----------------------------
DROP TABLE IF EXISTS `daojuxuyongmingxi`;
CREATE TABLE `daojuxuyongmingxi` (
  `xh` int(10) NOT NULL AUTO_INCREMENT COMMENT '序号',
  `xydh` char(20) CHARACTER SET utf8 NOT NULL COMMENT '续用单号',
  `djlx` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '刀具类型',
  `djgg` char(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '刀具规格',
  `djid` char(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '刀具id',
  `sl` int(10) DEFAULT NULL COMMENT '数量',
  `jggx` char(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '加工工序',
  `jcbm` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '机床编码',
  `dth` varchar(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '刀套号',
  `xygx` varchar(50) DEFAULT NULL COMMENT '续用工序',
  `xyjcbm` varchar(20) DEFAULT NULL COMMENT '续用机床编码',
  `xydth` varchar(20) DEFAULT NULL COMMENT '续用刀套号',
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of daojuxuyongmingxi
-- ----------------------------

-- ----------------------------
-- Table structure for `gongxu`
-- ----------------------------
DROP TABLE IF EXISTS `gongxu`;
CREATE TABLE `gongxu` (
  `xh` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `gykbh` char(50) NOT NULL,
  `gxh` char(20) CHARACTER SET utf8 NOT NULL,
  `jgljh` char(20) DEFAULT NULL,
  `jgljmc` char(50) CHARACTER SET utf8 DEFAULT NULL,
  `gxnr` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `jichuangbianma` char(20) CHARACTER SET utf8 DEFAULT NULL,
  `jiaju` char(20) CHARACTER SET utf8 DEFAULT NULL,
  `dbxx` char(20) CHARACTER SET utf8 DEFAULT NULL,
  `djscsj` char(20) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=94 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of gongxu
-- ----------------------------
INSERT INTO `gongxu` VALUES ('75', 'GY-001', '工序4', '1204.28.101', '两侧半轴面及侧面凸台', '30.5±0.3', 'FMS-1#机', null, null, null);
INSERT INTO `gongxu` VALUES ('74', 'GY-001', '工序3', '1204.28.101', '两侧半轴面及侧面凸台', '30.5±0.2', 'FMS-1#机', null, null, null);
INSERT INTO `gongxu` VALUES ('73', 'GY-001', '工序2', '1204.28.101', '两侧半轴面及侧面凸台', '30.5±0.1', 'FMS-1#机', null, null, null);
INSERT INTO `gongxu` VALUES ('72', 'GY-001', '工序1', '1204.28.101', '两侧半轴面及侧面凸台', '粗铣两侧半轴面', 'FMS-1#机', null, null, null);
INSERT INTO `gongxu` VALUES ('5', 'GY-002', '工序1', '1204.28.101', '两侧半轴面及侧面凸台', '170.5±0.1(两侧)', 'FMS-2#机', '夹具5', '刀柄5', '46分钟');
INSERT INTO `gongxu` VALUES ('6', 'GY-002', '工序2', '1204.28.101', '两侧半轴面及侧面凸台', '粗铣两侧半轴面', 'FMS-2#机', '夹具6', '刀柄6', '47分钟');
INSERT INTO `gongxu` VALUES ('7', 'GY-002', '工序3', '1204.28.101', '两侧半轴面及侧面凸台', '粗铣两侧半轴面', 'FMS-2#机', '夹具7', '刀柄7', '48分钟');
INSERT INTO `gongxu` VALUES ('81', 'GY-003', '工序15', '1204.28.101', '两侧半轴面及侧面凸台', '粗铣两侧半轴面', 'FMS-1#机', null, null, null);
INSERT INTO `gongxu` VALUES ('80', 'GY-003', '工序5', '1204.28.101', '两侧半轴面及侧面凸台', '791±0.6', 'FMS-3#机', null, null, null);
INSERT INTO `gongxu` VALUES ('79', 'GY-003', '工序4', '1204.28.101', '两侧半轴面及侧面凸台', '791±0.5', 'FMS-3#机', null, null, null);
INSERT INTO `gongxu` VALUES ('78', 'GY-003', '工序3', '1204.28.101', '两侧半轴面及侧面凸台', '791±0.4', 'FMS-3#机', null, null, null);
INSERT INTO `gongxu` VALUES ('76', 'GY-003', '工序1', '1204.28.101', '两侧半轴面及侧面凸台', '791±0.2', 'FMS-3#机', null, null, null);
INSERT INTO `gongxu` VALUES ('77', 'GY-003', '工序2', '1204.28.101', '两侧半轴面及侧面凸台', '791±0.3', 'FMS-3#机', null, null, null);
INSERT INTO `gongxu` VALUES ('93', 'GY-004', '工序4', '1204.28.101', '两侧半轴面及侧面凸台', '30.5±0.3', 'FMS-1#机', null, null, null);
INSERT INTO `gongxu` VALUES ('90', 'GY-004', '工序1', '1204.28.101', '两侧半轴面及侧面凸台', '粗铣两侧半轴面', 'FMS-1#机', null, null, null);
INSERT INTO `gongxu` VALUES ('91', 'GY-004', '工序2', '1204.28.101', '两侧半轴面及侧面凸台', '30.5±0.1', 'FMS-1#机', null, null, null);
INSERT INTO `gongxu` VALUES ('92', 'GY-004', '工序3', '1204.28.101', '两侧半轴面及侧面凸台', '30.5±0.2', 'FMS-1#机', null, null, null);

-- ----------------------------
-- Table structure for `gongxupeidao`
-- ----------------------------
DROP TABLE IF EXISTS `gongxupeidao`;
CREATE TABLE `gongxupeidao` (
  `xh` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `gykbh` char(50) CHARACTER SET utf8 NOT NULL COMMENT '工艺卡编号',
  `gxh` char(20) CHARACTER SET utf8 NOT NULL COMMENT '工序号',
  `gjlx` varchar(50) CHARACTER SET utf8 NOT NULL COMMENT '工具类型，刀具或零部件',
  `gongjumingcheng` char(20) CHARACTER SET utf8 NOT NULL COMMENT '工具名称',
  `gongjuguige` char(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '工具规格',
  `gongjuxinghao` char(20) CHARACTER SET utf8 NOT NULL COMMENT '工具型号',
  `sl` int(10) NOT NULL COMMENT '数量',
  `dw` varchar(10) CHARACTER SET utf8 DEFAULT NULL COMMENT '单位',
  `jichuangbianma` char(20) CHARACTER SET utf8 NOT NULL COMMENT '机床编码',
  `daotaohao` char(20) CHARACTER SET utf8 NOT NULL COMMENT '刀套号',
  `gongjushuoming` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '工具说明',
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=149 DEFAULT CHARSET=gbk COMMENT='工序配刀表';

-- ----------------------------
-- Records of gongxupeidao
-- ----------------------------
INSERT INTO `gongxupeidao` VALUES ('122', 'GY-001', '工序4', '刀具', '钻头', 'Φ22', 'Φ22 钻头(T49)', '4', '套', 'FMS-1#机', 'T07', '');
INSERT INTO `gongxupeidao` VALUES ('121', 'GY-001', '工序3', '刀具', '玉米铣', 'Φ100', 'Φ100玉米铣(T1055)', '2', '套', 'FMS-1#机', 'T05', '');
INSERT INTO `gongxupeidao` VALUES ('120', 'GY-001', '工序3', '刀具', '中心钻', 'φ16', 'φ16 中心钻(T117)', '2', '套', 'FMS-1#机', 'T06', '');
INSERT INTO `gongxupeidao` VALUES ('119', 'GY-001', '工序2', '刀具', '钻头', 'Φ22', 'Φ22 钻头(T49)', '1', '套', 'FMS-1#机', 'T04', '');
INSERT INTO `gongxupeidao` VALUES ('118', 'GY-001', '工序1', '刀具', '中心钻', 'φ16', 'φ16 中心钻(T117)', '3', '套', 'FMS-1#机', 'T03', '');
INSERT INTO `gongxupeidao` VALUES ('117', 'GY-001', '工序1', '刀具', '钻头', 'Φ22', 'Φ22 钻头(T49)', '3', '套', 'FMS-1#机', 'T01', '');
INSERT INTO `gongxupeidao` VALUES ('8', 'GY-002', '工序1', '刀具', '玉米铣', 'Φ100', 'Φ100玉米铣(T1055)', '1', '套', 'FMS-2#机', 'T08', null);
INSERT INTO `gongxupeidao` VALUES ('9', 'GY-002', '工序2', '刀具', '中心钻', 'φ16', 'φ16 中心钻(T117)', '1', '套', 'FMS-2#机', 'T09', null);
INSERT INTO `gongxupeidao` VALUES ('10', 'GY-002', '工序2', '刀具', '钻头', 'Φ22', 'Φ22 钻头(T49)', '1', '套', 'FMS-2#机', 'T10', null);
INSERT INTO `gongxupeidao` VALUES ('11', 'GY-002', '工序3', '刀具', '玉米铣', 'Φ100', 'Φ100玉米铣(T1055)', '1', '套', 'FMS-2#机', 'T11', null);
INSERT INTO `gongxupeidao` VALUES ('127', 'GY-003', '工序5', '刀具', '钻头', 'Φ22', 'Φ22 钻头(T49)', '1', '套', 'FMS-3#机', 'T16', '');
INSERT INTO `gongxupeidao` VALUES ('126', 'GY-003', '工序4', '刀具', '中心钻', 'φ16', 'φ16 中心钻(T117)', '1', '套', 'FMS-3#机', 'T15', '');
INSERT INTO `gongxupeidao` VALUES ('123', 'GY-003', '工序1', '刀具', '中心钻', 'φ16', 'φ16 中心钻(T117)', '1', '套', 'FMS-3#机', 'T12', '');
INSERT INTO `gongxupeidao` VALUES ('125', 'GY-003', '工序3', '刀具', '玉米铣', 'Φ100', 'Φ100玉米铣(T1055)', '1', '套', 'FMS-3#机', 'T14', '');
INSERT INTO `gongxupeidao` VALUES ('124', 'GY-003', '工序2', '刀具', '钻头', 'Φ22', 'Φ22 钻头(T49)', '1', '套', 'FMS-3#机', 'T13', '');
INSERT INTO `gongxupeidao` VALUES ('116', 'GY-001', '工序1', '刀具', '玉米铣', 'Φ100', 'Φ100玉米铣(T1055)', '2', '套', 'FMS-1#机', 'T02', '');
INSERT INTO `gongxupeidao` VALUES ('142', 'GY-004', '工序1', '刀具', '玉米铣', 'Φ100', 'Φ100玉米铣(T1055)', '2', '套', 'FMS-1#机', 'T02', '');
INSERT INTO `gongxupeidao` VALUES ('143', 'GY-004', '工序1', '刀具', '中心钻', 'φ16', 'φ16 中心钻(T117)', '3', '套', 'FMS-1#机', 'T03', '');
INSERT INTO `gongxupeidao` VALUES ('144', 'GY-004', '工序2', '刀具', '钻头', 'Φ22', 'Φ22 钻头(T49)', '1', '套', 'FMS-1#机', 'T04', '');
INSERT INTO `gongxupeidao` VALUES ('145', 'GY-004', '工序3', '刀具', '玉米铣', 'Φ100', 'Φ100玉米铣(T1055)', '2', '套', 'FMS-1#机', 'T05', '');
INSERT INTO `gongxupeidao` VALUES ('146', 'GY-004', '工序3', '刀具', '中心钻', 'φ16', 'φ16 中心钻(T117)', '2', '套', 'FMS-1#机', 'T06', '');
INSERT INTO `gongxupeidao` VALUES ('147', 'GY-004', '工序4', '刀具', '钻头', 'Φ22', 'Φ22 钻头(T49)', '4', '套', 'FMS-1#机', 'T07', '');
INSERT INTO `gongxupeidao` VALUES ('148', 'GY-004', '工序1', '零部件', '槽铣刀片', '', '328R13-26502-GM1025', '10', '件', 'FMS-1#机', 'T02', '更换刀片');

-- ----------------------------
-- Table structure for `gongyika`
-- ----------------------------
DROP TABLE IF EXISTS `gongyika`;
CREATE TABLE `gongyika` (
  `xh` int(10) NOT NULL AUTO_INCREMENT,
  `gykbh` char(50) CHARACTER SET utf8 DEFAULT NULL,
  `jglx` char(20) CHARACTER SET utf8 DEFAULT NULL,
  `scgl` char(20) CHARACTER SET utf8 DEFAULT NULL,
  `fbsj` datetime NOT NULL,
  `beizhu` text CHARACTER SET utf8,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of gongyika
-- ----------------------------
INSERT INTO `gongyika` VALUES ('1', 'GY-001', '后传动箱壳体', '', '2017-11-13 12:30:36', '加工');
INSERT INTO `gongyika` VALUES ('2', 'GY-002', '动箱壳体', null, '2017-11-01 08:32:50', null);
INSERT INTO `gongyika` VALUES ('3', 'GY-003', '前传动箱壳体', null, '2017-10-01 12:33:15', '');
INSERT INTO `gongyika` VALUES ('11', 'GY-004', '后传动箱壳体', null, '2017-11-13 12:30:36', '加工');

-- ----------------------------
-- Table structure for `groupbiao`
-- ----------------------------
DROP TABLE IF EXISTS `groupbiao`;
CREATE TABLE `groupbiao` (
  `groupid` int(4) NOT NULL AUTO_INCREMENT,
  `groupname` char(20) CHARACTER SET utf8 NOT NULL,
  `groupinfo` char(50) CHARACTER SET utf8 NOT NULL,
  `time` date NOT NULL,
  `beizhu` char(100) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`groupid`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of groupbiao
-- ----------------------------
INSERT INTO `groupbiao` VALUES ('1', '系统管理组', '负责管理系统', '2017-09-12', '');
INSERT INTO `groupbiao` VALUES ('2', '工艺部', '负责管理工艺卡', '2017-09-12', '');
INSERT INTO `groupbiao` VALUES ('3', '刀管中心', '负责管理车间刀具/零部件', '2017-09-12', '');
INSERT INTO `groupbiao` VALUES ('9', '车间工作小组', '负责车间的加工任务', '2017-09-14', '一拖第三装配厂机一车间');

-- ----------------------------
-- Table structure for `jcdaojuku`
-- ----------------------------
DROP TABLE IF EXISTS `jcdaojuku`;
CREATE TABLE `jcdaojuku` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `jichuangbianma` char(20) CHARACTER SET utf8 NOT NULL,
  `daotaohao` char(20) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=523 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of jcdaojuku
-- ----------------------------
INSERT INTO `jcdaojuku` VALUES ('1', 'FMS-1#机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('2', 'FMS-1#机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('3', 'FMS-1#机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('4', 'FMS-1#机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('5', 'FMS-1#机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('6', 'FMS-1#机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('7', 'FMS-1#机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('8', 'FMS-1#机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('9', 'FMS-1#机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('10', 'FMS-1#机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('11', 'FMS-1#机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('12', 'FMS-1#机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('13', 'FMS-1#机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('14', 'FMS-1#机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('15', 'FMS-1#机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('16', 'FMS-1#机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('17', 'FMS-1#机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('18', 'FMS-1#机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('19', 'FMS-1#机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('20', 'FMS-1#机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('21', 'FMS-2#机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('22', 'FMS-2#机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('23', 'FMS-2#机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('24', 'FMS-2#机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('25', 'FMS-2#机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('26', 'FMS-2#机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('27', 'FMS-2#机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('28', 'FMS-2#机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('29', 'FMS-2#机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('30', 'FMS-2#机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('31', 'FMS-2#机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('32', 'FMS-2#机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('33', 'FMS-2#机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('34', 'FMS-2#机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('35', 'FMS-2#机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('36', 'FMS-2#机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('37', 'FMS-2#机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('38', 'FMS-2#机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('39', 'FMS-2#机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('40', 'FMS-2#机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('41', 'FMS-3#机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('42', 'FMS-3#机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('43', 'FMS-3#机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('44', 'FMS-3#机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('45', 'FMS-3#机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('46', 'FMS-3#机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('47', 'FMS-3#机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('48', 'FMS-3#机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('49', 'FMS-3#机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('50', 'FMS-3#机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('51', 'FMS-3#机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('52', 'FMS-3#机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('53', 'FMS-3#机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('54', 'FMS-3#机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('55', 'FMS-3#机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('56', 'FMS-3#机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('57', 'FMS-3#机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('58', 'FMS-3#机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('59', 'FMS-3#机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('60', 'FMS-3#机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('61', 'FMS-3#机', 'T21');
INSERT INTO `jcdaojuku` VALUES ('62', 'FMS-4#机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('63', 'FMS-4#机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('64', 'FMS-4#机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('65', 'FMS-4#机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('66', 'FMS-4#机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('67', 'FMS-4#机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('68', 'FMS-4#机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('69', 'FMS-4#机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('70', 'FMS-4#机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('71', 'FMS-4#机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('72', 'FMS-5#机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('73', 'FMS-5#机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('74', 'FMS-5#机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('75', 'FMS-5#机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('76', 'FMS-5#机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('77', 'FMS-5#机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('78', 'FMS-5#机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('79', 'FMS-5#机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('80', 'FMS-5#机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('81', 'FMS-5#机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('93', 'FMS-5#机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('94', 'FMS-5#机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('95', 'FMS-5#机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('96', 'FMS-5#机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('97', 'FMS-5#机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('98', 'FMS-6#机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('99', 'FMS-6#机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('100', 'FMS-6#机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('101', 'FMS-6#机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('102', 'FMS-6#机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('103', '桁 架 #1号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('104', '桁 架 #1号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('105', '桁 架 #1号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('106', '桁 架 #1号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('107', '桁 架 #1号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('108', '桁 架 #1号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('109', '桁 架 #1号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('110', '桁 架 #1号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('111', '桁 架 #1号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('112', '桁 架 #1号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('113', '惠乐喜乐 #1号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('114', '惠乐喜乐 #1号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('115', '惠乐喜乐 #1号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('116', '惠乐喜乐 #1号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('117', '惠乐喜乐 #1号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('118', '惠乐喜乐 #1号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('119', '惠乐喜乐 #1号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('120', '惠乐喜乐 #1号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('121', '惠乐喜乐 #1号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('122', '惠乐喜乐 #1号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('123', '惠乐喜乐 #2号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('124', '惠乐喜乐 #2号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('125', '惠乐喜乐 #2号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('126', '惠乐喜乐 #2号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('127', '惠乐喜乐 #2号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('128', '惠乐喜乐 #2号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('129', '惠乐喜乐 #2号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('130', '惠乐喜乐 #2号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('131', '惠乐喜乐 #2号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('132', '惠乐喜乐 #2号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('133', '惠乐喜乐 #2号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('134', '惠乐喜乐 #2号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('135', '惠乐喜乐 #2号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('136', '惠乐喜乐 #2号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('137', '惠乐喜乐 #2号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('138', '惠乐喜乐 #2号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('139', '惠乐喜乐 #2号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('140', '惠乐喜乐 #2号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('141', '惠乐喜乐 #2号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('142', '惠乐喜乐 #2号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('143', '惠乐喜乐 #3号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('144', '惠乐喜乐 #3号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('145', '惠乐喜乐 #3号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('146', '惠乐喜乐 #3号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('147', '惠乐喜乐 #3号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('148', '惠乐喜乐 #3号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('149', '惠乐喜乐 #3号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('150', '惠乐喜乐 #3号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('151', '惠乐喜乐 #3号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('152', '惠乐喜乐 #3号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('153', '惠乐喜乐 #3号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('154', '惠乐喜乐 #3号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('155', '惠乐喜乐 #3号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('156', '惠乐喜乐 #3号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('157', '惠乐喜乐 #3号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('158', '惠乐喜乐 #3号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('159', '惠乐喜乐 #3号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('160', '惠乐喜乐 #3号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('161', '惠乐喜乐 #3号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('162', '惠乐喜乐 #3号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('163', '惠乐喜乐 #4号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('164', '惠乐喜乐 #4号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('165', '惠乐喜乐 #4号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('166', '惠乐喜乐 #4号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('167', '惠乐喜乐 #4号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('168', '惠乐喜乐 #4号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('169', '惠乐喜乐 #4号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('170', '惠乐喜乐 #4号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('171', '惠乐喜乐 #4号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('172', '惠乐喜乐 #4号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('173', '惠乐喜乐 #4号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('174', '惠乐喜乐 #4号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('175', '惠乐喜乐 #4号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('176', '惠乐喜乐 #4号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('177', '惠乐喜乐 #4号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('178', '惠乐喜乐 #4号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('179', '惠乐喜乐 #4号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('180', '惠乐喜乐 #4号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('181', '惠乐喜乐 #4号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('182', '惠乐喜乐 #4号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('183', '惠乐喜乐 #5号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('184', '惠乐喜乐 #5号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('185', '惠乐喜乐 #5号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('186', '惠乐喜乐 #5号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('187', '惠乐喜乐 #5号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('188', '惠乐喜乐 #5号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('189', '惠乐喜乐 #5号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('190', '惠乐喜乐 #5号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('191', '惠乐喜乐 #5号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('192', '惠乐喜乐 #5号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('193', '惠乐喜乐 #5号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('194', '惠乐喜乐 #5号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('195', '惠乐喜乐 #5号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('196', '惠乐喜乐 #5号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('197', '惠乐喜乐 #5号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('198', '惠乐喜乐 #5号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('199', '惠乐喜乐 #5号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('200', '惠乐喜乐 #5号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('201', '惠乐喜乐 #5号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('202', '惠乐喜乐 #5号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('203', '惠乐喜乐 #6号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('204', '惠乐喜乐 #6号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('205', '惠乐喜乐 #6号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('206', '惠乐喜乐 #6号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('207', '惠乐喜乐 #6号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('208', '惠乐喜乐 #6号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('209', '惠乐喜乐 #6号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('210', '惠乐喜乐 #6号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('211', '惠乐喜乐 #6号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('212', '惠乐喜乐 #6号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('213', '惠乐喜乐 #6号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('214', '惠乐喜乐 #6号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('215', '惠乐喜乐 #6号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('216', '惠乐喜乐 #6号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('217', '惠乐喜乐 #6号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('218', '惠乐喜乐 #6号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('219', '惠乐喜乐 #6号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('220', '惠乐喜乐 #6号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('221', '惠乐喜乐 #6号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('222', '惠乐喜乐 #6号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('223', '惠乐喜乐 #7号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('224', '惠乐喜乐 #7号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('225', '惠乐喜乐 #7号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('226', '惠乐喜乐 #7号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('227', '惠乐喜乐 #7号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('228', '惠乐喜乐 #7号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('229', '惠乐喜乐 #7号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('230', '惠乐喜乐 #7号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('231', '惠乐喜乐 #7号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('232', '惠乐喜乐 #7号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('233', '惠乐喜乐 #7号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('234', '惠乐喜乐 #7号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('235', '惠乐喜乐 #7号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('236', '惠乐喜乐 #7号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('237', '惠乐喜乐 #7号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('238', '惠乐喜乐 #7号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('239', '惠乐喜乐 #7号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('240', '惠乐喜乐 #7号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('241', '惠乐喜乐 #7号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('242', '惠乐喜乐 #7号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('243', '惠乐喜乐 #8号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('244', '惠乐喜乐 #8号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('245', '惠乐喜乐 #8号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('246', '惠乐喜乐 #8号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('247', '惠乐喜乐 #8号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('248', '惠乐喜乐 #8号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('249', '惠乐喜乐 #8号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('250', '惠乐喜乐 #8号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('251', '惠乐喜乐 #8号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('252', '惠乐喜乐 #8号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('253', '惠乐喜乐 #8号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('254', '惠乐喜乐 #8号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('255', '惠乐喜乐 #8号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('256', '惠乐喜乐 #8号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('257', '惠乐喜乐 #8号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('258', '惠乐喜乐 #8号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('259', '惠乐喜乐 #8号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('260', '惠乐喜乐 #8号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('261', '惠乐喜乐 #8号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('262', '惠乐喜乐 #8号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('263', '惠乐喜乐 #9号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('264', '惠乐喜乐 #9号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('265', '惠乐喜乐 #9号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('266', '惠乐喜乐 #9号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('267', '惠乐喜乐 #9号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('268', '惠乐喜乐 #9号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('269', '惠乐喜乐 #9号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('270', '惠乐喜乐 #9号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('271', '惠乐喜乐 #9号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('272', '惠乐喜乐 #9号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('273', '惠乐喜乐 #9号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('274', '惠乐喜乐 #9号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('275', '惠乐喜乐 #9号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('276', '惠乐喜乐 #9号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('277', '惠乐喜乐 #9号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('278', '惠乐喜乐 #9号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('279', '惠乐喜乐 #9号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('280', '惠乐喜乐 #9号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('281', '惠乐喜乐 #9号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('282', '惠乐喜乐 #9号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('283', '惠乐喜乐 #10号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('284', '惠乐喜乐 #10号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('285', '惠乐喜乐 #10号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('286', '惠乐喜乐 #10号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('287', '惠乐喜乐 #10号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('288', '惠乐喜乐 #10号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('289', '惠乐喜乐 #10号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('290', '惠乐喜乐 #10号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('291', '惠乐喜乐 #10号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('292', '惠乐喜乐 #10号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('293', '惠乐喜乐 #10号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('294', '惠乐喜乐 #10号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('295', '惠乐喜乐 #10号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('296', '惠乐喜乐 #10号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('297', '惠乐喜乐 #10号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('298', '惠乐喜乐 #10号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('299', '惠乐喜乐 #10号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('300', '惠乐喜乐 #10号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('301', '惠乐喜乐 #10号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('302', '惠乐喜乐 #10号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('303', '惠乐喜乐 #11号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('304', '惠乐喜乐 #11号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('305', '惠乐喜乐 #11号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('306', '惠乐喜乐 #11号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('307', '惠乐喜乐 #11号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('308', '惠乐喜乐 #11号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('309', '惠乐喜乐 #11号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('310', '惠乐喜乐 #11号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('311', '惠乐喜乐 #11号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('312', '惠乐喜乐 #11号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('313', '惠乐喜乐 #11号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('314', '惠乐喜乐 #11号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('315', '惠乐喜乐 #11号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('316', '惠乐喜乐 #11号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('317', '惠乐喜乐 #11号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('318', '惠乐喜乐 #11号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('319', '惠乐喜乐 #11号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('320', '惠乐喜乐 #11号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('321', '惠乐喜乐 #11号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('322', '惠乐喜乐 #11号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('323', '铱 镏 #1号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('324', '铱 镏 #1号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('325', '铱 镏 #1号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('326', '铱 镏 #1号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('327', '铱 镏 #1号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('328', '铱 镏 #1号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('329', '铱 镏 #1号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('330', '铱 镏 #1号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('331', '铱 镏 #1号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('332', '铱 镏 #1号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('333', '铱 镏 #1号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('334', '铱 镏 #1号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('335', '铱 镏 #1号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('336', '铱 镏 #1号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('337', '铱 镏 #1号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('338', '铱 镏 #1号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('339', '铱 镏 #1号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('340', '铱 镏 #1号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('341', '铱 镏 #1号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('342', '铱 镏 #1号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('343', '铱 镏 #1号机', 'T21');
INSERT INTO `jcdaojuku` VALUES ('344', '铱 镏 #1号机', 'T22');
INSERT INTO `jcdaojuku` VALUES ('345', '铱 镏 #1号机', 'T23');
INSERT INTO `jcdaojuku` VALUES ('346', '铱 镏 #1号机', 'T24');
INSERT INTO `jcdaojuku` VALUES ('347', '铱 镏 #1号机', 'T25');
INSERT INTO `jcdaojuku` VALUES ('348', '铱 镏 #1号机', 'T26');
INSERT INTO `jcdaojuku` VALUES ('349', '铱 镏 #1号机', 'T27');
INSERT INTO `jcdaojuku` VALUES ('350', '铱 镏 #1号机', 'T28');
INSERT INTO `jcdaojuku` VALUES ('351', '铱 镏 #1号机', 'T29');
INSERT INTO `jcdaojuku` VALUES ('352', '铱 镏 #1号机', 'T30');
INSERT INTO `jcdaojuku` VALUES ('353', '铱 镏 #1号机', 'T31');
INSERT INTO `jcdaojuku` VALUES ('354', '铱 镏 #1号机', 'T32');
INSERT INTO `jcdaojuku` VALUES ('355', '铱 镏 #1号机', 'T33');
INSERT INTO `jcdaojuku` VALUES ('356', '铱 镏 #1号机', 'T34');
INSERT INTO `jcdaojuku` VALUES ('357', '铱 镏 #1号机', 'T35');
INSERT INTO `jcdaojuku` VALUES ('358', '铱 镏 #1号机', 'T36');
INSERT INTO `jcdaojuku` VALUES ('359', '铱 镏 #1号机', 'T37');
INSERT INTO `jcdaojuku` VALUES ('360', '铱 镏 #1号机', 'T38');
INSERT INTO `jcdaojuku` VALUES ('361', '铱 镏 #1号机', 'T39');
INSERT INTO `jcdaojuku` VALUES ('362', '铱 镏 #1号机', 'T40');
INSERT INTO `jcdaojuku` VALUES ('363', '铱 镏 #1号机', 'T41');
INSERT INTO `jcdaojuku` VALUES ('364', '铱 镏 #1号机', 'T42');
INSERT INTO `jcdaojuku` VALUES ('365', '铱 镏 #1号机', 'T43');
INSERT INTO `jcdaojuku` VALUES ('366', '铱 镏 #1号机', 'T44');
INSERT INTO `jcdaojuku` VALUES ('367', '铱 镏 #1号机', 'T45');
INSERT INTO `jcdaojuku` VALUES ('368', '铱 镏 #1号机', 'T46');
INSERT INTO `jcdaojuku` VALUES ('369', '铱 镏 #1号机', 'T47');
INSERT INTO `jcdaojuku` VALUES ('370', '铱 镏 #1号机', 'T48');
INSERT INTO `jcdaojuku` VALUES ('371', '铱 镏 #1号机', 'T49');
INSERT INTO `jcdaojuku` VALUES ('372', '铱 镏 #1号机', 'T50');
INSERT INTO `jcdaojuku` VALUES ('373', '森 五 #1号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('374', '森 五 #1号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('375', '森 五 #1号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('376', '森 五 #1号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('377', '森 五 #1号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('378', '森 五 #1号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('379', '森 五 #1号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('380', '森 五 #1号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('381', '森 五 #1号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('382', '森 五 #1号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('383', '森 五 #1号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('384', '森 五 #1号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('385', '森 五 #1号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('386', '森 五 #1号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('387', '森 五 #1号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('388', '森 五 #1号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('389', '森 五 #1号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('390', '森 五 #1号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('391', '森 五 #1号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('392', '森 五 #1号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('393', '森 五 #1号机', 'T21');
INSERT INTO `jcdaojuku` VALUES ('394', '森 五 #1号机', 'T22');
INSERT INTO `jcdaojuku` VALUES ('395', '森 五 #1号机', 'T23');
INSERT INTO `jcdaojuku` VALUES ('396', '森 五 #1号机', 'T24');
INSERT INTO `jcdaojuku` VALUES ('397', '森 五 #1号机', 'T25');
INSERT INTO `jcdaojuku` VALUES ('398', '森 五 #1号机', 'T26');
INSERT INTO `jcdaojuku` VALUES ('399', '森 五 #1号机', 'T27');
INSERT INTO `jcdaojuku` VALUES ('400', '森 五 #1号机', 'T28');
INSERT INTO `jcdaojuku` VALUES ('401', '森 五 #1号机', 'T29');
INSERT INTO `jcdaojuku` VALUES ('402', '森 五 #1号机', 'T30');
INSERT INTO `jcdaojuku` VALUES ('403', '森 五 #1号机', 'T31');
INSERT INTO `jcdaojuku` VALUES ('404', '森 五 #1号机', 'T32');
INSERT INTO `jcdaojuku` VALUES ('405', '森 五 #1号机', 'T33');
INSERT INTO `jcdaojuku` VALUES ('406', '森 五 #1号机', 'T34');
INSERT INTO `jcdaojuku` VALUES ('407', '森 五 #1号机', 'T35');
INSERT INTO `jcdaojuku` VALUES ('408', '森 五 #1号机', 'T36');
INSERT INTO `jcdaojuku` VALUES ('409', '森 五 #1号机', 'T37');
INSERT INTO `jcdaojuku` VALUES ('410', '森 五 #1号机', 'T38');
INSERT INTO `jcdaojuku` VALUES ('411', '森 五 #1号机', 'T39');
INSERT INTO `jcdaojuku` VALUES ('412', '森 五 #1号机', 'T40');
INSERT INTO `jcdaojuku` VALUES ('413', '森 五 #1号机', 'T41');
INSERT INTO `jcdaojuku` VALUES ('414', '森 五 #1号机', 'T42');
INSERT INTO `jcdaojuku` VALUES ('415', '森 五 #1号机', 'T43');
INSERT INTO `jcdaojuku` VALUES ('416', '森 五 #1号机', 'T44');
INSERT INTO `jcdaojuku` VALUES ('417', '森 五 #1号机', 'T45');
INSERT INTO `jcdaojuku` VALUES ('418', '森 五 #1号机', 'T46');
INSERT INTO `jcdaojuku` VALUES ('419', '森 五 #1号机', 'T47');
INSERT INTO `jcdaojuku` VALUES ('420', '森 五 #1号机', 'T48');
INSERT INTO `jcdaojuku` VALUES ('421', '森 五 #1号机', 'T49');
INSERT INTO `jcdaojuku` VALUES ('422', '森 五 #1号机', 'T50');
INSERT INTO `jcdaojuku` VALUES ('423', '北齐二 #1号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('424', '北齐二 #1号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('425', '北齐二 #1号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('426', '北齐二 #1号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('427', '北齐二 #1号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('428', '北齐二 #1号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('429', '北齐二 #1号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('430', '北齐二 #1号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('431', '北齐二 #1号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('432', '北齐二 #1号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('433', '北齐二 #1号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('434', '北齐二 #1号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('435', '北齐二 #1号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('436', '北齐二 #1号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('437', '北齐二 #1号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('438', '北齐二 #1号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('439', '北齐二 #1号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('440', '北齐二 #1号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('441', '北齐二 #1号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('442', '北齐二 #1号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('443', '东 BW #1号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('444', '东 BW #1号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('445', '东 BW #1号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('446', '东 BW #1号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('447', '东 BW #1号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('448', '东 BW #1号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('449', '东 BW #1号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('450', '东 BW #1号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('451', '东 BW #1号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('452', '东 BW #1号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('453', '东 BW #1号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('454', '东 BW #1号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('455', '东 BW #1号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('456', '东 BW #1号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('457', '东 BW #1号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('458', '东 BW #1号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('459', '东 BW #1号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('460', '东 BW #1号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('461', '东 BW #1号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('462', '东 BW #1号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('463', '西 BW #1号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('464', '西 BW #1号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('465', '西 BW #1号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('466', '西 BW #1号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('467', '西 BW #1号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('468', '西 BW #1号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('469', '西 BW #1号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('470', '西 BW #1号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('471', '西 BW #1号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('472', '西 BW #1号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('473', '西 BW #1号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('474', '西 BW #1号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('475', '西 BW #1号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('476', '西 BW #1号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('477', '西 BW #1号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('478', '西 BW #1号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('479', '西 BW #1号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('480', '西 BW #1号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('481', '西 BW #1号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('482', '西 BW #1号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('483', '东 森 #1号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('484', '东 森 #1号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('485', '东 森 #1号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('486', '东 森 #1号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('487', '东 森 #1号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('488', '东 森 #1号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('489', '东 森 #1号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('490', '东 森 #1号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('491', '东 森 #1号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('492', '东 森 #1号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('493', '东 森 #1号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('494', '东 森 #1号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('495', '东 森 #1号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('496', '东 森 #1号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('497', '东 森 #1号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('498', '东 森 #1号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('499', '东 森 #1号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('500', '东 森 #1号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('501', '东 森 #1号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('502', '东 森 #1号机', 'T20');
INSERT INTO `jcdaojuku` VALUES ('503', '西 森 #1号机', 'T01');
INSERT INTO `jcdaojuku` VALUES ('504', '西 森 #1号机', 'T02');
INSERT INTO `jcdaojuku` VALUES ('505', '西 森 #1号机', 'T03');
INSERT INTO `jcdaojuku` VALUES ('506', '西 森 #1号机', 'T04');
INSERT INTO `jcdaojuku` VALUES ('507', '西 森 #1号机', 'T05');
INSERT INTO `jcdaojuku` VALUES ('508', '西 森 #1号机', 'T06');
INSERT INTO `jcdaojuku` VALUES ('509', '西 森 #1号机', 'T07');
INSERT INTO `jcdaojuku` VALUES ('510', '西 森 #1号机', 'T08');
INSERT INTO `jcdaojuku` VALUES ('511', '西 森 #1号机', 'T09');
INSERT INTO `jcdaojuku` VALUES ('512', '西 森 #1号机', 'T10');
INSERT INTO `jcdaojuku` VALUES ('513', '西 森 #1号机', 'T11');
INSERT INTO `jcdaojuku` VALUES ('514', '西 森 #1号机', 'T12');
INSERT INTO `jcdaojuku` VALUES ('515', '西 森 #1号机', 'T13');
INSERT INTO `jcdaojuku` VALUES ('516', '西 森 #1号机', 'T14');
INSERT INTO `jcdaojuku` VALUES ('517', '西 森 #1号机', 'T15');
INSERT INTO `jcdaojuku` VALUES ('518', '西 森 #1号机', 'T16');
INSERT INTO `jcdaojuku` VALUES ('519', '西 森 #1号机', 'T17');
INSERT INTO `jcdaojuku` VALUES ('520', '西 森 #1号机', 'T18');
INSERT INTO `jcdaojuku` VALUES ('521', '西 森 #1号机', 'T19');
INSERT INTO `jcdaojuku` VALUES ('522', '西 森 #1号机', 'T20');

-- ----------------------------
-- Table structure for `jichuang`
-- ----------------------------
DROP TABLE IF EXISTS `jichuang`;
CREATE TABLE `jichuang` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `suoshubanzu` varchar(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '所属班组',
  `shengchanxian` char(20) CHARACTER SET utf8 NOT NULL COMMENT '所属生产线',
  `jichuangbianma` char(20) CHARACTER SET utf8 NOT NULL COMMENT '机床编码',
  `jichuangleixing` char(20) CHARACTER SET utf8 DEFAULT NULL COMMENT '机床类型',
  `zichanbianhao` char(50) CHARACTER SET utf8 DEFAULT NULL COMMENT '资产编号',
  PRIMARY KEY (`xh`),
  UNIQUE KEY `jichuangbianma` (`jichuangbianma`)
) ENGINE=MyISAM AUTO_INCREMENT=38 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of jichuang
-- ----------------------------
INSERT INTO `jichuang` VALUES ('1', '机一车间_1204后箱班', '1204后箱班线', 'FMS-1#机', 'FMS', null);
INSERT INTO `jichuang` VALUES ('2', '机一车间_1204后箱班', '1204后箱班线', 'FMS-2#机', 'FMS', null);
INSERT INTO `jichuang` VALUES ('3', '机一车间_1204后箱班', '1204后箱班线', 'FMS-3#机', 'FMS', null);
INSERT INTO `jichuang` VALUES ('5', '机一车间_前托架班', '前托架班生产线', '北车床线', '北车', null);
INSERT INTO `jichuang` VALUES ('6', '机一车间_80减速器班', '80减速器班线', 'OP20T01', 'OP20', null);
INSERT INTO `jichuang` VALUES ('7', '机一车间_80减速器班', '80减速器班线', 'OP20T40', 'OP20', null);
INSERT INTO `jichuang` VALUES ('10', '机一车间_80减速器班', '80减速器班线', 'OP20T02', 'OP20', null);
INSERT INTO `jichuang` VALUES ('11', '机一车间_80减速器班', '80减速器班线', 'OP20T03', 'OP20', null);
INSERT INTO `jichuang` VALUES ('13', '机一车间_80减速器班', '80减速器班线', 'OP20T04', 'OP20', null);
INSERT INTO `jichuang` VALUES ('14', '机一车间_1204后箱班', '1204后箱班线', 'FMS-4#机', 'FMS', null);
INSERT INTO `jichuang` VALUES ('15', '机一车间_1204后箱班', '1204后箱班线', 'FMS-5#机', 'FMS', null);
INSERT INTO `jichuang` VALUES ('19', '机一车间 89减速器班', '89减速器班线', '桁 架 #1号机', '桁 架', '5899-8060');
INSERT INTO `jichuang` VALUES ('20', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #1号机', '惠乐喜乐', '5045-7108');
INSERT INTO `jichuang` VALUES ('21', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #2号机', '惠乐喜乐', '5045-7109');
INSERT INTO `jichuang` VALUES ('22', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #3号机', '惠乐喜乐', '5045-7110');
INSERT INTO `jichuang` VALUES ('23', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #4号机', '惠乐喜乐', '5045-7111');
INSERT INTO `jichuang` VALUES ('24', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #5号机', '惠乐喜乐', '5045-7112');
INSERT INTO `jichuang` VALUES ('25', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #6号机', '惠乐喜乐', '5045-7113');
INSERT INTO `jichuang` VALUES ('26', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #7号机', '惠乐喜乐', '5045-7114');
INSERT INTO `jichuang` VALUES ('27', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #8号机', '惠乐喜乐', '5045-7115');
INSERT INTO `jichuang` VALUES ('28', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #9号机', '惠乐喜乐', '5045-7116');
INSERT INTO `jichuang` VALUES ('29', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #10号机', '惠乐喜乐', '5045-7117');
INSERT INTO `jichuang` VALUES ('30', '机一车间 89减速器班', '89减速器班线', '惠乐喜乐 #11号机', '惠乐喜乐', '5045-7118');
INSERT INTO `jichuang` VALUES ('31', '机一车间_1204后箱班', '1204后箱班线', '铱 镏 #1号机', '铱 镏', '5045-7024');
INSERT INTO `jichuang` VALUES ('32', '机一车间_1204后箱班', '1204后箱班线', '森 五 #1号机', '森 五', '5045-7028');
INSERT INTO `jichuang` VALUES ('33', '机一车间_1204后箱班', '1204后箱班线', '北齐二 #1号机', '北齐二', '5068-7005');
INSERT INTO `jichuang` VALUES ('34', '机一车间_综加班', '综加班生产线', '东 BW #1号机', '东 BW', '5045-7105');
INSERT INTO `jichuang` VALUES ('35', '机一车间_综加班', '综加班生产线', '西 BW #1号机', '西 BW', '5045-7104');
INSERT INTO `jichuang` VALUES ('36', '机一车间_综加班', '综加班生产线', '东 森 #1号机', '东 森', '5045-7102');
INSERT INTO `jichuang` VALUES ('37', '机一车间_综加班', '综加班生产线', '西 森 #1号机', '西 森', '5045-7101');

-- ----------------------------
-- Table structure for `jichucanshu`
-- ----------------------------
DROP TABLE IF EXISTS `jichucanshu`;
CREATE TABLE `jichucanshu` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `csm` varchar(50) DEFAULT NULL,
  `csdm` varchar(50) NOT NULL,
  `csz` varchar(100) NOT NULL,
  `ssfm` varchar(50) NOT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=377 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of jichucanshu
-- ----------------------------
INSERT INTO `jichucanshu` VALUES ('1', '刀具轴截形刀段数量', 'p1', '5.0000', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('2', '刀具半径实际值R', 'p2', '0.5800', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('3', '刀具长度实际值L', 'p3', '120.0000', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('4', '刀尖圆弧半径R', 'p4', '2.5000', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('5', '刀具主偏角A1', 'p5', '45.0000', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('6', '刀具副偏角A2', 'p6', '15.0000', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('7', '端面跳动', 'p7', '0.0015', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('8', '径向跳动', 'p8', '0.0030', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('9', '当前工件表明粗糙度', 'p9', '10.0000', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('10', '要求工件表面粗糙度', 'p10', '11.0000', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('11', '刀具剩余寿命', 'p12', '100.0000', 'ZT-0001');
INSERT INTO `jichucanshu` VALUES ('12', '刀具轴截形刀段数量', 'p1', '6.0000', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('13', '刀具半径实际值R', 'p2', '1.2500', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('14', '刀具长度实际值L', 'p3', '135.0000', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('15', '刀尖圆弧半径R', 'p4', '3.0000', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('16', '刀具主偏角A2', 'p5', '60.0000', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('17', '刀具副偏角A3', 'p6', '30.0000', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('18', '端面跳动', 'p7', '0.0250', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('19', '径向跳动', 'p8', '0.0680', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('20', '当前工件表明粗糙度', 'p9', '5.2000', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('21', '要求工件表面粗糙度', 'p10', '5.0000', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('22', '刀具剩余寿命', 'p12', '100.0000', 'ZT-0002');
INSERT INTO `jichucanshu` VALUES ('23', '刀具材料牌号', 'jp1', 'YG3X', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('24', '刀具刀段数量', 'jp2', '3', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('25', '刀具原始寿命', 'jp3', '2000', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('26', '寿命报警阈值', 'jp4', '50', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('27', '刀尖圆弧半径R', 'jp5', '2.5', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('28', '圆弧半径上公差', 'jp6', '0.5', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('29', '圆弧半径下公差', 'jp7', '0.5', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('30', '刀具主偏角', 'jp8', '45', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('31', '刀具副偏角', 'jp9', '15', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('32', '刀具标准半径', 'jp10', '0.5', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('33', '半径上公差', 'jp11', '0.05', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('34', '半径下公差', 'jp12', '0.05', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('35', '刀具标准长度', 'jp13', '120', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('36', '长度上公差', 'jp14', '5', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('37', '长度下公差', 'jp15', '5', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('38', '端面跳动范围', 'jp16', '0.0025', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('39', '径向跳动范围', 'jp17', '0.0025', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('40', '刀具轴截形刀段数量', 'cp1', '3', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('41', '当前工件表面粗糙度', 'cp2', '80um', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('42', '要求工件表面粗糙度', 'cp3', '100um', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('43', '刀具剩余寿命', 'cp4', '1800', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('44', '刀具半径实际值R', 'cp5', '0.501', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('45', '刀具长度实际值L', 'cp6', '119.98', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('46', '刀具主偏角A1', 'cp7', '45', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('47', '刀具副偏角A2', 'cp8', '15', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('48', '刀尖圆弧半径R', 'cp9', '2.5', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('49', '端面跳动', 'cp10', '0.0015', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('50', '径向跳动', 'cp11', '0.0009', 'ZT-0003');
INSERT INTO `jichucanshu` VALUES ('51', null, 'sccj', '山高', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('52', null, 'djclph', 'YG3Z', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('53', null, 'djyssm', '2000', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('54', null, 'djytjs', '规格为10.4的钻头，170729测试保存按钮。第一次测试。', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('55', null, 'smbjyz', '50', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('56', null, 'jxtdfw', '0.0025', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('57', null, 'djfpj', '15', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('58', null, 'dmtdfw', '0.0025', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('59', null, 'yhbjxgc', '0.01', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('60', null, 'djzpj', '30', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('61', null, 'djbzbj', '1.5', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('62', null, 'yhbjsgc', '0.01', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('63', null, 'djddsl', '3', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('64', null, 'cdxgc', '0.01', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('65', null, 'bjxgc', '0.005', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('66', null, 'djyhbj', '1.2', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('67', null, 'cdsgc', '0.01', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('68', null, 'bjsgc', '0.005', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('69', null, 'djbzcd', '120', 'Φ10.4 钻头(T38)');
INSERT INTO `jichucanshu` VALUES ('70', null, 'sccj', '山高', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('71', null, 'djclph', 'YG3X', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('72', null, 'djyssm', '1000', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('73', null, 'djytjs', '规格为20.5的钻头，170729测试。', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('74', null, 'smbjyz', '30', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('75', null, 'jxtdfw', '0.0025', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('76', null, 'djfpj', '15', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('77', null, 'dmtdfw', '0.0025', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('78', null, 'yhbjxgc', '0.01', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('79', null, 'djzpj', '30', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('80', null, 'djbzbj', '1.5', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('81', null, 'yhbjsgc', '0.01', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('82', null, 'djddsl', '3', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('83', null, 'cdxgc', '0.01', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('84', null, 'bjxgc', '0.005', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('85', null, 'djyhbj', '1.2', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('86', null, 'cdsgc', '0.01', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('87', null, 'bjsgc', '0.005', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('88', null, 'djbzcd', '120', 'φ20.5 钻头(T52)');
INSERT INTO `jichucanshu` VALUES ('357', null, 'djbzcd', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('356', null, 'bjsgc', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('355', null, 'cdsgc', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('354', null, 'djyhbj', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('353', null, 'bjxgc', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('352', null, 'cdxgc', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('351', null, 'djddsl', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('130', null, 'sccj', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('131', null, 'djclph', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('132', null, 'djyssm', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('133', null, 'djytjs', '170730测试添加节点按钮', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('134', null, 'smbjyz', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('135', null, 'jxtdfw', '0.005', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('136', null, 'djfpj', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('137', null, 'dmtdfw', '0.005', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('138', null, 'yhbjxgc', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('139', null, 'djzpj', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('140', null, 'djbzbj', '2.5', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('141', null, 'yhbjsgc', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('142', null, 'djddsl', '3', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('143', null, 'cdxgc', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('144', null, 'bjxgc', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('145', null, 'djyhbj', '1.2', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('146', null, 'cdsgc', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('147', null, 'bjsgc', '', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('148', null, 'djbzcd', '50', 'φ520 钻头');
INSERT INTO `jichucanshu` VALUES ('149', null, 'sccj', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('150', null, 'djclph', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('151', null, 'djyssm', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('152', null, 'djytjs', '170730测试添加规格按钮', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('153', null, 'smbjyz', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('154', null, 'jxtdfw', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('155', null, 'djfpj', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('156', null, 'dmtdfw', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('157', null, 'yhbjxgc', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('158', null, 'djzpj', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('159', null, 'djbzbj', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('160', null, 'yhbjsgc', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('161', null, 'djddsl', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('162', null, 'cdxgc', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('163', null, 'bjxgc', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('164', null, 'djyhbj', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('165', null, 'cdsgc', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('166', null, 'bjsgc', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('167', null, 'djbzcd', '', 'φ21.2 中心钻');
INSERT INTO `jichucanshu` VALUES ('168', null, 'sccj', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('169', null, 'djclph', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('170', null, 'djyssm', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('171', null, 'djytjs', '测试添加新规格中心钻', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('172', null, 'smbjyz', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('173', null, 'jxtdfw', '0.0015', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('174', null, 'djfpj', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('175', null, 'dmtdfw', '0.002', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('176', null, 'yhbjxgc', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('177', null, 'djzpj', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('178', null, 'djbzbj', '2', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('179', null, 'yhbjsgc', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('180', null, 'djddsl', '10', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('181', null, 'cdxgc', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('182', null, 'bjxgc', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('183', null, 'djyhbj', '20', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('184', null, 'cdsgc', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('185', null, 'bjsgc', '', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('186', null, 'djbzcd', '52', 'φ520 中心钻');
INSERT INTO `jichucanshu` VALUES ('350', null, 'yhbjsgc', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('349', null, 'djbzbj', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('348', null, 'djzpj', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('347', null, 'yhbjxgc', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('346', null, 'dmtdfw', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('345', null, 'djfpj', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('344', null, 'jxtdfw', '', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('206', null, 'sccj', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('207', null, 'djclph', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('208', null, 'djyssm', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('209', null, 'djytjs', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('210', null, 'smbjyz', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('211', null, 'jxtdfw', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('212', null, 'djfpj', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('213', null, 'dmtdfw', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('214', null, 'yhbjxgc', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('215', null, 'djzpj', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('216', null, 'djbzbj', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('217', null, 'yhbjsgc', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('218', null, 'djddsl', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('219', null, 'cdxgc', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('220', null, 'bjxgc', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('221', null, 'djyhbj', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('222', null, 'cdsgc', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('223', null, 'bjsgc', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('224', null, 'djbzcd', '', 'φ520 铣槽刀');
INSERT INTO `jichucanshu` VALUES ('258', null, 'bjxgc', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('257', null, 'cdxgc', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('255', null, 'yhbjsgc', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('256', null, 'djddsl', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('254', null, 'djbzbj', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('253', null, 'djzpj', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('252', null, 'yhbjxgc', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('251', null, 'dmtdfw', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('250', null, 'djfpj', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('249', null, 'jxtdfw', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('248', null, 'smbjyz', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('247', null, 'djytjs', '170730测试添加新规格与实时刷新效果', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('244', null, 'sccj', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('245', null, 'djclph', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('246', null, 'djyssm', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('259', null, 'djyhbj', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('260', null, 'cdsgc', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('261', null, 'bjsgc', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('262', null, 'djbzcd', '', 'φ520H212 枪钻');
INSERT INTO `jichucanshu` VALUES ('343', null, 'smbjyz', '50', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('342', null, 'djytjs', '测试刀具装配', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('341', null, 'djyssm', '1000', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('340', null, 'djclph', 'YG3X', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('339', null, 'sccj', '212', 'φ16 中心钻(T117)');
INSERT INTO `jichucanshu` VALUES ('358', null, 'sccj', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('359', null, 'djclph', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('360', null, 'djyssm', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('361', null, 'djytjs', '用于测试。。。', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('362', null, 'smbjyz', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('363', null, 'jxtdfw', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('364', null, 'djfpj', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('365', null, 'dmtdfw', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('366', null, 'yhbjxgc', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('367', null, 'djzpj', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('368', null, 'djbzbj', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('369', null, 'yhbjsgc', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('370', null, 'djddsl', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('371', null, 'cdxgc', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('372', null, 'bjxgc', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('373', null, 'djyhbj', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('374', null, 'cdsgc', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('375', null, 'bjsgc', '', '212-测试刀具');
INSERT INTO `jichucanshu` VALUES ('376', null, 'djbzcd', '', '212-测试刀具');

-- ----------------------------
-- Table structure for `jichuxinxi`
-- ----------------------------
DROP TABLE IF EXISTS `jichuxinxi`;
CREATE TABLE `jichuxinxi` (
  `xh` int(10) NOT NULL AUTO_INCREMENT,
  `daojuid` char(20) CHARACTER SET utf8 NOT NULL,
  `daojuxinghao` char(20) CHARACTER SET utf8 NOT NULL,
  `daojuguige` char(20) CHARACTER SET utf8 DEFAULT NULL,
  `daojuleixing` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `daojushouming` int(10) NOT NULL,
  `weizhi` char(20) CHARACTER SET utf8 NOT NULL,
  `cengshu` char(20) CHARACTER SET utf8 NOT NULL,
  `weizhibiaoshi` char(4) CHARACTER SET utf8 NOT NULL,
  `type` char(20) CHARACTER SET utf8 NOT NULL,
  `kcsl` int(10) NOT NULL,
  `danwei` varchar(10) CHARACTER SET utf8 DEFAULT '件' COMMENT '单位',
  `zuixiaokucun` int(10) NOT NULL,
  `zuidakucun` int(10) NOT NULL,
  `beizhu` varchar(200) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=327 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of jichuxinxi
-- ----------------------------
INSERT INTO `jichuxinxi` VALUES ('252', '中心刀片', '880-040305H-C-GM 104', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('251', '切槽刀片', '327R12-2221502-GM102', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '49', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('250', '槽铣刀片', '328R13-26502-GM1025', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '42', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('249', '刀片', '490R-140408M-PM3040', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '400', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('247', '精镗刀片', 'TCMT090204-KFH13A', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('246', 'CD8804刃刀片', '880-0503W06H-P-GR404', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '27', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('245', 'CD8804刃刀片', '880-050305H-C-GR1044', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '40', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('243', 'CD8804刃刀片', '880-0303W06H-P-GR404', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '40', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('242', 'CD8804刃刀片', '880-030305H-C-GR1044', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '40', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('241', '刀片', 'TCMT090204-KFH13A', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '30', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('240', '刀片', 'TCMT060204-KFH13A', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '50', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('235', '刀片', 'TPMT110304-KF3215', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '100', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('228', '刀片', 'TCMT16T308-KM3215', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '60', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('227', '刀片', 'TCMT220408-KMH13A', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '80', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('225', '修光刀片', '345N-1305E-KW81020', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '20', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('224', '刀片', '345R-1305M-KM3220', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '250', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('223', '刀片', '490R-08T308M-KM1020', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '270', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('221', '刀片', '345N-1305E-KW81020', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '50', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('216', '刀片', 'TPMT06T104-KF3215', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('215', '周边刀片', '880-0503W05H-P-GM 40', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '20', '盒', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('214', '中心刀片', '880-050305H-C-GM  10', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('213', '107车刀片', 'TCMT110304-KFH13A', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '15', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('212', '刀片', 'CCMT060204-KM3215', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('211', '周边刀片', 'R216.2-15T308-1SM30', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('210', '中心刀片', 'R216.2-07T3SM30', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('209', '钻立铣刀', 'R216.2-025', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('207', '精镗刀片', 'TCMT090204-KFH13A', '', '', '100', '箱式 2号柜', '5层', 'S', '零部件', '40', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('206', '刀片', '490R-08T308M-PM1030', '', '', '100', '箱式 2号柜', '4层', 'S', '零部件', '50', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('205', '刀片', '490R-140408M-PM3040', '', '', '100', '箱式 2号柜', '3层', 'S', '零部件', '50', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('204', '刀片', '490R-140420M-PH3220', '', '', '100', '箱式 2号柜', '2层', 'S', '零部件', '50', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('202', '刀片', '345R-1305M-KM3220', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '100', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('201', '刀片', 'ZPMT160408LJG5041', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('200', '刀片', 'ZPMT160408RJG5040', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('199', '锪钻', '019-0201SZ', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '4', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('198', '刀片', 'CCMT09T308NNT-LT10-P', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('197', '特型钻', '019-0200SZ', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '5', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('196', '合金铰刀', '720-32', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('195', '刀片', '328R13-26502-GM1025', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '50', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('194', '加长铰刀', '021-9518SZ', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '4', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('193', '铰刀', '020-9570', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('192', '铰刀', '020-8606', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('191', '铰刀', '020-8605', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('190', '特型钻', '019-9519SZ', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('189', '扩孔钻', '010-8584', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('188', '扩孔钻', '010-8583', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('187', '刀片', 'TCMT220408KMH13A', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('186', '非标外冷钻头', 'SZ5515-8.5', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('185', '非标外冷硬钻', 'SZ5515-10.2', '', '', '100', '箱式 1号柜', '2层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('184', '锪钻', 'k012-9005', '', '', '100', '箱式 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('183', '锪钻', '012-9575A', '', '', '100', '箱式 1号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('182', '刀片', 'TPMT110304-KF', '', '', '100', '箱式 1号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('180', '刀片', 'R216.2-15T312-2SM30', '', '', '100', '箱式 1号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('179', '刀片', 'R216.2-09T3SM30', '', '', '100', '箱式 1号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('178', '过心锪钻', 'L=482Φ52', '', '', '100', '箱式 1号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('176', '刀片', '880-0303W06H-P-GR404', '', '', '100', '箱式 1号柜', '1层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('175', '刀片', '880-030305H-C-GR1044', '', '', '100', '箱式 1号柜', '1层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('174', '刀片', '331.91-5415-1  SM30', '', '', '100', '箱式 1号柜', '1层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('173', '刀片', 'TCMT16T308-KM 3215', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('170', '刀片', 'TPMT110304-KF', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('168', '刀片', '880-0303W06H-P-GR404', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('167', '刀片', '880-030305H-C-GR1044', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('166', '刀片', 'TPMT090204-KF3215', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('158', '刀片', 'R290.12T308-KM', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('157', '490铣刀刀片', '490R-08T308M-KM3040', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('153', '切槽刀片', '327R12-22 215 02-GM', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('152', '刀片', '328R13-26502-GM1025', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('151', '刀片', 'TCMT220408KMH13A', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('142', '刀片', 'R290-12T308M-KM1020', '', '', '100', 'kardex 2号柜', 'T17', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('141', '刀片', '880-0403W07H-P-GR402', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('140', '刀片', '880-040305H-GR1044', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('139', '刀片', '880-0503W08H-P-GR402', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('138', '刀片', '880-050305H-C-GR1044', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('125', '刀片', 'TPMT06T104-KF', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('124', '刀片', '880-050305H-C-GM1044', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('123', '中心刀片', '880-050305H-C-GM1044', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('122', '刀片', 'CCMT060208-KM', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('120', '槽刀', 'L=340Φ83.5×2.65', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('119', '槽刀', 'L=280Φ85×3.15', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('118', '刀片', '328R13-31502-GM1025', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('116', '整体硬质合金内冷钻', 'S5525-8.4', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('115', '硬钻', '5515-17', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('114', '硬质合金内冷铰刀', 'S5510-15F9', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('113', '硬质合金内冷钻', 'S5510-16F9', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('112', '硬质合金钻头', '5514-15', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('111', '非标直槽钻', 'SIM773-8.00', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('110', '丝锥', 'M39*2', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('109', '内冷硬质合金钻', '5511-10.7', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('108', '整体硬质合金钻', '5515-10.2', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('107', '刀片', 'P2706-3-ZK10UF', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '50', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('106', '刀片', 'SPMX12T308-75.F40M', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('105', '刀片', 'SPMX12T3AP-75.F40M', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('104', '刀片', '880-0704W06H-P-GM402', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('103', '刀片', '880-070406H-C-GM 104', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('102', '镗刀', '062-9684', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '4', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('101', '钴高速钢丝锥', '930-M10粗柄', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('100', '内冷硬质合金钻头', '5510-21', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('99', '刀片', '880-0503W05H-P-GM404', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('97', '整体硬质合金钻头', '5514-14', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('96', '刀片', 'ODEW0605APFN', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('95', '刀片', '490R-08T308M-KM', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('94', '硬钻', '5515-8.6', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('93', '周边刀片', '880-0604W06H-P-GM404', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('92', '中心刀片', '880-060406H-C-GM1044', '', '', '100', 'kardex 2号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('91', '刀片', 'TCMT090204-KF3005', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('90', '周边刀片', '880-0503W05H-P-GM404', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('89', '中心刀片', '880-050305H-C-GM1044', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('88', '刀片', 'R210-090412M-KM3220', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('87', '刀片', 'TPMT090204-KF3215', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('86', '刀片', 'CCMT060208-KM', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('84', '刀片', 'TCMT06T104-KF', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('81', '刀片', 'R245-12T3M-KM3040', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('79', '刀片', 'TCMT220408KMH13A', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('78', '刀片', 'TPMT110304-KF', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('72', '硬质合金钻铰刀', 'S5510-20R8', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('71', '硬质合金钻铰刀', 'S5510-15R8', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('70', '钻攻一体内冷螺纹铣刀', '3785-M12', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('69', '丝锥', '819-M12', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('68', '倒角钻', '477-30', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('67', '丝锥', '819-M20', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('66', '倒角钻', '477-50', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('65', '内冷硬钻', '5511-6.8', '', '', '100', 'kardex 2号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('64', '内冷硬质合金钻', '5511-17.5', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('63', '丝锥', '5550-m8', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('62', '整体硬质合金钻头', '5515-9.0', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('61', '直柄硬质合金钻', '5514-16.5', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('60', '丝锥', '040-9534', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('59', '钻头', '001-2055', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('58', '钻头', 'K001-073', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('57', '刀片', 'R290-12T308M-KM 3040', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('56', '刀片', 'CCMT060208-KM', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('55', '刀片', '880.0503.5H.C-GM', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('54', '刀片', '880.0503W05H-P-GM', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('53', '钻头', 'k001-092', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('52', '刀片', 'CNMG120408-KR 3210', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('51', '硬质合金钻绞刀', '302362461-16F9*105', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('50', '钴高速钢丝锥', '932-18.007', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('49', '直柄硬质合金钻头', '5514-8.73', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('48', '丝锥', 'K045-9004', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('47', '硬质合金内冷铰刀', 'S5510-15F9', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('46', '直柄硬质合金钻', '5514-5.00', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('45', '硬质合金内冷钻', 'S5510-25H8', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('44', '硬质合金内冷钻', 'S5510-20H8', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '3', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('43', '硬钻', '5514-15.5', '', '', '100', 'kardex 1号柜', '4层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('42', '硬质合金钻头', '5515-6.8', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('41', '非标钻铰刀', '302265497 S5515-15R8', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('40', '整体硬质合金钻', '5515-12.5', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('39', '整体硬质合金钻头', '5515-8.5', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('38', '铰刀', '020-9682', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('37', '扩孔钻', '010-6060-1', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('36', '丝锥', '5550-M10', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('34', '整体硬质合金钻', '5515-10.2', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('33', '高精度内冷钻头', '302105885-12R8', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('32', '铰刀', '302105884 12F9', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('31', '刀片', 'LNKX1506PNTN   IC410', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '30', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('30', '非标倒角刀', '85/30', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('29', '非标倒角刀', '70/30', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('28', '非标倒角刀', '64/45D', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('27', '非标倒角刀', '52/30', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('26', '刀片', 'XNGJ535ANSNGD3E', '', '', '100', 'kardex 1号柜', '3层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('25', '刀片', 'HNPJ0905ANSNGD', '', '', '100', 'kardex 1号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('24', '加长钻头', '302270595-10.8', '', '', '100', 'kardex 1号柜', '2层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('23', '刀片', 'SPMX12T308-75F40M', '', '', '100', 'kardex 1号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('22', '刀片', 'SPMX12T3AP-75F40M', '', '', '100', 'kardex 1号柜', '2层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('21', '刀片', 'WCMX06T308', '', '', '100', 'kardex 1号柜', '2层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('20', '丝锥', '040-3061', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('19', '丝锥', '040-3064', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('18', '硬质合金钻头', '5515-14.5', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('17', '硬质合金钻头', '5511-15.5', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('16', '刀片', 'MDHX1004ZDFRGD4W', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('15', '刀片', 'LNKX1506PN-NPL', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '30', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('14', '铰刀', '021-9518SZ', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('13', '扩孔钻', '019-9519SZ', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('11', '硬质合金钻', '5515-12.5', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('10', '铣刀', 'WSE40', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('9', '刀柄', 'C5-390.58-50 080', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('8', '刀片', '880-0704W06H-P-GM', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('1', 'OSG机用丝锥', 'M12*1.25非涂层', 'BT16', 'BT16', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '备注');
INSERT INTO `jichuxinxi` VALUES ('2', '锥钻', '37', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('3', '丝锥', 'M39*2', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('4', '铰刀(m)', '020-9668', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('5', '直柄硬质合金钻', '5511-19.5', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('6', 'U钻', '880-D3700C5-04', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '1', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('7', '刀片', '880-070406H-C-GM', '', '', '100', 'kardex 1号柜', '1层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('257', '刀片', 'R390-11T308M-K M 102', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '20', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('255', '中心刀片', '880-050305H-C-GM 104', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('253', '周边刀片', '880-0403W05H-P-GM 40', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('261', '刀片', 'R245-12T3M-KM3220', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('263', '刀夹', '391.68A-8-T22-A', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '2', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('270', '中心刀片', '880-060406H-C-GM 104', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('271', '周边刀片', '880-0604W06H-P-GM 40', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('272', '中心刀片', '880-070406H-C-GM 104', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('273', '周边刀片', '880-0704W06H-P-GM 40', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('274', '中心刀片', '880-080508H-C-GM 104', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('275', '周边刀片', '880-0805W08H-P-GM 40', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('276', '精镗刀片', 'TPMT110304-KF3215', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('282', '刀片', 'TCMT110308-KM3210', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('286', '精镗刀片', 'TPMT06T104-KF3215', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('287', '刀片', 'TCMT220412-KR3215', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '50', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('289', '刀片', 'TCMT16T308-KR3210', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('293', '精镗刀片', 'TCMT09T204-KF3215', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('315', '中心钻', '723 16.0(看不到）', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '47', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('316', '热涨刀柄', 'GM3004736 116.100', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '18', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('317', '冷却管', '4949 24.100', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '12', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('318', '立铣刀', '4736.120.100(看不到）', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '35', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('319', '热涨刀柄', 'HSK100A 20.00', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '43', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('320', '热胀刀柄', '4736 112.100', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '14', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('322', '引导钻', '5510 10.4', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('323', '主刀柄', 'C8-390.410-100 120A', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('324', '刀盘', 'R390-100C8-71M', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '15', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('325', '刀片', 'R390-180608M-KM', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '18', '件', '10', '99', '');
INSERT INTO `jichuxinxi` VALUES ('326', '水嘴', '5692 022-06', '', '', '100', '箱式 2号柜', '6层', 'S', '零部件', '10', '件', '10', '99', '');

-- ----------------------------
-- Table structure for `lbj_kczt`
-- ----------------------------
DROP TABLE IF EXISTS `lbj_kczt`;
CREATE TABLE `lbj_kczt` (
  `xh` int(20) NOT NULL AUTO_INCREMENT COMMENT '序号',
  `sapid` char(50) DEFAULT NULL COMMENT 'sap编号',
  `gzbh` char(50) DEFAULT NULL COMMENT '工装编号，暂用型号',
  `lbjlx` char(20) DEFAULT NULL COMMENT '零部件类型',
  `lbjgg` char(50) DEFAULT NULL COMMENT '零部件规格',
  `lbjwz` char(50) DEFAULT NULL COMMENT '零部件存储位置',
  `jtwz` char(20) DEFAULT NULL COMMENT '具体位置',
  `kcsl` int(10) DEFAULT NULL COMMENT '库存数量',
  `wzbs` char(50) DEFAULT NULL COMMENT '位置标识',
  `zdkc` int(10) DEFAULT NULL COMMENT '最大库存',
  `zxkc` int(10) DEFAULT NULL COMMENT '最小库存',
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='零部件库存状态表';

-- ----------------------------
-- Records of lbj_kczt
-- ----------------------------

-- ----------------------------
-- Table structure for `lbj_lingyong`
-- ----------------------------
DROP TABLE IF EXISTS `lbj_lingyong`;
CREATE TABLE `lbj_lingyong` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL,
  `lybz` varchar(20) DEFAULT NULL,
  `lysb` varchar(20) DEFAULT NULL,
  `lyr` varchar(20) DEFAULT NULL,
  `zjgx` char(20) DEFAULT NULL,
  `lyrq` date DEFAULT NULL,
  `beizhu` tinytext,
  `jbr` varchar(20) DEFAULT NULL,
  `djzt` int(2) NOT NULL,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `daojuchucang_ix1` (`danhao`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of lbj_lingyong
-- ----------------------------
INSERT INTO `lbj_lingyong` VALUES ('1', 'LBJLY_171017001', '先锋一班', 'FMS-1#机', '145', '245', '2017-10-17', '以旧换新。', '赵经手', '0');
INSERT INTO `lbj_lingyong` VALUES ('2', 'LBJLY_171018001', '先锋一班', 'FMS-5#机', '111', '20171018', '2017-10-18', '以旧换新。', '赵经手', '1');
INSERT INTO `lbj_lingyong` VALUES ('3', 'LBJLY_171106001', '先锋一班', 'FMS-1#机', 'Marcia', '201710-058序', '2017-11-06', '以旧换新。', '赵经手', '0');
INSERT INTO `lbj_lingyong` VALUES ('4', 'LBJLY_171108001', '先锋一班', 'FMS-1#机', '测试人员', '测试', '2017-11-08', '以旧换新。', '赵经手', '1');
INSERT INTO `lbj_lingyong` VALUES ('5', 'LBJLY_171112001', '先锋一班', 'OP20T01', '王二', '20171112', '2017-11-12', '以旧换新。', '赵经手', '0');

-- ----------------------------
-- Table structure for `lbj_lingyongmingxi`
-- ----------------------------
DROP TABLE IF EXISTS `lbj_lingyongmingxi`;
CREATE TABLE `lbj_lingyongmingxi` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL COMMENT '单号',
  `lbjmc` varchar(20) DEFAULT NULL COMMENT '零部件名称',
  `lbjgg` char(20) DEFAULT NULL COMMENT '零部件规格',
  `lbjxh` varchar(50) NOT NULL COMMENT '零部件型号',
  `djgbm` varchar(50) DEFAULT NULL COMMENT '刀具柜编码',
  `jtwz` varchar(20) DEFAULT NULL COMMENT '具体位置',
  `lysl` int(11) NOT NULL COMMENT '领用数量',
  `dw` varchar(10) DEFAULT '件' COMMENT '单位',
  `wzbs` char(10) DEFAULT 'M' COMMENT '位置标识',
  `jcbm` char(20) DEFAULT NULL COMMENT '机床编码',
  `gx` char(20) DEFAULT NULL COMMENT '工序',
  `bz` tinytext COMMENT '备注',
  PRIMARY KEY (`xh`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COMMENT='零部件领用明细表';

-- ----------------------------
-- Records of lbj_lingyongmingxi
-- ----------------------------
INSERT INTO `lbj_lingyongmingxi` VALUES ('1', 'LBJLY_171017001', '107车刀片', '', 'TCMT110304-KFH13A', '箱式 2号柜', '6层', '5', '件', 'M', 'FMS-1#机', '245', '');
INSERT INTO `lbj_lingyongmingxi` VALUES ('2', 'LBJLY_171017001', 'CD8804刃刀片', '', '880-0503W06H-P-GR404', '箱式 2号柜', '6层', '10', '件', 'M', 'FMS-1#机', '245', '');
INSERT INTO `lbj_lingyongmingxi` VALUES ('3', 'LBJLY_171018001', '中心刀片', '', '880-040305H-C-GM 104', '箱式 2号柜', '6层', '2', '件', 'M', 'FMS-5#机', '20171018', '');
INSERT INTO `lbj_lingyongmingxi` VALUES ('4', 'LBJLY_171018001', '切槽刀片', '', '327R12-2221502-GM102', '箱式 2号柜', '6层', '3', '件', 'M', 'FMS-5#机', '20171018', '');
INSERT INTO `lbj_lingyongmingxi` VALUES ('5', 'LBJLY_171018001', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '6', '件', 'M', 'FMS-5#机', '20171018', '');
INSERT INTO `lbj_lingyongmingxi` VALUES ('6', 'LBJLY_171106001', '中心刀片', '', '880-040305H-C-GM 104', '箱式 2号柜', '6层', '1', '件', 'M', 'FMS-1#机', '201710-058序', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('7', 'LBJLY_171106001', '切槽刀片', '', '327R12-2221502-GM102', '箱式 2号柜', '6层', '1', '件', 'M', 'FMS-1#机', '201710-058序', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('8', 'LBJLY_171106001', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '1', '件', 'M', 'FMS-1#机', '201710-058序', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('9', 'LBJLY_171106001', '刀片', '', '490R-140408M-PM3040', '箱式 2号柜', '6层', '1', '件', 'M', 'FMS-1#机', '201710-058序', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('10', 'LBJLY_171106001', '刀片', '', '490R-140408M-PM3040', '箱式 2号柜', '6层', '1', '件', 'M', 'FMS-1#机', '201710-058序', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('11', 'LBJLY_171106001', '精镗刀片', '', 'TCMT090204-KFH13A', '箱式 2号柜', '6层', '1', '件', 'M', 'FMS-1#机', '201710-058序', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('12', 'LBJLY_171106001', 'CD8804刃刀片', '', '880-0503W06H-P-GR404', '箱式 2号柜', '6层', '1', '件', 'M', 'FMS-1#机', '201710-058序', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('15', 'LBJLY_171108001', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '2', '件', 'M', 'FMS-1#机', '测试', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('16', 'LBJLY_171108001', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '2', '件', 'M', 'FMS-1#机', '测试', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('17', 'LBJLY_171112001', '107车刀片', '', 'TCMT110304-KFH13A', '箱式 2号柜', '6层', '2', '件', 'M', 'OP20T01', '20171112', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('18', 'LBJLY_171112001', '490铣刀刀片', '', '490R-08T308M-KM3040', 'kardex 2号柜', '2层', '5', '件', 'M', 'OP20T01', '20171112', '以旧换新。');
INSERT INTO `lbj_lingyongmingxi` VALUES ('19', 'LBJLY_171112001', 'CD8804刃刀片', '', '880-0503W06H-P-GR404', '箱式 2号柜', '6层', '1', '件', 'M', 'OP20T01', '20171112', '以旧换新。');

-- ----------------------------
-- Table structure for `lbj_liushui`
-- ----------------------------
DROP TABLE IF EXISTS `lbj_liushui`;
CREATE TABLE `lbj_liushui` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) DEFAULT NULL COMMENT '单号',
  `dhlx` varchar(10) DEFAULT NULL COMMENT '单号类型',
  `lbjmc` varchar(20) DEFAULT NULL COMMENT '零部件名称',
  `lbjgg` char(20) DEFAULT NULL COMMENT '零部件规格',
  `lbjxh` char(50) DEFAULT NULL COMMENT '零部件型号',
  `djgbm` varchar(50) DEFAULT NULL COMMENT '刀具柜编码',
  `jtwz` varchar(50) DEFAULT NULL COMMENT '具体位置',
  `zsl` int(2) DEFAULT NULL COMMENT '增加数量',
  `fsl` int(2) DEFAULT NULL COMMENT '减少数量',
  `dskykc` int(20) DEFAULT NULL COMMENT '当时可用库存数量',
  `dw` varchar(20) DEFAULT NULL COMMENT '零部件单位',
  `czsj` datetime DEFAULT NULL COMMENT '操作时间',
  `jbr` varchar(10) DEFAULT NULL COMMENT '经办人',
  `bz` varchar(50) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=129 DEFAULT CHARSET=utf8 COMMENT='零部件库存操作流水表\r\n';

-- ----------------------------
-- Records of lbj_liushui
-- ----------------------------
INSERT INTO `lbj_liushui` VALUES ('100', 'LBJLY_171017001', '零部件领用', '107车刀片', '', 'TCMT110304-KFH13A', '箱式 2号柜', '6层', '0', '5', '20', '件', '2017-10-17 22:55:44', '赵经手', '');
INSERT INTO `lbj_liushui` VALUES ('101', 'LBJLY_171017001', '零部件领用', 'CD8804刃刀片', '', '880-0503W06H-P-GR404', '箱式 2号柜', '6层', '0', '10', '40', '件', '2017-10-17 22:55:58', '赵经手', '');
INSERT INTO `lbj_liushui` VALUES ('102', 'LBJLY_171018001', '零部件领用', '中心刀片', '', '880-040305H-C-GM 104', '箱式 2号柜', '6层', '0', '2', '10', '件', '2017-10-18 14:00:17', '赵经手', '');
INSERT INTO `lbj_liushui` VALUES ('103', 'LBJLY_171018001', '零部件领用', '切槽刀片', '', '327R12-2221502-GM102', '箱式 2号柜', '6层', '0', '3', '50', '件', '2017-10-18 14:00:17', '赵经手', '');
INSERT INTO `lbj_liushui` VALUES ('104', 'LBJLY_171018001', '零部件领用', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '0', '6', '50', '件', '2017-10-18 14:00:17', '赵经手', '');
INSERT INTO `lbj_liushui` VALUES ('108', 'LBJTH_171108001', '零部件退还', '切槽刀片', '', '327R12-2221502-GM102', '箱式 2号柜', '6层', '2', '0', '47', '件', '2017-11-08 00:00:00', '赵经手', '');
INSERT INTO `lbj_liushui` VALUES ('107', 'LBJTH_171108001', '零部件退还', '中心刀片', '', '880-040305H-C-GM 104', '箱式 2号柜', '6层', '1', '0', '8', '件', '2017-11-08 00:00:00', '赵经手', '');
INSERT INTO `lbj_liushui` VALUES ('109', 'LBJLY_171108001', '零部件领用', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '0', '2', '44', '件', '2017-11-08 16:19:36', '赵经手', '以旧换新。');
INSERT INTO `lbj_liushui` VALUES ('110', 'LBJLY_171108001', '零部件领用', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '0', '2', '44', '件', '2017-11-08 16:19:36', '赵经手', '以旧换新。');
INSERT INTO `lbj_liushui` VALUES ('111', 'LBJTH_171108003', '零部件退还', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '2', '0', '40', '件', '2017-11-08 16:19:56', '赵经手', '');
INSERT INTO `lbj_liushui` VALUES ('112', '', '库存修改', '中心刀片', '', '880-040305H-C-GM 104', '箱式 2号柜', '6层', '1', '0', '9', '件', '2017-11-08 19:21:30', '赵一', '');
INSERT INTO `lbj_liushui` VALUES ('113', '', '库存修改', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '0', '1', '42', '件', '2017-11-08 19:24:03', '赵一', '');
INSERT INTO `lbj_liushui` VALUES ('114', '', '库存修改', '槽铣刀片', '', '328R13-26502-GM1025', '箱式 2号柜', '6层', '1', '0', '41', '件', '2017-11-08 19:31:10', '赵一', '');
INSERT INTO `lbj_liushui` VALUES ('115', '', '库存修改', 'CD8804刃刀片', '', '880-0503W06H-P-GR404', '箱式 2号柜', '6层', '0', '2', '30', '件', '2017-11-08 19:33:32', '赵一', '测试刷新按钮');
INSERT INTO `lbj_liushui` VALUES ('116', '', '库存修改', 'CD8804刃刀片', '', '880-0503W06H-P-GR404', '箱式 2号柜', '6层', '0', '1', '28', '件', '2017-11-08 19:36:22', '赵一', '');
INSERT INTO `lbj_liushui` VALUES ('117', null, '装配领用', '冷却管', '', '4949 24.100', null, null, '0', '1', null, null, '2017-11-20 14:17:23', null, null);
INSERT INTO `lbj_liushui` VALUES ('118', null, '装配领用', '热胀刀柄', '', '4736 112.100', null, null, '0', '1', null, null, '2017-11-20 14:17:23', null, null);
INSERT INTO `lbj_liushui` VALUES ('119', null, '装配领用', '引导钻', '', '5510 10.4', null, null, '0', '1', null, null, '2017-11-20 14:17:24', null, null);
INSERT INTO `lbj_liushui` VALUES ('120', null, '装配领用', '冷却管', '', '4949 24.100', '箱式 2号柜', '6层', '0', '1', '11', '个', '2017-11-20 14:43:49', null, null);
INSERT INTO `lbj_liushui` VALUES ('121', null, '装配领用', '热胀刀柄', '', '4736 112.100', '箱式 2号柜', '6层', '0', '1', '13', '个', '2017-11-20 14:43:49', null, null);
INSERT INTO `lbj_liushui` VALUES ('122', null, '装配领用', '引导钻', '', '5510 10.4', '箱式 2号柜', '6层', '0', '1', '9', '个', '2017-11-20 14:43:49', null, null);
INSERT INTO `lbj_liushui` VALUES ('123', null, '拆卸退还', '冷却管', '', '4949 24.100', '箱式 2号柜', '6层', '1', '0', '10', '个', '2017-11-20 14:54:32', null, 'ZT-0016');
INSERT INTO `lbj_liushui` VALUES ('124', null, '拆卸退还', '热胀刀柄', '', '4736 112.100', '箱式 2号柜', '6层', '1', '0', '12', '个', '2017-11-20 14:54:32', null, 'ZT-0016');
INSERT INTO `lbj_liushui` VALUES ('125', null, '拆卸退还', '引导钻', '', '5510 10.4', '箱式 2号柜', '6层', '1', '0', '8', '个', '2017-11-20 14:54:32', null, 'ZT-0016');
INSERT INTO `lbj_liushui` VALUES ('126', null, '拆卸退还', '冷却管', '', '4949 24.100', '箱式 2号柜', '6层', '1', '0', '11', '个', '2017-11-20 14:55:47', null, 'ZT-0015');
INSERT INTO `lbj_liushui` VALUES ('127', null, '拆卸退还', '热胀刀柄', '', '4736 112.100', '箱式 2号柜', '6层', '1', '0', '13', '个', '2017-11-20 14:55:47', null, 'ZT-0015');
INSERT INTO `lbj_liushui` VALUES ('128', null, '拆卸退还', '引导钻', '', '5510 10.4', '箱式 2号柜', '6层', '1', '0', '9', '个', '2017-11-20 14:55:47', null, 'ZT-0015');

-- ----------------------------
-- Table structure for `lbj_temp`
-- ----------------------------
DROP TABLE IF EXISTS `lbj_temp`;
CREATE TABLE `lbj_temp` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `lbjmc` varchar(20) NOT NULL,
  `lbjxh` char(50) NOT NULL,
  `lbjgg` varchar(50) DEFAULT NULL,
  `dw` varchar(10) DEFAULT NULL,
  `dj` decimal(10,2) DEFAULT NULL,
  `sl` int(20) DEFAULT NULL,
  `img` char(100) DEFAULT NULL,
  `bz` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=327 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of lbj_temp
-- ----------------------------
INSERT INTO `lbj_temp` VALUES ('1', 'OSG机用丝锥', 'M12*1.25非涂层', '', '件', '197.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('2', '锥钻', '37', '', '件', '324.87', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('3', '丝锥', 'M39*2', '', '件', '158.34', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('4', '铰刀(m)', '020-9668', '', '件', '105.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('5', '直柄硬质合金钻', '5511-19.5', '', '件', '2641.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('6', 'U钻', '880-D3700C5-04', '', '件', '5015.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('7', '刀片', '880-070406H-C-GM', '', '件', '110.25', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('8', '刀片', '880-0704W06H-P-GM', '', '件', '110.25', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('9', '刀柄', 'C5-390.58-50 080', '', '件', '2278.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('10', '铣刀', 'WSE40', '', '件', '412.16', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('11', '硬质合金钻', '5515-12.5', '', '件', '676.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('12', '刀片', 'LNKX1506PN-NPL', '', '件', '105.86', '30', null, null);
INSERT INTO `lbj_temp` VALUES ('13', '扩孔钻', '019-9519SZ', '', '件', '780.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('14', '铰刀', '021-9518SZ', '', '件', '780.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('15', '刀片', 'LNKX1506PN-NPL', '', '件', '105.86', '30', null, null);
INSERT INTO `lbj_temp` VALUES ('16', '刀片', 'MDHX1004ZDFRGD4W', '', '件', '90.00', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('17', '硬质合金钻头', '5511-15.5', '', '件', '1620.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('18', '硬质合金钻头', '5515-14.5', '', '件', '950.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('19', '丝锥', '040-3064', '', '件', '14.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('20', '丝锥', '040-3061', '', '件', '18.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('21', '刀片', 'WCMX06T308', '', '件', '28.50', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('22', '刀片', 'SPMX12T3AP-75F40M', '', '件', '83.30', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('23', '刀片', 'SPMX12T308-75F40M', '', '件', '83.30', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('24', '加长钻头', '302270595-10.8', '', '件', '1588.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('25', '刀片', 'HNPJ0905ANSNGD', '', '件', '110.00', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('26', '刀片', 'XNGJ535ANSNGD3E', '', '件', '120.00', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('27', '非标倒角刀', '52/30', '', '件', '769.23', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('28', '非标倒角刀', '64/45D', '', '件', '854.70', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('29', '非标倒角刀', '70/30', '', '件', '854.70', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('30', '非标倒角刀', '85/30', '', '件', '940.17', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('31', '刀片', 'LNKX1506PNTN   IC4100', '', '件', '120.66', '30', null, null);
INSERT INTO `lbj_temp` VALUES ('32', '铰刀', '302105884 12F9', '', '件', '1152.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('33', '高精度内冷钻头', '302105885-12R8', '', '件', '1152.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('34', '整体硬质合金钻', '5515-10.2', '', '件', '460.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('35', '整体硬质合金钻头', '5515-8.5', '', '件', '356.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('36', '丝锥', '5550-M10', '', '件', '123.33', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('37', '扩孔钻', '010-6060-1', '', '件', '29.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('38', '铰刀', '020-9682', '', '件', '106.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('39', '整体硬质合金钻头', '5515-8.5', '', '件', '356.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('40', '整体硬质合金钻', '5515-12.5', '', '件', '676.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('41', '非标钻铰刀', '302265497 S5515-15R8', '', '件', '1625.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('42', '硬质合金钻头', '5515-6.8', '', '件', '327.18', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('43', '硬钻', '5514-15.5', '', '件', '890.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('44', '硬质合金内冷钻', 'S5510-20H8', '', '件', '2490.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('45', '硬质合金内冷钻', 'S5510-25H8', '', '件', '2960.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('46', '直柄硬质合金钻', '5514-5.00', '', '件', '302.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('47', '硬质合金内冷铰刀', 'S5510-15F9', '', '件', '1625.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('48', '丝锥', 'K045-9004', '', '件', '34.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('49', '直柄硬质合金钻头', '5514-8.73', '', '件', '265.60', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('50', '钴高速钢丝锥', '932-18.007', '', '件', '676.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('51', '硬质合金钻绞刀', '302362461-16F9*105', '', '件', '1625.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('52', '刀片', 'CNMG120408-KR 3210', '', '件', '74.17', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('53', '钻头', 'k001-092', '', '件', '38.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('54', '刀片', '880.0503W05H-P-GM', '', '件', '93.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('55', '刀片', '880.0503.5H.C-GM', '', '件', '91.38', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('56', '刀片', 'CCMT060208-KM', '', '件', '41.96', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('57', '刀片', 'R290-12T308M-KM 3040', '', '件', '78.00', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('58', '钻头', 'K001-073', '', '件', '52.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('59', '钻头', '001-2055', '', '件', '41.28', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('60', '丝锥', '040-9534', '', '件', '30.93', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('61', '直柄硬质合金钻', '5514-16.5', '', '件', '1184.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('62', '整体硬质合金钻头', '5515-9.0', '', '件', '375.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('63', '丝锥', '5550-m8', '', '件', '107.83', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('64', '内冷硬质合金钻', '5511-17.5', '', '件', '2350.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('65', '内冷硬钻', '5511-6.8', '', '件', '526.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('66', '倒角钻', '477-50', '', '件', '676.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('67', '丝锥', '819-M20', '', '件', '491.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('68', '倒角钻', '477-30', '', '件', '357.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('69', '丝锥', '819-M12', '', '件', '218.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('70', '钻攻一体内冷螺纹铣刀', '3785-M12', '', '件', '4185.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('71', '硬质合金钻铰刀', 'S5510-15R8', '', '件', '1625.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('72', '硬质合金钻铰刀', 'S5510-20R8', '', '件', '2490.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('73', '刀片', 'TPMT110304-KF', '', '件', '58.55', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('74', '刀片', 'TPMT110304-KF', '', '件', '58.55', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('75', '刀片', 'TPMT110304-KF', '', '件', '58.55', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('76', '刀片', 'TPMT110304-KF', '', '件', '58.55', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('77', '刀片', 'TPMT110304-KF', '', '件', '58.55', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('78', '刀片', 'TPMT110304-KF', '', '件', '58.55', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('79', '刀片', 'TCMT220408KMH13A', '', '件', '74.20', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('80', '刀片', 'R245-12T3M-KM3040', '', '件', '82.00', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('81', '刀片', 'R245-12T3M-KM3040', '', '件', '82.00', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('82', '刀片', 'TCMT06T104-KF', '', '件', '42.82', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('83', '刀片', 'TCMT06T104-KF', '', '件', '42.82', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('84', '刀片', 'TCMT06T104-KF', '', '件', '42.82', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('85', '刀片', 'CCMT060208-KM', '', '件', '41.96', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('86', '刀片', 'CCMT060208-KM', '', '件', '41.96', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('87', '刀片', 'TPMT090204-KF3215', '', '件', '45.85', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('88', '刀片', 'R210-090412M-KM3220', '', '件', '75.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('89', '中心刀片', '880-050305H-C-GM1044', '', '件', '93.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('90', '周边刀片', '880-0503W05H-P-GM4044', '', '件', '93.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('91', '刀片', 'TCMT090204-KF3005', '', '件', '44.32', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('92', '中心刀片', '880-060406H-C-GM1044', '', '件', '102.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('93', '周边刀片', '880-0604W06H-P-GM4044', '', '件', '102.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('94', '硬钻', '5515-8.6', '', '件', '361.57', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('95', '刀片', '490R-08T308M-KM', '', '件', '129.00', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('96', '刀片', 'ODEW0605APFN', '', '件', '118.20', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('97', '整体硬质合金钻头', '5514-14', '', '件', '601.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('98', '刀片', '880-050305H-C-GM1044', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('99', '刀片', '880-0503W05H-P-GM4044', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('100', '内冷硬质合金钻头', '5510-21', '', '件', '2808.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('101', '钴高速钢丝锥', '930-M10粗柄', '', '件', '253.50', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('102', '镗刀', '062-9684', '', '件', '14.00', '4', null, null);
INSERT INTO `lbj_temp` VALUES ('103', '刀片', '880-070406H-C-GM 1044', '', '件', '110.25', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('104', '刀片', '880-0704W06H-P-GM4024', '', '件', '110.25', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('105', '刀片', 'SPMX12T3AP-75.F40M', '', '件', '83.30', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('106', '刀片', 'SPMX12T308-75.F40M', '', '件', '83.30', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('107', '刀片', 'P2706-3-ZK10UF', '', '件', '23.40', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('108', '整体硬质合金钻', '5515-10.2', '', '件', '460.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('109', '内冷硬质合金钻', '5511-10.7', '', '件', '793.28', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('110', '丝锥', 'M39*2', '', '件', '158.34', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('111', '非标直槽钻', 'SIM773-8.00', '', '件', '1586.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('112', '硬质合金钻头', '5514-15', '', '件', '890.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('113', '硬质合金内冷钻', 'S5510-16F9', '', '件', '1520.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('114', '硬质合金内冷铰刀', 'S5510-15F9', '', '件', '1625.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('115', '硬钻', '5515-17', '', '件', '1287.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('116', '整体硬质合金内冷钻', 'S5525-8.4', '', '件', '2548.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('117', '刀片', '328R13-26502-GM1025', '', '件', '253.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('118', '刀片', '328R13-31502-GM1025', '', '件', '253.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('119', '槽刀', 'L=280Φ85×3.15', '', '件', '10498.25', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('120', '槽刀', 'L=340Φ83.5×2.65', '', '件', '31024.30', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('121', '刀片', 'TPMT090204-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('122', '刀片', 'CCMT060208-KM', '', '件', '41.96', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('123', '中心刀片', '880-050305H-C-GM1044', '', '件', '93.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('124', '刀片', '880-050305H-C-GM1044', '', '件', '93.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('125', '刀片', 'TPMT06T104-KF', '', '件', '40.46', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('126', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('127', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('128', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('129', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('130', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('131', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('132', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('133', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('134', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('135', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('136', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('137', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('138', '刀片', '880-050305H-C-GR1044', '', '件', '100.00', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('139', '刀片', '880-0503W08H-P-GR4024', '', '件', '100.00', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('140', '刀片', '880-040305H-GR1044', '', '件', '89.60', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('141', '刀片', '880-0403W07H-P-GR4024', '', '件', '89.60', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('142', '刀片', 'R290-12T308M-KM1020', '', '件', '84.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('143', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('144', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('145', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('146', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('147', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('148', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('149', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('150', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('151', '刀片', 'TCMT220408KMH13A', '', '件', '72.90', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('152', '刀片', '328R13-26502-GM1025', '', '件', '253.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('153', '切槽刀片', '327R12-22 215 02-GM 1025', '', '件', '280.50', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('154', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '30', null, null);
INSERT INTO `lbj_temp` VALUES ('155', '刀片', 'TPMT090204-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('156', '刀片', 'TPMT090204-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('157', '490铣刀刀片', '490R-08T308M-KM3040', '', '件', '103.70', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('158', '刀片', 'R290.12T308-KM', '', '件', '63.35', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('159', '刀片', 'TPMT110304-KF', '', '件', '46.48', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('160', '刀片', 'TPMT110304-KF', '', '件', '46.48', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('161', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('162', '刀片', 'TPMT110304-KF', '', '件', '46.48', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('163', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('164', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('165', '刀片', 'TPMT090204-KF3215', '', '件', '58.27', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('166', '刀片', 'TPMT090204-KF3215', '', '件', '58.27', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('167', '刀片', '880-030305H-C-GR1044', '', '件', '89.60', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('168', '刀片', '880-0303W06H-P-GR4044', '', '件', '89.60', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('169', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('170', '刀片', 'TPMT110304-KF', '', '件', '46.48', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('171', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '30', null, null);
INSERT INTO `lbj_temp` VALUES ('172', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('173', '刀片', 'TCMT16T308-KM 3215', '', '件', '72.67', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('174', '刀片', '331.91-5415-1  SM30', '', '件', '146.25', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('175', '刀片', '880-030305H-C-GR1044', '', '件', '89.60', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('176', '刀片', '880-0303W06H-P-GR4044', '', '件', '89.60', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('177', '刀片', 'TPMT110304-KF', '', '件', '46.48', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('178', '过心锪钻', 'L=482Φ52', '', '件', '8000.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('179', '刀片', 'R216.2-09T3SM30', '', '件', '124.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('180', '刀片', 'R216.2-15T312-2SM30', '', '件', '66.45', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('181', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('182', '刀片', 'TPMT110304-KF', '', '件', '46.48', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('183', '锪钻', '012-9575A', '', '件', '500.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('184', '锪钻', 'k012-9005', '', '件', '85.50', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('185', '非标外冷硬钻', 'SZ5515-10.2', '', '件', '1082.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('186', '非标外冷钻头', 'SZ5515-8.5', '', '件', '780.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('187', '刀片', 'TCMT220408KMH13A', '', '件', '73.27', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('188', '扩孔钻', '010-8583', '', '件', '560.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('189', '扩孔钻', '010-8584', '', '件', '590.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('190', '特型钻', '019-9519SZ', '', '件', '780.00', '3', null, null);
INSERT INTO `lbj_temp` VALUES ('191', '铰刀', '020-8605', '', '件', '560.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('192', '铰刀', '020-8606', '', '件', '580.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('193', '铰刀', '020-9570', '', '件', '645.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('194', '加长铰刀', '021-9518SZ', '', '件', '780.00', '4', null, null);
INSERT INTO `lbj_temp` VALUES ('195', '刀片', '328R13-26502-GM1025', '', '件', '253.50', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('196', '合金铰刀', '720-32', '', '件', '1297.00', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('197', '特型钻', '019-0200SZ', '', '件', '110.00', '5', null, null);
INSERT INTO `lbj_temp` VALUES ('198', '刀片', 'CCMT09T308NNT-LT10-PVD', '', '件', '33.93', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('199', '锪钻', '019-0201SZ', '', '件', '110.00', '4', null, null);
INSERT INTO `lbj_temp` VALUES ('200', '刀片', 'ZPMT160408RJG5040', '', '件', '61.00', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('201', '刀片', 'ZPMT160408LJG5041', '', '件', '61.00', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('202', '刀片', '345R-1305M-KM3220', '', '片', '141.00', '100', null, null);
INSERT INTO `lbj_temp` VALUES ('203', '刀片', '345N-1305E-KW81020', '', '片', '166.40', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('204', '刀片', '490R-140420M-PH3220', '', '片', '138.00', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('205', '刀片', '490R-140408M-PM3040', '', '片', '128.00', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('206', '刀片', '490R-08T308M-PM1030', '', '片', '131.00', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('207', '精镗刀片', 'TCMT090204-KFH13A', '', '片', '37.68', '40', null, null);
INSERT INTO `lbj_temp` VALUES ('208', '刀片', '490R-08T308M-KM1020', '', '片', '129.00', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('209', '钻立铣刀', 'R216.2-025', '', '件', '2235.00', '1', null, null);
INSERT INTO `lbj_temp` VALUES ('210', '中心刀片', 'R216.2-07T3SM30', '', '片', '100.80', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('211', '周边刀片', 'R216.2-15T308-1SM30', '', '片', '54.46', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('212', '刀片', 'CCMT060204-KM3215', '', '片', '54.56', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('213', '107车刀片', 'TCMT110304-KFH13A', '', '片', '42.30', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('214', '中心刀片', '880-050305H-C-GM  1044', '', '片', '93.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('215', '周边刀片', '880-0503W05H-P-GM 4044', '', '片', '93.75', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('216', '刀片', 'TPMT06T104-KF3215', '', '件', '45.85', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('217', '刀片', '345R-1305M-KM3220', '', '件', '141.00', '100', null, null);
INSERT INTO `lbj_temp` VALUES ('218', '刀片', '345N-1305E-KW81020', '', '件', '166.40', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('219', '刀片', 'TCMT090204-KFH13A', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('220', '刀片', 'TCMT060204-KFH13A', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('221', '刀片', '345N-1305E-KW81020', '', '件', '166.40', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('222', '刀片', '345R-1305M-KM3220', '', '件', '141.00', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('223', '刀片', '490R-08T308M-KM1020', '', '件', '129.00', '200', null, null);
INSERT INTO `lbj_temp` VALUES ('224', '刀片', '345R-1305M-KM3220', '', '件', '141.00', '100', null, null);
INSERT INTO `lbj_temp` VALUES ('225', '修光刀片', '345N-1305E-KW81020', '', '件', '166.40', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('226', '刀片', 'TCMT16T308-KM3215', '', '件', '72.67', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('227', '刀片', 'TCMT220408-KMH13A', '', '件', '74.20', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('228', '刀片', 'TCMT16T308-KM3215', '', '件', '72.67', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('229', '刀片', '490R-140408M-PM3040', '', '件', '128.00', '100', null, null);
INSERT INTO `lbj_temp` VALUES ('230', '刀片', '490R-140408M-PM3040', '', '件', '128.00', '100', null, null);
INSERT INTO `lbj_temp` VALUES ('231', '刀片', 'TPMT110304-KF3215', '', '件', '58.27', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('232', '刀片', 'TPMT110304-KF3215', '', '件', '58.27', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('233', '刀片', 'TPMT110304-KF3215', '', '件', '58.27', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('234', '刀片', 'TPMT110304-KF3215', '', '件', '58.27', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('235', '刀片', 'TPMT110304-KF3215', '', '件', '58.27', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('236', '刀片', 'TCMT090204-KFH13A', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('237', '刀片', 'TCMT060204-KFH13A', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('238', '刀片', 'TCMT060204-KFH13A', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('239', '刀片', 'TCMT060204-KFH13A', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('240', '刀片', 'TCMT060204-KFH13A', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('241', '刀片', 'TCMT090204-KFH13A', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('242', 'CD8804刃刀片', '880-030305H-C-GR1044', '', '件', '89.60', '40', null, null);
INSERT INTO `lbj_temp` VALUES ('243', 'CD8804刃刀片', '880-0303W06H-P-GR4044', '', '件', '89.60', '40', null, null);
INSERT INTO `lbj_temp` VALUES ('244', '精镗刀片', 'TCMT090204-KFH13A', '', '件', '37.68', '40', null, null);
INSERT INTO `lbj_temp` VALUES ('245', 'CD8804刃刀片', '880-050305H-C-GR1044', '', '件', '100.00', '40', null, null);
INSERT INTO `lbj_temp` VALUES ('246', 'CD8804刃刀片', '880-0503W06H-P-GR4044', '', '件', '100.00', '40', null, null);
INSERT INTO `lbj_temp` VALUES ('247', '精镗刀片', 'TCMT090204-KFH13A', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('248', '刀片', '490R-140408M-PM3040', '', '件', '128.00', '100', null, null);
INSERT INTO `lbj_temp` VALUES ('249', '刀片', '490R-140408M-PM3040', '', '件', '128.00', '100', null, null);
INSERT INTO `lbj_temp` VALUES ('250', '槽铣刀片', '328R13-26502-GM1025', '', '件', '253.50', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('251', '切槽刀片', '327R12-2221502-GM1025', '', '件', '280.50', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('252', '中心刀片', '880-040305H-C-GM 1044', '', '件', '82.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('253', '周边刀片', '880-0403W05H-P-GM 4024', '', '件', '82.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('254', '刀片', 'R390-11T308M-K M 1020', '', '件', '92.25', '100', null, null);
INSERT INTO `lbj_temp` VALUES ('255', '中心刀片', '880-050305H-C-GM 1044', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('256', '周边刀片', '880-0503W05H-P-GM 4024', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('257', '刀片', 'R390-11T308M-K M 1020', '', '件', '92.25', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('258', '刀片', 'TCMT220408-KMH13A', '', '件', '74.20', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('259', '刀片', 'TCMT220408-KMH13A', '', '件', '74.20', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('260', '刀片', 'TCMT220408-KMH13A', '', '件', '74.20', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('261', '刀片', 'R245-12T3M-KM3220', '', '件', '84.00', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('262', '刀片', 'R245-12T3M-KM3220', '', '件', '84.00', '20', null, null);
INSERT INTO `lbj_temp` VALUES ('263', '刀夹', '391.68A-8-T22-A', '', '件', '1436.50', '2', null, null);
INSERT INTO `lbj_temp` VALUES ('264', '刀片', 'TCMT220408-KMH13A', '', '件', '74.20', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('265', '刀片', 'TCMT220408-KMH13A', '', '件', '74.20', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('266', '刀片', 'TCMT16T308-KM3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('267', '刀片', 'TCMT220408-KMH13A', '', '件', '74.20', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('268', '中心刀片', '880-050305H-C-GM 1044', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('269', '周边刀片', '880-0503W05H-P-GM 4024', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('270', '中心刀片', '880-060406H-C-GM 1044', '', '件', '102.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('271', '周边刀片', '880-0604W06H-P-GM 4024', '', '件', '102.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('272', '中心刀片', '880-070406H-C-GM 1044', '', '件', '110.25', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('273', '周边刀片', '880-0704W06H-P-GM 4024', '', '件', '110.25', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('274', '中心刀片', '880-080508H-C-GM 1044', '', '件', '120.00', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('275', '周边刀片', '880-0805W08H-P-GM 4024', '', '件', '120.00', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('276', '精镗刀片', 'TPMT110304-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('277', '精镗刀片', 'TPMT110304-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('278', '中心刀片', '880-040305H-C-GM 1044', '', '件', '82.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('279', '周边刀片', '880-0403W05H-P-GM 4024', '', '件', '82.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('280', '中心刀片', '880-060406H-C-GM 1044', '', '件', '102.75', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('281', '周边刀片', '880-0604W06H-P-GM 4024', '', '件', '102.75', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('282', '刀片', 'TCMT110308-KM3210', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('283', '刀片', 'TCMT110308-KM3210', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('284', '中心刀片', '880-050305H-C-GM 1044', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('285', '周边刀片', '880-0503W05H-P-GM 4024', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('286', '精镗刀片', 'TPMT06T104-KF3215', '', '件', '45.85', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('287', '刀片', 'TCMT220412-KR3215', '', '件', '108.80', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('288', '刀片', 'TCMT220412-KR3215', '', '件', '108.80', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('289', '刀片', 'TCMT16T308-KR3210', '', '件', '77.52', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('290', '中心刀片', '880-070406H-C-GM 1044', '', '件', '110.25', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('291', '周边刀片', '880-0704W06H-P-GM 4024', '', '件', '110.25', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('292', '刀片', '490R-08T308M-KM1020', '', '件', '129.00', '50', null, null);
INSERT INTO `lbj_temp` VALUES ('293', '精镗刀片', 'TCMT09T204-KF3215', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('294', '精镗刀片', 'TCMT09T204-KF3215', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('295', '精镗刀片', 'TCMT09T204-KF3215', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('296', '精镗刀片', 'TCMT09T204-KF3215', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('297', '精镗刀片', 'TCMT09T204-KF3215', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('298', '精镗刀片', 'TCMT09T204-KF3215', '', '件', '37.68', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('299', '刀片', 'TCMT16T308-KM3215', '', '件', '72.67', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('300', '刀片', 'TCMT220412-KR3215', '', '件', '108.80', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('301', '刀片', 'TCMT220412-KR3215', '', '件', '108.80', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('302', '刀片', 'TCMT220412-KR3215', '', '件', '108.80', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('303', '刀片', 'TCMT220412-KR3215', '', '件', '108.80', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('304', '刀片', 'TCMT220412-KR3215', '', '件', '108.80', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('305', '精镗刀片', 'TPMT110304-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('306', '精镗刀片', 'TPMT110304-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('307', '精镗刀片', 'TPMT110304-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('308', '精镗刀片', 'TPMT110304-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('309', '精镗刀片', 'TPMT110304-KF3215', '', '件', '58.27', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('310', '精镗刀片', 'TPMT06T104-KF3215', '', '件', '45.85', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('311', '中心刀片', '880-040305H-C-GM 1044', '', '件', '82.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('312', '周边刀片', '880-0403W05H-P-GM 4024', '', '件', '82.50', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('313', '中心刀片', '880-050305H-C-GM 1044', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('314', '周边刀片', '880-0503W05H-P-GM 4024', '', '件', '93.75', '10', null, null);
INSERT INTO `lbj_temp` VALUES ('315', '中心钻', '723 16.0(看不到）', null, '件', null, '47', null, null);
INSERT INTO `lbj_temp` VALUES ('316', '热涨刀柄', 'GM3004736 116.100', null, '件', null, '18', null, null);
INSERT INTO `lbj_temp` VALUES ('317', '冷却管', '4949 24.100', null, '件', null, '11', null, null);
INSERT INTO `lbj_temp` VALUES ('318', '立铣刀', '4736.120.100(看不到）', null, '个', null, '35', null, null);
INSERT INTO `lbj_temp` VALUES ('319', '热涨刀柄', 'HSK100A 20.00', null, '个', null, '43', null, null);
INSERT INTO `lbj_temp` VALUES ('320', '热胀刀柄', '4736 112.100', null, '个', null, '13', null, null);
INSERT INTO `lbj_temp` VALUES ('322', '引导钻', '5510 10.4', null, '个', null, '9', null, null);
INSERT INTO `lbj_temp` VALUES ('323', '主刀柄', 'C8-390.410-100 120A', null, '个', null, '10', null, null);
INSERT INTO `lbj_temp` VALUES ('324', '刀盘', 'R390-100C8-71M', null, '个', null, '15', null, null);
INSERT INTO `lbj_temp` VALUES ('325', '刀片', 'R390-180608M-KM', null, '个', null, '18', null, null);
INSERT INTO `lbj_temp` VALUES ('326', '水嘴', '5692 022-06', null, '个', null, '10', null, null);

-- ----------------------------
-- Table structure for `lbj_tuihuan`
-- ----------------------------
DROP TABLE IF EXISTS `lbj_tuihuan`;
CREATE TABLE `lbj_tuihuan` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL,
  `thbz` varchar(20) NOT NULL,
  `thr` varchar(10) NOT NULL,
  `thrq` date NOT NULL,
  `thyy` text,
  `jbr` varchar(10) NOT NULL,
  `jbrq` date NOT NULL,
  `djzt` int(2) DEFAULT NULL,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `danhao` (`danhao`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of lbj_tuihuan
-- ----------------------------
INSERT INTO `lbj_tuihuan` VALUES ('5', 'LBJTH_171108001', '先锋一班', 'Marcia', '2017-11-08', '机床退还。', '赵经手', '2017-11-08', '1');
INSERT INTO `lbj_tuihuan` VALUES ('6', 'LBJTH_171108002', '先锋一班', 'Marcia', '2017-11-08', '机床退还。', '赵经手', '2017-11-08', '0');
INSERT INTO `lbj_tuihuan` VALUES ('7', 'LBJTH_171108003', '先锋一班', '1548', '2017-11-08', '机床退还。', '赵经手', '2017-11-08', '1');
INSERT INTO `lbj_tuihuan` VALUES ('8', 'LBJTH_171112001', '先锋一班', '王二', '2017-11-12', '机床退还。', '赵经手', '2017-11-12', '0');

-- ----------------------------
-- Table structure for `lbj_tuihuanmingxi`
-- ----------------------------
DROP TABLE IF EXISTS `lbj_tuihuanmingxi`;
CREATE TABLE `lbj_tuihuanmingxi` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `danhao` char(20) NOT NULL,
  `lbjmc` char(20) DEFAULT NULL,
  `lbjgg` char(20) DEFAULT NULL,
  `lbjxh` varchar(50) NOT NULL,
  `sl` int(11) NOT NULL,
  `dw` varchar(10) NOT NULL,
  `jcbm` char(20) DEFAULT NULL,
  `gx` char(20) DEFAULT NULL,
  `djgbm` varchar(20) DEFAULT NULL,
  `cfwz` varchar(20) DEFAULT NULL,
  `bz` tinytext,
  PRIMARY KEY (`xh`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of lbj_tuihuanmingxi
-- ----------------------------
INSERT INTO `lbj_tuihuanmingxi` VALUES ('18', 'LBJTH_171108002', '中心刀片', '', '880-040305H-C-GM 104', '1', '件', '', '', '箱式 2号柜', '6层', '');
INSERT INTO `lbj_tuihuanmingxi` VALUES ('19', 'LBJTH_171108002', '切槽刀片', '', '327R12-2221502-GM102', '2', '件', '', '', '箱式 2号柜', '6层', '');
INSERT INTO `lbj_tuihuanmingxi` VALUES ('22', 'LBJTH_171108001', '中心刀片', '', '880-040305H-C-GM 104', '1', '件', '', '', '箱式 2号柜', '6层', '');
INSERT INTO `lbj_tuihuanmingxi` VALUES ('23', 'LBJTH_171108001', '切槽刀片', '', '327R12-2221502-GM102', '2', '件', '', '', '箱式 2号柜', '6层', '');
INSERT INTO `lbj_tuihuanmingxi` VALUES ('24', 'LBJTH_171108003', '槽铣刀片', '', '328R13-26502-GM1025', '2', '件', '', '', '箱式 2号柜', '6层', '');
INSERT INTO `lbj_tuihuanmingxi` VALUES ('25', 'LBJTH_171112001', '107车刀片', '', 'TCMT110304-KFH13A', '1', '件', 'OP20T01', '20171112', '箱式 2号柜', '6层', '');
INSERT INTO `lbj_tuihuanmingxi` VALUES ('26', 'LBJTH_171112001', '490铣刀刀片', '', '490R-08T308M-KM3040', '1', '件', 'OP20T01', '20171112', 'kardex 2号柜', '2层', '');
INSERT INTO `lbj_tuihuanmingxi` VALUES ('27', 'LBJTH_171112001', 'CD8804刃刀片', '', '880-0503W06H-P-GR404', '2', '件', 'OP20T01', '20171112', '箱式 2号柜', '6层', '');

-- ----------------------------
-- Table structure for `lingbujian`
-- ----------------------------
DROP TABLE IF EXISTS `lingbujian`;
CREATE TABLE `lingbujian` (
  `xh` int(11) NOT NULL AUTO_INCREMENT,
  `xinghao` char(50) NOT NULL,
  `mc` varchar(50) NOT NULL,
  `dj` float(6,2) NOT NULL,
  `yssm` float(6,2) NOT NULL,
  `zt` varchar(10) DEFAULT NULL,
  `img` blob,
  `bz` tinytext,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `lingbujian_ix1` (`xinghao`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of lingbujian
-- ----------------------------
INSERT INTO `lingbujian` VALUES ('6', 'BT16', '夹头', '101.00', '100.00', null, null, '546');
INSERT INTO `lingbujian` VALUES ('7', 'BT50', '拉丁', '91.00', '100.00', null, null, '634');
INSERT INTO `lingbujian` VALUES ('8', 'BT520', '夹头', '13.00', '100.00', null, null, '这是个夹头');
INSERT INTO `lingbujian` VALUES ('9', 'BT80', '刀片', '300.00', '100.00', null, null, '463');
INSERT INTO `lingbujian` VALUES ('10', 'Colorman8080', '刀杆', '200.00', '100.00', null, null, '');
INSERT INTO `lingbujian` VALUES ('11', 'GS39032', '夹头', '70.00', '100.00', null, null, '');
INSERT INTO `lingbujian` VALUES ('12', 'HSK100', '丝锥', '108.00', '100.00', null, null, '344');
INSERT INTO `lingbujian` VALUES ('13', 'HSK20', '铣刀', '108.00', '100.00', null, null, '111');
INSERT INTO `lingbujian` VALUES ('14', 'HSK212', '铣刀', '108.00', '100.00', null, null, '这是一把刀');
INSERT INTO `lingbujian` VALUES ('15', 'HSK40', '钻头', '108.00', '100.00', null, null, '23234');
INSERT INTO `lingbujian` VALUES ('16', 'HSK52212', '铣刀', '108.00', '100.00', null, null, '这是一把刀');
INSERT INTO `lingbujian` VALUES ('17', 'HSK60', '刀柄', '108.00', '100.00', null, null, '45');
INSERT INTO `lingbujian` VALUES ('18', 'HSK80', '刀杆', '108.00', '100.00', null, null, '');
INSERT INTO `lingbujian` VALUES ('19', 'lab212', '212实验室', '520.00', '100.00', null, null, '我爱实验室');
INSERT INTO `lingbujian` VALUES ('20', 'S1608032', '刀套', '421.00', '100.00', null, null, 'cxzvg');
INSERT INTO `lingbujian` VALUES ('21', ' R331.32-080Q27EM10.00', '铣刀', '6948.00', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('22', ' N331.1A-084508E-KL3220', '刀片', '105.60', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('23', ' SCLCR2020K12', '车刀杆', '105.00', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('24', 'SOMT120408PDER-GACK200', '刀片', '51.76', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('25', ' C4-391.01-40080A', '加长接杆', '1997.50', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('26', ' R390-044C4-45M', '铣刀', '6819.12', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('27', 'R390-11T316M-KM1020', '刀片 ', '86.13', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('28', ' C3-391.01-32060A', '刀柄', '2275.00', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('29', ' 870-2500-25-Pm4234', '刀片', '1155.00', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('30', ' C4-391.27-25*077', '钻头接柄', '2119.50', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('31', '870-2500-25L32-8', '加长U钻 ', '5455.00', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('32', ' 4736 308.100', '热涨刀柄', '2956.00', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('33', ' 3Z6070-18.5', '直柄硬质合金钻头', '3290.00', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('34', '3Z750-19.70L', '硬质合金内冷铣铰刀 ', '3450.00', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('35', ' 3Z1025-20.05SL', '硬质合金内冷铰刀', '3650.00', '100.00', null, null, '下落不明');
INSERT INTO `lingbujian` VALUES ('36', ' C5-390.410-100-100A', '主刀柄', '3667.75', '100.00', null, null, '东BW');
INSERT INTO `lingbujian` VALUES ('37', 'C8-390.410-100120A', '主刀柄 ', '4216.00', '100.00', null, null, '');
INSERT INTO `lingbujian` VALUES ('38', ' 5692022-06', '冷却管  ', '318.75', '100.00', null, null, '1-23');
INSERT INTO `lingbujian` VALUES ('39', ' TXP20-D24.7A30P72', '非标倒角刀', '1050.00', '100.00', null, null, '1-9');
INSERT INTO `lingbujian` VALUES ('40', ' C3-390.410-100 080A', '刀柄', '3302.25', '100.00', null, null, '');
INSERT INTO `lingbujian` VALUES ('41', 'C6-390.410-100110A', '主刀柄', '3846.25', '100.00', null, null, '');
INSERT INTO `lingbujian` VALUES ('42', ' C4-390.410-100090A', 'HSK Capto刀柄', '3476.50', '100.00', null, null, '');

-- ----------------------------
-- Table structure for `quanxianbiao`
-- ----------------------------
DROP TABLE IF EXISTS `quanxianbiao`;
CREATE TABLE `quanxianbiao` (
  `quanxianid` int(10) NOT NULL AUTO_INCREMENT,
  `quanxianmc` char(20) CHARACTER SET utf8 NOT NULL,
  `quanxianyw` char(20) CHARACTER SET utf8 NOT NULL,
  `qxdm` int(4) NOT NULL,
  `beizhu` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`quanxianid`)
) ENGINE=MyISAM AUTO_INCREMENT=45 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of quanxianbiao
-- ----------------------------
INSERT INTO `quanxianbiao` VALUES ('34', '编辑用户', 'bianjiyh', '2', '');
INSERT INTO `quanxianbiao` VALUES ('33', '添加用户', 'tianjiayh', '2', '');
INSERT INTO `quanxianbiao` VALUES ('32', '删除组', 'shanchuzu', '1', '');
INSERT INTO `quanxianbiao` VALUES ('31', '编辑组', 'bianjizu', '1', '');
INSERT INTO `quanxianbiao` VALUES ('30', '新建组', 'xinjianzu', '1', '12');
INSERT INTO `quanxianbiao` VALUES ('35', '删除用户', 'shanchuyh', '2', '');
INSERT INTO `quanxianbiao` VALUES ('36', '重置密码', 'czmima', '3', '');
INSERT INTO `quanxianbiao` VALUES ('37', '查看系统日志', 'chakanrz', '4', '');
INSERT INTO `quanxianbiao` VALUES ('38', '基础资料导入', 'zldaoru', '5', '');
INSERT INTO `quanxianbiao` VALUES ('39', '基础资料导出', 'zldaochu', '5', '');
INSERT INTO `quanxianbiao` VALUES ('40', '基础资料修改', 'zlxiugai', '5', '');
INSERT INTO `quanxianbiao` VALUES ('41', '查看系统数据', 'chakansj', '6', '');
INSERT INTO `quanxianbiao` VALUES ('42', '管理刀具/零部件', 'guanlidj', '7', '');
INSERT INTO `quanxianbiao` VALUES ('43', '管理机床/刀具柜', 'guanlijc', '8', '');
INSERT INTO `quanxianbiao` VALUES ('44', '管理工艺卡', 'guanligy', '9', '');

-- ----------------------------
-- Table structure for `qxgroup`
-- ----------------------------
DROP TABLE IF EXISTS `qxgroup`;
CREATE TABLE `qxgroup` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `quanxianmc` char(20) CHARACTER SET utf8 NOT NULL,
  `groupname` char(20) CHARACTER SET utf8 NOT NULL,
  `beizhu` varchar(100) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of qxgroup
-- ----------------------------
INSERT INTO `qxgroup` VALUES ('4', '管理机床/刀具柜', '车间工作小组', '');
INSERT INTO `qxgroup` VALUES ('5', '管理工艺卡', '车间工作小组', '');
INSERT INTO `qxgroup` VALUES ('8', '新建组', '系统管理组', '');
INSERT INTO `qxgroup` VALUES ('9', '编辑组', '系统管理组', '');
INSERT INTO `qxgroup` VALUES ('10', '删除组', '系统管理组', '');
INSERT INTO `qxgroup` VALUES ('11', '添加用户', '系统管理组', '');
INSERT INTO `qxgroup` VALUES ('12', '编辑用户', '系统管理组', '');
INSERT INTO `qxgroup` VALUES ('13', '删除用户', '系统管理组', '');
INSERT INTO `qxgroup` VALUES ('14', '重置密码', '系统管理组', '');

-- ----------------------------
-- Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `name` char(50) DEFAULT NULL,
  `pwd` char(50) DEFAULT NULL,
  `xingming` char(20) NOT NULL,
  `type` char(50) DEFAULT NULL,
  `bumen` char(20) NOT NULL,
  `beizhu` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`xh`),
  UNIQUE KEY `name` (`name`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('1', 'xmu', '123', '厦门大学', '管理员', '刀管中心', '系统超级管理员');
INSERT INTO `user` VALUES ('2', 'chenmoliang', '123456', '陈沫良', '普通用户', '车间', '车间工人');
INSERT INTO `user` VALUES ('5', 'admin', '123456', '小王', '管理员', '刀管中心', '');

-- ----------------------------
-- Table structure for `usergroup`
-- ----------------------------
DROP TABLE IF EXISTS `usergroup`;
CREATE TABLE `usergroup` (
  `xh` int(10) NOT NULL AUTO_INCREMENT,
  `name` char(20) CHARACTER SET utf8 NOT NULL,
  `groupname` char(20) CHARACTER SET utf8 NOT NULL,
  `beizhu` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`xh`)
) ENGINE=MyISAM AUTO_INCREMENT=60 DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of usergroup
-- ----------------------------
INSERT INTO `usergroup` VALUES ('57', 'admin', '车间工作小组', null);
INSERT INTO `usergroup` VALUES ('53', 'chenmoliang', '车间工作小组', null);

-- ----------------------------
-- Table structure for `zuchengmingxi`
-- ----------------------------
DROP TABLE IF EXISTS `zuchengmingxi`;
CREATE TABLE `zuchengmingxi` (
  `xh` int(20) NOT NULL AUTO_INCREMENT,
  `lbjxh` char(50) NOT NULL,
  `lbjmc` varchar(50) NOT NULL,
  `sl` int(10) NOT NULL,
  `guige` varchar(50) DEFAULT NULL,
  `danwei` varchar(10) NOT NULL,
  `szjd` varchar(50) NOT NULL,
  `bz` text,
  PRIMARY KEY (`xh`)
) ENGINE=InnoDB AUTO_INCREMENT=1404 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of zuchengmingxi
-- ----------------------------
INSERT INTO `zuchengmingxi` VALUES ('1', 'S945-563916', '主刀柄', '1', '', '个', 'Φ100铣刀(T1001)', '');
INSERT INTO `zuchengmingxi` VALUES ('2', 'R365-100Q32-S15M', '刀盘', '1', 'z=7', '个', 'Φ100铣刀(T1001)', '');
INSERT INTO `zuchengmingxi` VALUES ('3', 'R365-1505ZNE-KM 1020', '刀片', '7', '', '个', 'Φ100铣刀(T1001)', '');
INSERT INTO `zuchengmingxi` VALUES ('4', '5692 022-06', '水嘴', '1', '', '个', 'Φ100铣刀(T1001)', '');
INSERT INTO `zuchengmingxi` VALUES ('5', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ8.5-25/120°(T1002)', '');
INSERT INTO `zuchengmingxi` VALUES ('6', 'C5-391.14-32 100', '弹簧夹头', '1', '', '个', 'Φ8.5-25/120°(T1002)', '');
INSERT INTO `zuchengmingxi` VALUES ('7', '393.15-32 12', '夹心', '1', '', '个', 'Φ8.5-25/120°(T1002)', '');
INSERT INTO `zuchengmingxi` VALUES ('8', '5692 022-06', '水嘴', '1', '', '个', 'Φ8.5-25/120°(T1002)', '');
INSERT INTO `zuchengmingxi` VALUES ('9', 'C4-390.410-100 090A', '主刀柄', '1', '', '个', 'M10×1 丝锥(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('10', 'C4-391.01-40 080A', '接杆', '1', '', '个', 'M10×1 丝锥(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('11', 'C4-391.14-20 052', '弹簧夹头', '1', '', '个', 'M10×1 丝锥(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('12', 'ER20-GB Φ7.0-Φ5.5', '夹心', '1', '', '个', 'M10×1 丝锥(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('13', 'E447M10', '丝锥', '1', '', '个', 'M10×1 丝锥(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('14', '5692 022-06', '水嘴', '1', '', '个', 'M10×1 丝锥(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('15', 'A10.00.32', '主刀柄', '1', '', '个', 'Φ6.8-19/120°(T1004)', '');
INSERT INTO `zuchengmingxi` VALUES ('16', '393.15-32 10', '夹心', '1', '', '个', 'Φ6.8-19/120°(T1004)', '');
INSERT INTO `zuchengmingxi` VALUES ('17', '5692 022-06', '水嘴', '1', '', '个', 'Φ6.8-19/120°(T1004)', '');
INSERT INTO `zuchengmingxi` VALUES ('18', 'C6-390.410-100 110A', '主刀柄', '1', '', '个', 'M8 丝锥(T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('19', 'C6-391.01-63 140A', '接杆', '1', '', '个', 'M8 丝锥(T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('20', 'C6-391.14-40 130', '弹簧夹头', '1', '', '个', 'M8 丝锥(T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('21', 'ER40-GB', '夹心', '1', '', '个', 'M8 丝锥(T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('22', 'E446M8', '丝锥', '1', '', '个', 'M8 丝锥(T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('23', '5692 022-06', '水嘴', '1', '', '个', 'M8 丝锥(T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('24', 'C6-390.410-100 110A', '主刀柄', '1', '', '个', 'Φ22.1-35/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('25', 'C6-391.27-25 070A', '侧压夹头', '1', '', '个', 'Φ22.1-35/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('26', '870-2210-22-KM       3234', '刀片', '1', '', '个', 'Φ22.1-35/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('27', '880-04 03 W07H-P-GR  4044', '刀片', '1', '', '个', 'Φ22.1-35/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('28', '5692 022-06', '水嘴', '1', '', '个', 'Φ22.1-35/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('29', 'A10.022.32', '主刀柄', '1', '', '个', 'Φ11.8-16/120°(T1007)', '');
INSERT INTO `zuchengmingxi` VALUES ('30', '393.15-32 14', '夹心', '1', '', '个', 'Φ11.8-16/120°(T1007)', '');
INSERT INTO `zuchengmingxi` VALUES ('31', 'ST0790', '阶梯硬钻', '1', '', '个', 'Φ11.8-16/120°(T1007)', '');
INSERT INTO `zuchengmingxi` VALUES ('32', '5692 022-06', '水嘴', '1', '', '个', 'Φ11.8-16/120°(T1007)', '');
INSERT INTO `zuchengmingxi` VALUES ('33', 'A10.022.32', '主刀柄', '1', '', '个', 'Φ12F9-11(T1008)', '');
INSERT INTO `zuchengmingxi` VALUES ('34', '393.15-32 12', '夹心', '1', '', '个', 'Φ12F9-11(T1008)', '');
INSERT INTO `zuchengmingxi` VALUES ('35', 'ST0781', '铰刀', '1', '', '个', 'Φ12F9-11(T1008)', '');
INSERT INTO `zuchengmingxi` VALUES ('36', '5692 022-06', '水嘴', '1', '', '个', 'Φ12F9-11(T1008)', '');
INSERT INTO `zuchengmingxi` VALUES ('37', 'S945-563916', '主刀柄', '1', '', '个', 'Φ100铣刀(T1009)', '');
INSERT INTO `zuchengmingxi` VALUES ('38', 'R590-100Q32A-11M', '刀盘', '1', 'z=6', '个', 'Φ100铣刀(T1009)', '');
INSERT INTO `zuchengmingxi` VALUES ('39', 'R590-1105H-ZC2-KL    CB50', '刀片', '6', '', '个', 'Φ100铣刀(T1009)', '');
INSERT INTO `zuchengmingxi` VALUES ('40', '5692 022-06', '水嘴', '1', '', '个', 'Φ100铣刀(T1009)', '');
INSERT INTO `zuchengmingxi` VALUES ('41', '392.41027-100 32 100A', '主刀柄', '1', '', '个', 'Φ20.5-30/Ø32 (T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('42', '880-04 03 05H-C-GR   1044', '刀片', '1', '', '个', 'Φ20.5-30/Ø32 (T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('43', '880-04 03 W07H-P-GR  4044', '刀片', '1', '', '个', 'Φ20.5-30/Ø32 (T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('44', 'TPMT 09 02 08-KM     3215', '刀片', '2', '', '个', 'Φ20.5-30/Ø32 (T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('45', '5692 022-06', '水嘴', '1', '', '个', 'Φ20.5-30/Ø32 (T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('46', '392.41014-100 40 120A', '主刀柄', '1', '', '个', 'M22x1.5 (T1011)', '');
INSERT INTO `zuchengmingxi` VALUES ('47', '393.14-40 D180×145', '夹心', '1', '', '个', 'M22x1.5 (T1011)', '');
INSERT INTO `zuchengmingxi` VALUES ('48', 'EP11M22X1.5（ST0787)', '丝锥', '1', '', '个', 'M22x1.5 (T1011)', '');
INSERT INTO `zuchengmingxi` VALUES ('49', '5692 022-06', '水嘴', '1', '', '个', 'M22x1.5 (T1011)', '');
INSERT INTO `zuchengmingxi` VALUES ('50', '392.41014-100 40 100A', '主刀柄', '1', '', '个', 'Φ10.3-30/120°(T1012)', '');
INSERT INTO `zuchengmingxi` VALUES ('51', '393.15-32 14', '夹心', '1', '', '个', 'Φ10.3-30/120°(T1012)', '');
INSERT INTO `zuchengmingxi` VALUES ('52', '5692 022-06', '水嘴', '1', '', '个', 'Φ10.3-30/120°(T1012)', '');
INSERT INTO `zuchengmingxi` VALUES ('53', '392.41014-100 32 100A', '主刀柄', '1', '', '个', 'M12×6H丝锥（T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('54', 'ER32-GB Φ9.0', '夹心', '1', '', '个', 'M12×6H丝锥（T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('55', 'E447M12', '丝锥', '1', '', '个', 'M12×6H丝锥（T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('56', '5692 022-06', '水嘴', '1', '', '个', 'M12×6H丝锥（T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('57', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ84铣刀(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('58', 'C8-391.05CD-27 320', '铣刀接柄', '1', '', '个', 'Φ84铣刀(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('59', 'R390-084Q27-11M', '铣刀盘', '1', 'Z=7', '个', 'Φ84铣刀(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('60', 'R390-11 T3 08M-KM    1020', '刀片', '7', '', '个', 'Φ84铣刀(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('61', '5692 022-06', '水嘴', '1', '', '个', 'Φ84铣刀(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('62', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ109.5/90°(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('63', 'S912-561764', '非标镗刀接柄', '1', 'L=420', '个', 'Φ109.5/90°(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('64', 'TCMT 16 T3 08-KR     3210', '刀片', '3', '', '个', 'Φ109.5/90°(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('65', 'STFCR-12CA-16-M', '刀夹', '2', '', '个', 'Φ109.5/90°(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('66', 'STSCR-12CA-16-M', '刀夹', '1', '', '个', 'Φ109.5/90°(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('67', '5692 022-06', '水嘴', '1', '', '个', 'Φ109.5/90°(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('68', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ119.5/90°(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('69', 'S912-561771', '非标镗刀接柄', '1', 'L=420', '个', 'Φ119.5/90°(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('70', 'TCMT 16 T3 08-KR     3210', '刀片', '3', '', '个', 'Φ119.5/90°(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('71', 'STFCR-12CA-16-M', '刀夹', '2', '', '个', 'Φ119.5/90°(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('72', 'STSCR-12CA-16-M（无刀夹）', '刀夹', '0', '', '个', 'Φ119.5/90°(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('73', '5692 022-06', '水嘴', '1', '', '个', 'Φ119.5/90°(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('74', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ129.5/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('75', 'S912-561772', '非标镗刀接柄', '1', 'L=370', '个', 'Φ129.5/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('76', 'TCMT 16 T3 08-KR     3210', '刀片', '2', '', '个', 'Φ129.5/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('77', 'STFCR-12CA-16-M', '刀夹', '2', '', '个', 'Φ129.5/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('78', 'STSCR-12CA-16-M（无刀夹）', '刀夹', '1', '', '个', 'Φ129.5/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('79', '5692 022-06', '水嘴', '1', '', '个', 'Φ129.5/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('80', '392.41020-100 40 120A', '主刀柄', '1', '', '个', 'D250 刀检(T1019)', '');
INSERT INTO `zuchengmingxi` VALUES ('81', 'SCLCL20 20K12（看不到）', '非标刀杆', '1', '', '个', 'D250 刀检(T1019)', '');
INSERT INTO `zuchengmingxi` VALUES ('82', 'CCMT 22 04 08-KR    3215', '刀片', '1', '', '个', 'D250 刀检(T1019)', '');
INSERT INTO `zuchengmingxi` VALUES ('83', '5692 022-06', '水嘴', '1', '', '个', 'D250 刀检(T1019)', '');
INSERT INTO `zuchengmingxi` VALUES ('84', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ50倒角铣刀(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('85', 'C5-391.05CD-22 220', '铣刀接柄', '1', '', '个', 'Φ50倒角铣刀(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('86', 'R245-050Q22-12M', '铣刀盘', '1', '', '个', 'Φ50倒角铣刀(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('87', 'R245-12 T3 M-KM      1020', '刀片', '4', '', '个', 'Φ50倒角铣刀(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('88', '5692 022-06', '水嘴', '1', '', '个', 'Φ50倒角铣刀(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('89', 'C4-390.410-100 090A', '主刀柄', '1', '', '个', 'Φ17.5-42/120°(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('90', 'C4-391.27-25 077', '侧压接柄', '1', '', '个', 'Φ17.5-42/120°(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('91', 'TM880-553659（看不到）', '刀杆', '1', '', '个', 'Φ17.5-42/120°(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('92', '880-03 03 05H-C-GR  1044', '刀片', '1', '', '个', 'Φ17.5-42/120°(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('93', '880-03 03 W06H-P-GR 4044', '刀片', '1', '', '个', 'Φ17.5-42/120°(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('94', '880-02 02 W05H-P-GR 4044', '刀片', '1', '', '个', 'Φ17.5-42/120°(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('95', '5692 022-06', '水嘴', '1', '', '个', 'Φ17.5-42/120°(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('96', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'M20丝锥(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('97', 'C5-391.14-25 100', '弹簧夹头', '1', '', '个', 'M20丝锥(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('98', '393.14-25 D160X120', '夹心', '1', '', '个', 'M20丝锥(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('99', 'E447M20', '丝锥', '1', '', '个', 'M20丝锥(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('100', '5692 022-06', '水嘴', '1', '', '个', 'M20丝锥(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('101', '392.41014-100 32 100A', '主刀柄', '1', '', '个', 'Φ10.8 /120°(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('102', 'ER32GB', '夹心', '1', '', '个', 'Φ10.8 /120°(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('103', 'ST0788', '硬钻', '1', 'L=30', '个', 'Φ10.8 /120°(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('104', '5692 022-06', '水嘴', '1', '', '个', 'Φ10.8 /120°(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('105', '392.41014-100 32 100A', '主刀柄', '1', '', '个', 'Φ10.8/8.65/120°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('106', '393.15-32 14', '夹心', '1', '', '个', 'Φ10.8/8.65/120°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('107', 'ST0787', '硬钻', '1', 'L=17', '个', 'Φ10.8/8.65/120°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('108', '5692 022-06', '水嘴', '1', '', '个', 'Φ10.8/8.65/120°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('109', '392.41014-100 32 100A', '主刀柄', '1', '', '个', 'M12×1.25丝锥(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('110', 'ER32GB-Φ9.0', '夹心', '1', '', '个', 'M12×1.25丝锥(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('111', 'ES13KM12X1.25', '丝锥', '1', '', '个', 'M12×1.25丝锥(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('112', '5692 022-06', '水嘴', '1', '', '个', 'M12×1.25丝锥(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('113', '392.41014-100 32 100A', '主刀柄', '1', '', '个', 'Φ8.65硬钻(T1028)', '');
INSERT INTO `zuchengmingxi` VALUES ('114', 'ER32DCB Φ10.0-Φ9.5', '夹心', '1', '', '个', 'Φ8.65硬钻(T1028)', '');
INSERT INTO `zuchengmingxi` VALUES ('115', 'S861.1-GM-553677', '硬钻', '1', '', '个', 'Φ8.65硬钻(T1028)', '');
INSERT INTO `zuchengmingxi` VALUES ('116', '5692 022-06', '水嘴', '1', '', '个', 'Φ8.65硬钻(T1028)', '');
INSERT INTO `zuchengmingxi` VALUES ('117', '392.41014-100 32 100A', '主刀柄', '1', '', '个', 'Φ9-90/120°（T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('118', 'ER32DCB 12-11.5', '夹心', '1', '', '个', 'Φ9-90/120°（T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('119', 'ST0786', '硬钻', '1', '', '个', 'Φ9-90/120°（T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('120', '5692 022-06', '水嘴', '1', '', '个', 'Φ9-90/120°（T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('121', '392.41014-100 32 100A', '主刀柄', '1', '', '个', 'M10x1丝锥(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('122', 'ER32GB-Φ7.0', '夹心', '1', '', '个', 'M10x1丝锥(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('123', 'ES13KM10×1', '丝锥', '1', '', '个', 'M10x1丝锥(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('124', '5692 022-06', '水嘴', '1', '', '个', 'M10x1丝锥(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('125', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ29阶梯钻(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('126', 'C8-391.27-40 095', '侧压接柄', '1', '', '个', 'Φ29阶梯钻(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('127', '880-05 03 05H-C-GR  1044', '刀片', '1', '', '个', 'Φ29阶梯钻(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('128', '880-05 03 W08H-P-GR 4044', '刀片', '1', '', '个', 'Φ29阶梯钻(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('129', '880-04 03 W07H-P-GR 4044', '刀片', '1', '', '个', 'Φ29阶梯钻(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('130', '5692 022-06', '水嘴', '1', '', '个', 'Φ29阶梯钻(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('131', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ31.5镗刀(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('132', 'C8-391.27-40 095', '侧压接柄', '1', '', '个', 'Φ31.5镗刀(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('133', 'S912-553898(看不到）', '刀杆', '1', '', '个', 'Φ31.5镗刀(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('134', 'TCMT 09 02 04-KM    3215', '刀片', '2', '', '个', 'Φ31.5镗刀(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('135', 'STFCR-12CA-16-M(看不到）', '刀夹', '2', '', '个', 'Φ31.5镗刀(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('136', '5692 022-06', '水嘴', '1', '', '个', 'Φ31.5镗刀(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('137', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ32精镗(T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('138', 'C8-391.02-40 070A', '变径接柄', '1', '', '个', 'Φ32精镗(T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('139', 'C4-R825A-AAB120A', '精镗单元', '1', '', '个', 'Φ32精镗(T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('140', 'A-AF11STUC06T1A', '刀夹', '1', '', '个', 'Φ32精镗(T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('141', 'TCMT 06 T1 04-KF    3005', '刀片', '1', '', '个', 'Φ32精镗(T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('142', '5692 022-06', '水嘴', '1', '', '个', 'Φ32精镗(T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('143', '392.41027-100 32 100A', '主刀柄', '1', '', '个', 'Φ25扩孔(T1034)', '');
INSERT INTO `zuchengmingxi` VALUES ('144', 'S912-553749(看不到）', '刀杆', '1', '', '个', 'Φ25扩孔(T1034)', '');
INSERT INTO `zuchengmingxi` VALUES ('145', 'TCMT 11 03 08-KM    3215', '刀片', '2', '', '个', 'Φ25扩孔(T1034)', '');
INSERT INTO `zuchengmingxi` VALUES ('146', '5692 022-06', '水嘴', '1', '', '个', 'Φ25扩孔(T1034)', '');
INSERT INTO `zuchengmingxi` VALUES ('147', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ80铣刀（T1035）', '');
INSERT INTO `zuchengmingxi` VALUES ('148', 'C8-391.05CD-27 320', '铣刀接柄', '1', '', '个', 'Φ80铣刀（T1035）', '');
INSERT INTO `zuchengmingxi` VALUES ('149', 'R590-080Q27S-11M', '铣刀盘', '1', '', '个', 'Φ80铣刀（T1035）', '');
INSERT INTO `zuchengmingxi` VALUES ('150', 'R590-110508H-KL     1020', '刀片', '6', '', '个', 'Φ80铣刀（T1035）', '');
INSERT INTO `zuchengmingxi` VALUES ('151', '5692 022-06', '水嘴', '1', '', '个', 'Φ80铣刀（T1035）', '');
INSERT INTO `zuchengmingxi` VALUES ('152', 'C6-390.410-100 110A', '主刀柄', '1', '', '个', 'Φ17-47/90°(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('153', 'C6-391.27-25 070A', '侧压接柄', '1', '', '个', 'Φ17-47/90°(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('154', '870-1700-17-KM      3234', '刀片', '1', '', '个', 'Φ17-47/90°(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('155', '880-03 03 W06H-P-GR 4044', '刀片', '1', '', '个', 'Φ17-47/90°(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('156', '5692 022-06', '水嘴', '1', '', '个', 'Φ17-47/90°(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('157', '392.41014-100 32 100A', '主刀柄', '1', '', '个', 'Φ14.5/120°（T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('158', '393.15-32 18', '夹心', '1', '', '个', 'Φ14.5/120°（T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('159', '5692 022-06', '水嘴', '1', '', '个', 'Φ14.5/120°（T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('160', 'A10.022.40', '主刀柄', '1', '', '个', 'M16x1.5丝锥(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('161', '393.14-40 D120X090', '夹心', '1', '', '个', 'M16x1.5丝锥(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('162', 'ES13KM16X1.5', '丝锥', '1', '', '个', 'M16x1.5丝锥(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('163', '5692 022-06', '水嘴', '1', '', '个', 'M16x1.5丝锥(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('164', '392.41014-100 32 100A', '主刀柄', '1', '', '个', 'Φ14.5-20/90°(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('165', '393.15-32 18', '夹心', '1', '', '个', 'Φ14.5-20/90°(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('166', 'ST0784', '硬钻', '1', '', '个', 'Φ14.5-20/90°(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('167', '5692 022-06', '水嘴', '1', '', '个', 'Φ14.5-20/90°(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('168', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ15R8精镗(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('169', 'C5-391.37A-12 048B', '精镗单元', '1', '', '个', 'Φ15R8精镗(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('170', 'R429U(看不到）', '镗刀杆', '1', '', '个', 'Φ15R8精镗(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('171', 'TCMT 09 02 04-KF   3005', '刀片', '1', '', '个', 'Φ15R8精镗(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('172', '5692 022-06', '水嘴', '1', '', '个', 'Φ15R8精镗(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('173', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ15F9精镗(T1041)', '');
INSERT INTO `zuchengmingxi` VALUES ('174', 'C5-391.37A-12 048B', '精镗单元', '1', '', '个', 'Φ15F9精镗(T1041)', '');
INSERT INTO `zuchengmingxi` VALUES ('175', 'R429.90-14-040-09-AC(看不到）', '镗刀杆', '1', '', '个', 'Φ15F9精镗(T1041)', '');
INSERT INTO `zuchengmingxi` VALUES ('176', 'TCMT 09 02 04-KF   3005', '刀片', '1', '', '个', 'Φ15F9精镗(T1041)', '');
INSERT INTO `zuchengmingxi` VALUES ('177', '5692 022-06', '水嘴', '1', '', '个', 'Φ15F9精镗(T1041)', '');
INSERT INTO `zuchengmingxi` VALUES ('178', 'C6-390.410-100110A', '主刀柄', '1', '', '个', 'Φ6.8-17/120°(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('179', 'C6-391.01-63 140A', '接柄', '1', '', '个', 'Φ6.8-17/120°(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('180', 'C6-391.14-40 130', '弹簧夹头', '1', '', '个', 'Φ6.8-17/120°(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('181', '393.15-40 10', '夹心', '1', '', '个', 'Φ6.8-17/120°(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('182', 'ST0783', '丝锥', '1', '', '个', 'Φ6.8-17/120°(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('183', '5692 022-06', '水嘴', '1', '', '个', 'Φ6.8-17/120°(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('184', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ18F9精镗(T1044)', '');
INSERT INTO `zuchengmingxi` VALUES ('185', 'C5-391.37A-12 048B', '精镗单元', '1', '', '个', 'Φ18F9精镗(T1044)', '');
INSERT INTO `zuchengmingxi` VALUES ('186', 'R429.90-14-040-09-AC(看不到）', '镗刀杆', '1', '', '个', 'Φ18F9精镗(T1044)', '');
INSERT INTO `zuchengmingxi` VALUES ('187', 'TCMT 09 02 04-KF   3005', '刀片', '1', '', '个', 'Φ18F9精镗(T1044)', '');
INSERT INTO `zuchengmingxi` VALUES ('188', '5692 022-06', '水嘴', '1', '', '个', 'Φ18F9精镗(T1044)', '');
INSERT INTO `zuchengmingxi` VALUES ('189', '392.41027-100 32 100A', '主刀柄', '1', '', '个', 'Φ16 / Φ17.5(T1043) ', '');
INSERT INTO `zuchengmingxi` VALUES ('190', 'S912-561773((看不到）', '刀杆', '1', '', '个', 'Φ16 / Φ17.5(T1043) ', '');
INSERT INTO `zuchengmingxi` VALUES ('191', 'TCMT 09 02 08-KM   3215', '刀片', '1', '', '个', 'Φ16 / Φ17.5(T1043) ', '');
INSERT INTO `zuchengmingxi` VALUES ('192', 'TCMT 06 T1 04-KF   3005', '刀片', '1', '', '个', 'Φ16 / Φ17.5(T1043) ', '');
INSERT INTO `zuchengmingxi` VALUES ('193', '5692 022-06', '水嘴', '1', '', '个', 'Φ16 / Φ17.5(T1043) ', '');
INSERT INTO `zuchengmingxi` VALUES ('194', '930-HA10-HD-25-106', '主刀柄', '1', '', '个', 'Φ19.5-20/90°(T1045)', '');
INSERT INTO `zuchengmingxi` VALUES ('195', 'ST0782', '硬钻', '1', '', '个', 'Φ19.5-20/90°(T1045)', '');
INSERT INTO `zuchengmingxi` VALUES ('196', '5692 022-06', '水嘴', '1', '', '个', 'Φ19.5-20/90°(T1045)', '');
INSERT INTO `zuchengmingxi` VALUES ('197', '930-HA10-HD-25-106', '主刀柄', '1', '', '个', 'Φ20H9枪钻(T1046)', '');
INSERT INTO `zuchengmingxi` VALUES ('198', '5692 022-06', '水嘴', '1', '', '个', 'Φ20H9枪钻(T1046)', '');
INSERT INTO `zuchengmingxi` VALUES ('199', '392.41027-100 32 100A', '主刀柄', '1', '', '个', 'Φ27硬钻(T1047)', '');
INSERT INTO `zuchengmingxi` VALUES ('200', '880-D2700L32-03', '刀杆', '1', '', '个', 'Φ27硬钻(T1047)', '');
INSERT INTO `zuchengmingxi` VALUES ('201', '880-05 03 05H-C-GR   1044', '刀片', '1', '', '个', 'Φ27硬钻(T1047)', '');
INSERT INTO `zuchengmingxi` VALUES ('202', '880-05 03 W08H-P-GR  4044', '刀片', '1', '', '个', 'Φ27硬钻(T1047)', '');
INSERT INTO `zuchengmingxi` VALUES ('203', '5692 022-06', '水嘴', '1', '', '个', 'Φ27硬钻(T1047)', '');
INSERT INTO `zuchengmingxi` VALUES ('204', 'C3-390.410-100 080A', '主刀柄', '1', '', '个', 'Φ29.5半精镗(T1048)', '');
INSERT INTO `zuchengmingxi` VALUES ('205', 'C3-391.68A-1-021068B', '粗镗接柄', '1', '', '个', 'Φ29.5半精镗(T1048)', '');
INSERT INTO `zuchengmingxi` VALUES ('206', '391.68A-1-03213C06B', '滑块', '2', '', '个', 'Φ29.5半精镗(T1048)', '');
INSERT INTO `zuchengmingxi` VALUES ('207', 'CCMT 06 02 04-KM     3005', '刀片', '2', '', '个', 'Φ29.5半精镗(T1048)', '');
INSERT INTO `zuchengmingxi` VALUES ('208', '5692 022-06', '水嘴', '1', '', '个', 'Φ29.5半精镗(T1048)', '');
INSERT INTO `zuchengmingxi` VALUES ('209', 'C3-390.410-100 080A', '主刀柄', '1', '', '个', 'Φ30精镗(T1049)', '');
INSERT INTO `zuchengmingxi` VALUES ('210', 'C3-R825A-AAB072A', '精镗单元', '1', '', '个', 'Φ30精镗(T1049)', '');
INSERT INTO `zuchengmingxi` VALUES ('211', 'R825A-AF11STUC06T1A', '刀夹', '1', '', '个', 'Φ30精镗(T1049)', '');
INSERT INTO `zuchengmingxi` VALUES ('212', 'TCMT06 T1 04-KF     3005', '刀片', '1', '', '个', 'Φ30精镗(T1049)', '');
INSERT INTO `zuchengmingxi` VALUES ('213', '5692 022-06', '水嘴', '1', '', '个', 'Φ30精镗(T1049)', '');
INSERT INTO `zuchengmingxi` VALUES ('214', '345-11-9093S-53619(看不到）', '主刀柄', '1', '', '个', 'Φ110/Φ130精镗(T1050)', '');
INSERT INTO `zuchengmingxi` VALUES ('215', '890450232R58429(看不到）', '镗刀杆', '1', ' L585', '个', 'Φ110/Φ130精镗(T1050)', '');
INSERT INTO `zuchengmingxi` VALUES ('216', 'TCMT 11 03 04-KF    3005', '刀片', '2', '', '个', 'Φ110/Φ130精镗(T1050)', '');
INSERT INTO `zuchengmingxi` VALUES ('217', '无型号', '镗刀头', '2', '', '个', 'Φ110/Φ130精镗(T1050)', '');
INSERT INTO `zuchengmingxi` VALUES ('218', '5692 022-06', '水嘴', '1', '', '个', 'Φ110/Φ130精镗(T1050)', '');
INSERT INTO `zuchengmingxi` VALUES ('219', '345-11-9093S-53619', '主刀柄', '1', '', '个', 'Φ120精镗(T1051)', '');
INSERT INTO `zuchengmingxi` VALUES ('220', '890450232R58430', '镗刀杆', '1', '', '个', 'Φ120精镗(T1051)', '');
INSERT INTO `zuchengmingxi` VALUES ('221', 'TCMT 11 03 04-KF    3005', '刀片', '1', '', '个', 'Φ120精镗(T1051)', '');
INSERT INTO `zuchengmingxi` VALUES ('222', '无型号', '镗刀头', '1', '', '个', 'Φ120精镗(T1051)', '');
INSERT INTO `zuchengmingxi` VALUES ('223', '5692 022-06', '水嘴', '1', '', '个', 'Φ120精镗(T1051)', '');
INSERT INTO `zuchengmingxi` VALUES ('224', 'C3-390.410-100 080A', '主刀柄', '1', '', '个', 'Φ37.5粗镗(T1052)', '');
INSERT INTO `zuchengmingxi` VALUES ('225', 'C3-391.68A-2-026084B', '镗刀接柄', '1', '', '个', 'Φ37.5粗镗(T1052)', '');
INSERT INTO `zuchengmingxi` VALUES ('226', '391.68A-2-03813C06B', '滑块', '2', '', '个', 'Φ37.5粗镗(T1052)', '');
INSERT INTO `zuchengmingxi` VALUES ('227', 'CCMT 06 02 04-KM     3005', '刀片', '2', '', '个', 'Φ37.5粗镗(T1052)', '');
INSERT INTO `zuchengmingxi` VALUES ('228', '5692 022-06', '水嘴', '1', '', '个', 'Φ37.5粗镗(T1052)', '');
INSERT INTO `zuchengmingxi` VALUES ('229', 'C4-390.410-100 090A', '主刀柄', '1', '', '个', 'Φ38精镗(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('230', 'C4-R825A-AAB084A', '精镗单元', '1', '', '个', 'Φ38精镗(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('231', 'R825A-AF11STUC06T1A', '刀夹', '1', '', '个', 'Φ38精镗(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('232', 'TCMT06 T1 04-KF     3005', '刀片', '1', '', '个', 'Φ38精镗(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('233', '5692 022-06', '水嘴', '1', '', '个', 'Φ38精镗(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('234', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ50铣刀(T1054)', '');
INSERT INTO `zuchengmingxi` VALUES ('235', 'M10×1.5', '铣刀盘', '1', '', '个', 'Φ50铣刀(T1054)', '');
INSERT INTO `zuchengmingxi` VALUES ('236', 'R390-11 T3 08M-KM    1020', '刀片', '12', '', '个', 'Φ50铣刀(T1054)', '');
INSERT INTO `zuchengmingxi` VALUES ('237', '5692 022-06', '水嘴', '1', '', '个', 'Φ50铣刀(T1054)', '');
INSERT INTO `zuchengmingxi` VALUES ('238', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ100玉米铣(T1055)', '');
INSERT INTO `zuchengmingxi` VALUES ('239', 'R390-100C8-71M', '刀盘', '1', '', '个', 'Φ100玉米铣(T1055)', '');
INSERT INTO `zuchengmingxi` VALUES ('240', 'R390-180608M-KM', '刀片', '20', '', '个', 'Φ100玉米铣(T1055)', '');
INSERT INTO `zuchengmingxi` VALUES ('241', '5692 022-06', '水嘴', '1', '', '个', 'Φ100玉米铣(T1055)', '');
INSERT INTO `zuchengmingxi` VALUES ('242', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ130精镗(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('243', 'C8-R825C-AAH077A', '精镗单元', '1', '', '个', 'Φ130精镗(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('244', 'TCMT110304-KF', '刀片', '1', '', '个', 'Φ130精镗(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('245', '5692 022-06', '水嘴', '1', '', '个', 'Φ130精镗(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('246', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ120精镗(T1056)', '');
INSERT INTO `zuchengmingxi` VALUES ('247', 'C8-R825C-AAH077A', '精镗单元', '1', '', '个', 'Φ120精镗(T1056)', '');
INSERT INTO `zuchengmingxi` VALUES ('248', 'TCMT110304-KF', '刀片', '1', '', '个', 'Φ120精镗(T1056)', '');
INSERT INTO `zuchengmingxi` VALUES ('249', '5692 022-06', '水嘴', '1', '', '个', 'Φ120精镗(T1056)', '');
INSERT INTO `zuchengmingxi` VALUES ('250', 'A10.022.32', '主刀柄', '1', '', '个', 'M10×1.5丝锥(T1113)', '');
INSERT INTO `zuchengmingxi` VALUES ('251', '393.14-32 100', '夹心', '1', '', '个', 'M10×1.5丝锥(T1113)', '');
INSERT INTO `zuchengmingxi` VALUES ('252', 'E615M10', '丝锥', '1', '', '个', 'M10×1.5丝锥(T1113)', '');
INSERT INTO `zuchengmingxi` VALUES ('253', '5692 022-06', '水嘴', '1', '', '个', 'M10×1.5丝锥(T1113)', '');
INSERT INTO `zuchengmingxi` VALUES ('254', '', '主轴延伸轴', '1', '', '个', 'T998', '');
INSERT INTO `zuchengmingxi` VALUES ('255', '', '测头', '1', '', '个', 'T999999', '');
INSERT INTO `zuchengmingxi` VALUES ('256', 'S945-563916(看不到）', '主刀柄', '1', 'L=200', '个', 'Φ100铣刀(T1001)', '');
INSERT INTO `zuchengmingxi` VALUES ('257', 'R365-100Q32-S15M', '刀盘', '1', '', '个', 'Φ100铣刀(T1001)', '');
INSERT INTO `zuchengmingxi` VALUES ('258', 'R365-1505ZNE-KM  1020', '刀片', '7', '', '个', 'Φ100铣刀(T1001)', '');
INSERT INTO `zuchengmingxi` VALUES ('259', '5692 022-06', '水嘴', '1', '', '个', 'Φ100铣刀(T1001)', '');
INSERT INTO `zuchengmingxi` VALUES ('260', 'S945-563916(890800100N60566)', '主刀柄', '1', 'L=200', '个', 'Φ100铣刀(T1002)', '');
INSERT INTO `zuchengmingxi` VALUES ('261', 'R590-100Q32A-11M', '刀盘', '1', '', '个', 'Φ100铣刀(T1002)', '');
INSERT INTO `zuchengmingxi` VALUES ('262', 'R590-1105H-ZC2-KL  CB50', '刀片', '6', '', '个', 'Φ100铣刀(T1002)', '');
INSERT INTO `zuchengmingxi` VALUES ('263', '5692 022-06', '水嘴', '1', '', '个', 'Φ100铣刀(T1002)', '');
INSERT INTO `zuchengmingxi` VALUES ('264', '392.41014-100 40 120A', '刀柄', '1', '', '个', 'Φ14.5-42/90°(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('265', '393.15-40 18', '夹心', '1', '', '个', 'Φ14.5-42/90°(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('266', '5692 022-06', '水嘴', '1', '', '个', 'Φ14.5-42/90°(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('267', '392.41014-100 40 120A', '主刀柄', '1', '', '个', 'Φ14.5-47/90°(T1004)', '');
INSERT INTO `zuchengmingxi` VALUES ('268', '393.14-40 18', '夹心', '1', '', '个', 'Φ14.5-47/90°(T1004)', '');
INSERT INTO `zuchengmingxi` VALUES ('269', '5692 022-06', '水嘴', '1', '', '个', 'Φ14.5-47/90°(T1004)', '');
INSERT INTO `zuchengmingxi` VALUES ('270', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'M16×1.5丝锥（T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('271', 'C8-391.01-80 100A', '接杆1', '1', '', '个', 'M16×1.5丝锥（T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('272', 'C8-391.01-80 100A', '接杆2', '1', '', '个', 'M16×1.5丝锥（T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('273', 'C8-391.14-32 070', '接杆3', '1', '', '个', 'M16×1.5丝锥（T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('274', '393.14-40D120×090', '夹心', '1', '', '个', 'M16×1.5丝锥（T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('275', 'ES13KM16×1.5', '丝锥', '1', '', '个', 'M16×1.5丝锥（T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('276', '5692 022-06', '水嘴', '1', '', '个', 'M16×1.5丝锥（T1005)', '');
INSERT INTO `zuchengmingxi` VALUES ('277', 'A10.022.40', 'ER刀柄', '1', 'L=160', '个', 'Φ17-40/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('278', '393.15-40 20', '夹心', '1', '', '个', 'Φ17-40/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('279', '5692 022-06', '水嘴', '1', '', '个', 'Φ17-40/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('280', 'C6-390.410-100 110A', '主刀柄', '1', 'L=180', '个', 'Φ14.5-17/90°(T1007)', '');
INSERT INTO `zuchengmingxi` VALUES ('281', 'C6-391.14-40 130', '接杆', '1', '', '个', 'Φ14.5-17/90°(T1007)', '');
INSERT INTO `zuchengmingxi` VALUES ('282', '393.14-40 18', '夹心', '1', '', '个', 'Φ14.5-17/90°(T1007)', '');
INSERT INTO `zuchengmingxi` VALUES ('283', '5692 022-06', '水嘴', '1', '', '个', 'Φ14.5-17/90°(T1007)', '');
INSERT INTO `zuchengmingxi` VALUES ('284', 'C6-390.410-100 110A', '主刀柄', '1', '', '个', 'Φ15镗刀（T1008)', '');
INSERT INTO `zuchengmingxi` VALUES ('285', 'C6-391.37A-16 075A', '接杆1', '1', '', '个', 'Φ15镗刀（T1008)', '');
INSERT INTO `zuchengmingxi` VALUES ('286', '无号(看不见）', '镗刀杆(非标）', '1', '', '个', 'Φ15镗刀（T1008)', '');
INSERT INTO `zuchengmingxi` VALUES ('287', 'TCMT 06 T1 04-KF  3215', '刀片', '1', '', '个', 'Φ15镗刀（T1008)', '');
INSERT INTO `zuchengmingxi` VALUES ('288', '5692 022-06', '水嘴', '1', '', '个', 'Φ15镗刀（T1008)', '');
INSERT INTO `zuchengmingxi` VALUES ('289', '392.41014-100 32 120A', '刀柄', '1', '', '个', 'Φ12硬钻（T1009)', '');
INSERT INTO `zuchengmingxi` VALUES ('290', '393.15-40 12', '夹心', '1', '', '个', 'Φ12硬钻（T1009)', '');
INSERT INTO `zuchengmingxi` VALUES ('291', 'R840-1200-70-A1A  1220', '硬钻', '1', '', '个', 'Φ12硬钻（T1009)', '');
INSERT INTO `zuchengmingxi` VALUES ('292', '5692 022-06', ' 水嘴', '1', '', '个', 'Φ12硬钻（T1009)', '');
INSERT INTO `zuchengmingxi` VALUES ('293', 'C6-390.410-100 110A', '主刀柄', '1', 'L=180', '个', 'Φ10.8硬钻（T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('294', 'C6-391.14-40 130', '刀杆', '1', '', '个', 'Φ10.8硬钻（T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('295', '393.15-40 12', '夹心', '1', '', '个', 'Φ10.8硬钻（T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('296', 'R840-1080-50-A1A  1220', '硬钻', '1', '', '个', 'Φ10.8硬钻（T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('297', '5692 022-06', '水嘴', '1', '', '个', 'Φ10.8硬钻（T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('298', 'C6-390.410-100 110A', '主刀柄', '1', 'L=180', '个', 'M12×1.25丝锥（T1011)', '');
INSERT INTO `zuchengmingxi` VALUES ('299', 'C6-391.14-40 130', '刀杆', '1', '', '个', 'M12×1.25丝锥（T1011)', '');
INSERT INTO `zuchengmingxi` VALUES ('300', 'ER40GB Φ9.0', '夹心', '1', '', '个', 'M12×1.25丝锥（T1011)', '');
INSERT INTO `zuchengmingxi` VALUES ('301', 'EP11M12×1.25', '丝锥', '1', '', '个', 'M12×1.25丝锥（T1011)', '');
INSERT INTO `zuchengmingxi` VALUES ('302', '5692 022-06', '水嘴', '1', '', '个', 'M12×1.25丝锥（T1011)', '');
INSERT INTO `zuchengmingxi` VALUES ('303', 'C6-390.410-100 110A', '主刀柄', '1', 'L=180', '个', 'Φ11.5-16/90°(T1012)', '');
INSERT INTO `zuchengmingxi` VALUES ('304', 'C6-391.14-40 130', '刀杆', '1', '', '个', 'Φ11.5-16/90°(T1012)', '');
INSERT INTO `zuchengmingxi` VALUES ('305', '393.15-40 14', '夹心', '1', '', '个', 'Φ11.5-16/90°(T1012)', '');
INSERT INTO `zuchengmingxi` VALUES ('306', '5692 022-06', '水嘴', '1', '', '个', 'Φ11.5-16/90°(T1012)', '');
INSERT INTO `zuchengmingxi` VALUES ('307', 'C6-390.410-100 110A', '主刀柄', '1', '', '个', 'Φ12 镗刀(T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('308', 'C6-391.02-50 110A', '接杆1', '1', '', '个', 'Φ12 镗刀(T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('309', 'C5-391.37A-12 048B', '接杆2', '1', '', '个', 'Φ12 镗刀(T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('310', 'R492.90-11-033-06-AC(看不见）', '刀杆', '1', '', '个', 'Φ12 镗刀(T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('311', 'TCMT 06 T1 04-KF  3215', '刀片', '1', '', '个', 'Φ12 镗刀(T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('312', '5692 022-06', '水嘴', '1', '', '个', 'Φ12 镗刀(T1013)', '');
INSERT INTO `zuchengmingxi` VALUES ('313', 'C6-390.410-100 110A', '主刀柄', '1', 'L=180', '个', 'Φ8.8-22/90°(T1014)', '');
INSERT INTO `zuchengmingxi` VALUES ('314', 'C6-391.02-40 130A', '接杆1', '1', '', '个', 'Φ8.8-22/90°(T1014)', '');
INSERT INTO `zuchengmingxi` VALUES ('315', '393.15-40 12', '夹心', '1', '', '个', 'Φ8.8-22/90°(T1014)', '');
INSERT INTO `zuchengmingxi` VALUES ('316', '5692 022-06', '水嘴', '1', '', '个', 'Φ8.8-22/90°(T1014)', '');
INSERT INTO `zuchengmingxi` VALUES ('317', 'C6-390.410-100 110A', '主刀柄', '1', 'L=180', '个', 'Φ8.3-85(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('318', 'C6-391.02-40 130', '接杆1', '1', '', '个', 'Φ8.3-85(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('319', '393.15-40 10', '夹心', '1', '', '个', 'Φ8.3-85(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('320', '861.1-0833-100A1-GM-GC34', '硬钻', '1', 'L=192', '个', 'Φ8.3-85(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('321', '5692 022-06', '水嘴', '1', '', '个', 'Φ8.3-85(T1015)', '');
INSERT INTO `zuchengmingxi` VALUES ('322', 'C6-390.410-100 110A', '主刀柄', '1', 'L=180', '个', 'M10×1.25丝锥(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('323', 'C6-391.14-32 130', '接杆1', '1', '', '个', 'M10×1.25丝锥(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('324', 'ER32GBΦ7.0', '夹心', '1', '', '个', 'M10×1.25丝锥(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('325', 'ES13KM10×1.25', '丝锥', '1', '', '个', 'M10×1.25丝锥(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('326', '5692 022-06', '水嘴', '1', '', '个', 'M10×1.25丝锥(T1016)', '');
INSERT INTO `zuchengmingxi` VALUES ('327', '930-HA10-HD-25-106', '主刀柄', '1', '', '个', 'Φ25铣刀(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('328', '看不见', '铣刀盘', '1', '', '个', 'Φ25铣刀(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('329', 'R390-17 04 08M-KM   1020', '刀片', '2', '', '个', 'Φ25铣刀(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('330', '5692 022-06', '水嘴', '1', '', '个', 'Φ25铣刀(T1017)', '');
INSERT INTO `zuchengmingxi` VALUES ('331', 'C6-390.410-100 110A', '主刀柄', '1', 'L=180', '个', 'Φ20.5-30/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('332', 'C6-391.27-25 070A', '接杆1', '1', '', '个', 'Φ20.5-30/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('333', '870-2050-20 KM3234', '刀片', '1', '', '个', 'Φ20.5-30/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('334', '880-03 03 W06H-P-GR 4044', '刀片', '1', '', '个', 'Φ20.5-30/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('335', '5692 022-06', '水嘴', '1', '', '个', 'Φ20.5-30/90°(T1018)', '');
INSERT INTO `zuchengmingxi` VALUES ('336', 'C6-390.410-100 110A', '主刀柄', '1', 'L=180', '个', 'M22×1.5丝锥(T1019)', '');
INSERT INTO `zuchengmingxi` VALUES ('337', 'C6-391.14-40 130', '接杆1', '1', '', '个', 'M22×1.5丝锥(T1019)', '');
INSERT INTO `zuchengmingxi` VALUES ('338', '393.14-40D180×145', '夹心', '1', '', '个', 'M22×1.5丝锥(T1019)', '');
INSERT INTO `zuchengmingxi` VALUES ('339', 'EP11KM22×1.5', '丝锥', '1', '', '个', 'M22×1.5丝锥(T1019)', '');
INSERT INTO `zuchengmingxi` VALUES ('340', '5692 022-06', '水嘴', '1', '', '个', 'M22×1.5丝锥(T1019)', '');
INSERT INTO `zuchengmingxi` VALUES ('341', '392.41027-100 40 110A', '刀柄', '1', '', '个', 'Φ34/Φ40/Φ42/15°(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('342', '890 44929R14211(看不见）', '刀杆', '1', '', '个', 'Φ34/Φ40/Φ42/15°(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('343', 'TCMT 11 03 04-KM    3215', '刀片', '3', '', '个', 'Φ34/Φ40/Φ42/15°(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('344', 'WCMX 06 T3 08 R-53 3040', '刀片', '2', '', '个', 'Φ34/Φ40/Φ42/15°(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('345', '5692 022-06', '水嘴', '1', '', '个', 'Φ34/Φ40/Φ42/15°(T1020)', '');
INSERT INTO `zuchengmingxi` VALUES ('346', 'C4-390.410-100 40 110A', '主刀柄', '1', '', '个', 'Φ42 镗刀(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('347', 'C4-R825B-AAC066A', '接杆', '1', '', '个', 'Φ42 镗刀(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('348', 'R-AF17STUC0902', '镗刀夹', '1', '', '个', 'Φ42 镗刀(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('349', 'TCMT 09 02 04-KF    3005', '刀片', '1', '', '个', 'Φ42 镗刀(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('350', '5692 022-06', '水嘴', '1', '', '个', 'Φ42 镗刀(T1021)', '');
INSERT INTO `zuchengmingxi` VALUES ('351', 'S945-561753', ' 非标刀柄', '1', 'L=250', '个', 'Φ19.5/Φ22.5/45°(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('352', 'S931-561751（看不见）', '非标阶梯刀杆', '1', 'L=85', '个', 'Φ19.5/Φ22.5/45°(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('353', '880-03 03-05H-CM1044', '刀片', '2', '', '个', 'Φ19.5/Φ22.5/45°(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('354', '880-03 03 W06H-P-GR 4044', '刀片', '2', '', '个', 'Φ19.5/Φ22.5/45°(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('355', '5692 022-06', '水嘴', '1', '', '个', 'Φ19.5/Φ22.5/45°(T1022)', '');
INSERT INTO `zuchengmingxi` VALUES ('356', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ20 镗刀(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('357', 'C8-391.02-63 080A', '接杆1', '1', '', '个', 'Φ20 镗刀(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('358', 'C6-391.37A-16 075A', '接杆2', '1', '', '个', 'Φ20 镗刀(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('359', 'R429U-A16-17056 TC09A（看不见）', '刀杆', '1', '', '个', 'Φ20 镗刀(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('360', 'TCMT 09 02 04-KF    3005', '刀片', '1', '', '个', 'Φ20 镗刀(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('361', '5692 022-06', '水嘴', '1', '', '个', 'Φ20 镗刀(T1023)', '');
INSERT INTO `zuchengmingxi` VALUES ('362', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ169.5/90°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('363', '890.450232R58410', '非标阶梯刀杆', '1', ' L=140', '个', 'Φ169.5/90°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('364', 'STGCL12CA-16-M', '刀夹', '2', '', '个', 'Φ169.5/90°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('365', 'STSCL12CA-16-M', '刀夹', '1', '', '个', 'Φ169.5/90°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('366', 'TCMT 16 T3 08-KR  3210', '刀片', '3', '', '个', 'Φ169.5/90°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('367', '5692 022-06', '水嘴', '1', '', '个', 'Φ169.5/90°(T1024)', '');
INSERT INTO `zuchengmingxi` VALUES ('368', '345-11-9003-206344', '主刀柄', '1', 'L=275', '个', 'Φ170H8(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('369', '344-C8-390.01S-80 180', '接杆', '1', 'L=180', '个', 'Φ170H8(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('370', 'C8-R822XLS17-AJ 070', '接杆', '1', '', '个', 'Φ170H8(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('371', 'A34-R826C-E.017', '接杆', '1', '', '个', 'Φ170H8(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('372', 'C-AF23STUC1103A', '刀夹', '1', '', '个', 'Φ170H8(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('373', 'S17-R825XLA34-020', '配重', '2', '', '个', 'Φ170H8(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('374', 'TCMT 09 02 04-KF    3005', '刀片', '1', '', '个', 'Φ170H8(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('375', '5692 022-06', '水嘴', '1', '', '个', 'Φ170H8(T1025)', '');
INSERT INTO `zuchengmingxi` VALUES ('376', '345-11-9003-206344', '主刀柄', '1', ' L=275', '个', 'Φ79.5/90°(T1026)', '');
INSERT INTO `zuchengmingxi` VALUES ('377', '8900450232R58423', '非标刀杆', '1', '', '个', 'Φ79.5/90°(T1026)', '');
INSERT INTO `zuchengmingxi` VALUES ('378', 'STFCR12CA-16-M', '刀夹', '1', '', '个', 'Φ79.5/90°(T1026)', '');
INSERT INTO `zuchengmingxi` VALUES ('379', 'STFCR12CA-16-M', '刀夹', '1', '', '个', 'Φ79.5/90°(T1026)', '');
INSERT INTO `zuchengmingxi` VALUES ('380', 'TCMT 16 T3 08-KM  3210', '刀片', '2', '', '个', 'Φ79.5/90°(T1026)', '');
INSERT INTO `zuchengmingxi` VALUES ('381', 'TCMT 11 T3 08-KM 3210', '刀片', '1', '', '个', 'Φ79.5/90°(T1026)', '');
INSERT INTO `zuchengmingxi` VALUES ('382', 'STSCR 10CA-11-B1', '刀夹', '1', '', '个', 'Φ79.5/90°(T1026)', '');
INSERT INTO `zuchengmingxi` VALUES ('383', '5692 022-06', '水嘴', '1', '', '个', 'Φ79.5/90°(T1026)', '');
INSERT INTO `zuchengmingxi` VALUES ('384', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ89.5/90°(T1027)', '');
INSERT INTO `zuchengmingxi` VALUES ('385', '890450232R58412', '非标阶梯刀杆', '1', '', '个', 'Φ89.5/90°(T1027)', '');
INSERT INTO `zuchengmingxi` VALUES ('386', 'TCMT 16 T3 08-KM  3210', '刀片', '2', '', '个', 'Φ89.5/90°(T1027)', '');
INSERT INTO `zuchengmingxi` VALUES ('387', 'TCMT 11 T3 08-KM 3210', '刀片', '1', '', '个', 'Φ89.5/90°(T1027)', '');
INSERT INTO `zuchengmingxi` VALUES ('388', 'STFCR12CA-16-M', '刀夹', '2', '', '个', 'Φ89.5/90°(T1027)', '');
INSERT INTO `zuchengmingxi` VALUES ('389', 'STSCR12CA-16-M', '刀夹', '1', '', '个', 'Φ89.5/90°(T1027)', '');
INSERT INTO `zuchengmingxi` VALUES ('390', '5692 022-06', '水嘴', '1', '', '个', 'Φ89.5/90°(T1027)', '');
INSERT INTO `zuchengmingxi` VALUES ('391', '345-11-9003-206344', '主刀柄', '1', 'L=275', '个', 'Φ100铣刀(T1028)', '');
INSERT INTO `zuchengmingxi` VALUES ('392', 'C8-391.05CD-32 320', '接杆', '1', '', '个', 'Φ100铣刀(T1028)', '');
INSERT INTO `zuchengmingxi` VALUES ('393', 'R390-100Q32-17M', '铣刀盘', '1', 'Φ100,z=7', '个', 'Φ100铣刀(T1028)', '');
INSERT INTO `zuchengmingxi` VALUES ('394', 'R390-17 04 08M-KM  1020', '刀片 ', '7', '', '个', 'Φ100铣刀(T1028)', '');
INSERT INTO `zuchengmingxi` VALUES ('395', '5692 022-06', '水嘴', '1', '', '个', 'Φ100铣刀(T1028)', '');
INSERT INTO `zuchengmingxi` VALUES ('396', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ119.5/90°(T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('397', '890450232R58413', '非标阶梯刀杆', '1', '', '个', 'Φ119.5/90°(T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('398', 'TCMT 16 T3 08-KM  3210', '刀片', '3', '', '个', 'Φ119.5/90°(T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('399', 'STFCR12CA-16-M', '刀夹', '2', '', '个', 'Φ119.5/90°(T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('400', 'STSCR12CA-16-M', '刀夹', '1', '', '个', 'Φ119.5/90°(T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('401', '5692 022-06', '水嘴', '1', '', '个', 'Φ119.5/90°(T1029)', '');
INSERT INTO `zuchengmingxi` VALUES ('402', '345-11-9003-206344', '主刀柄', '1', ' L=275 ', '个', 'Φ139.5/90°L550(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('403', '344-C8-391.01S-80 180', '接杆', '1', 'L=180', '个', 'Φ139.5/90°L550(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('404', '890450232R58424', '非标刀杆', '1', '', '个', 'Φ139.5/90°L550(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('405', 'TCMT 16 T3 08-KM  3210', '刀片', '4', '', '个', 'Φ139.5/90°L550(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('406', 'STFCR12CA-16-M', '刀夹', '4', '', '个', 'Φ139.5/90°L550(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('407', '5692 022-06', '水嘴', '1', '', '个', 'Φ139.5/90°L550(T1030)', '');
INSERT INTO `zuchengmingxi` VALUES ('408', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ28/Φ36(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('409', 'C5-391.02-40 065A', '接杆1', '1', '', '个', 'Φ28/Φ36(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('410', 'S931-561614', '非标阶梯刀杆', '1', '', '个', 'Φ28/Φ36(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('411', '880-05 05H-C-GR  1044', '中心刀片', '1', '', '个', 'Φ28/Φ36(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('412', '880-05 03 W08H-P-GR  4024', '中心刀片', '1', '', '个', 'Φ28/Φ36(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('413', 'TCMT 11 T3 08-KM 3215', '刀片', '2', '', '个', 'Φ28/Φ36(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('414', '5692 022-06', '水嘴', '1', '', '个', 'Φ28/Φ36(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('415', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ29.5/Φ37.7(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('416', 'C5-391.02-32 060A', '接杆1', '1', '', '个', 'Φ29.5/Φ37.7(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('417', 'C3-391.68A-3-032 C34B', '镗刀接柄', '1', '', '个', 'Φ29.5/Φ37.7(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('418', '391.68F-3-04716 TC11B', '滑块', '2', '', '个', 'Φ29.5/Φ37.7(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('419', 'TCMT 11 T3 08-KM 3215', '刀片', '2', '', '个', 'Φ29.5/Φ37.7(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('420', '5692 022-06', '水嘴', '1', '', '个', 'Φ29.5/Φ37.7(T1032)', '');
INSERT INTO `zuchengmingxi` VALUES ('421', '890450232R58416', '非标刀杆（整体）', '1', '', '个', 'Φ29.95/Φ37.95（T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('422', '看不见', '支承块', '4', '', '个', 'Φ29.95/Φ37.95（T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('423', '看不见', '刀夹', '4', '', '个', 'Φ29.95/Φ37.95（T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('424', 'TCMT 11 03 04-KF    3005', '刀片', '2', '', '个', 'Φ29.95/Φ37.95（T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('425', '5692 022-06', '水嘴', '1', '', '个', 'Φ29.95/Φ37.95（T1033)', '');
INSERT INTO `zuchengmingxi` VALUES ('426', 'S-L148CX2-29/32/43 315//HSK100A', '减振镗刀杆', '1', '', '个', 'Φ38(T1034)', '');
INSERT INTO `zuchengmingxi` VALUES ('427', 'L148C-13-11 03（看不见）', '精镗刀头', '2', '', '个', 'Φ38(T1034)', '');
INSERT INTO `zuchengmingxi` VALUES ('428', 'TCMT 06 T 104-KF    3005', '刀片', '2', '', '个', 'Φ38(T1034)', '');
INSERT INTO `zuchengmingxi` VALUES ('429', '5692 022-06', '水嘴', '1', '', '个', 'Φ38(T1034)', '');
INSERT INTO `zuchengmingxi` VALUES ('430', '345-11-9003-206344', '主刀柄', '1', 'L=275', '个', 'Φ80/Φ90 H7 L420(T1035)', '');
INSERT INTO `zuchengmingxi` VALUES ('431', '890450232R58422', '非标刀杆', '1', '', '个', 'Φ80/Φ90 H7 L420(T1035)', '');
INSERT INTO `zuchengmingxi` VALUES ('432', 'L148C-13-11 03（看不见）', '精镗刀头', '2', '', '个', 'Φ80/Φ90 H7 L420(T1035)', '');
INSERT INTO `zuchengmingxi` VALUES ('433', 'TCMT 11 03 04-KF    3005', '刀片', '2', '', '个', 'Φ80/Φ90 H7 L420(T1035)', '');
INSERT INTO `zuchengmingxi` VALUES ('434', '5692 022-06', '水嘴', '1', '', '个', 'Φ80/Φ90 H7 L420(T1035)', '');
INSERT INTO `zuchengmingxi` VALUES ('435', '345-11-9003-206344', '主刀柄', '1', 'L=275', '个', 'Φ140/Φ120 N7 L420(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('436', '890450232R58421', '非标刀杆', '1', '', '个', 'Φ140/Φ120 N7 L420(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('437', 'L148C-13-11 03（看不见）', '微调单元', '2', '', '个', 'Φ140/Φ120 N7 L420(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('438', 'TCMT 11 03 04-KF    3005', '刀片', '2', '', '个', 'Φ140/Φ120 N7 L420(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('439', '5692 022-06', '水嘴', '1', '', '个', 'Φ63 L420(T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('440', '345-11-9003-206344', '主刀柄', '1', 'L=275', '个', 'Φ63 L420(T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('441', 'C6-391.05CD-22 200', '接杆', '1', '', '个', 'Φ63 L420(T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('442', '328-063Q22-13M', ' 切槽刀盘', '1', '', '个', 'Φ63 L420(T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('443', '328r13-26545-GC   1025', '刀片', '5', '', '个', 'Φ63 L420(T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('444', '5692 022-06', '水嘴', '1', '', '个', 'Φ63 L420(T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('445', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ40 L250(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('446', 'C8-391.02-50 080A', '接杆1', '1', '', '个', 'Φ40 L250(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('447', '890450272R58420  S912-561756', '刀杆', '1', '', '个', 'Φ40 L250(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('448', 'CCMT 09 T3 08-KM   3215', '刀片', '2', '', '个', 'Φ40 L250(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('449', 'SCFCR 10CA-09', '刀夹', '2', '', '个', 'Φ40 L250(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('450', '5692 022-06', '水嘴', '1', '', '个', 'Φ40 L250(T1038)', '');
INSERT INTO `zuchengmingxi` VALUES ('451', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ50 L250(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('452', 'C8-391.02-50 080A', '接杆1', '1', '', '个', 'Φ50 L250(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('453', '890 450272R58419  S912-561755', '刀杆', '1', '', '个', 'Φ50 L250(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('454', 'CCMT 09 T3 08-KM   3215', '刀片', '2', '', '个', 'Φ50 L250(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('455', 'SCFCR10CA-09', '刀夹', '2', '', '个', 'Φ50 L250(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('456', '5692 022-06', '水嘴', '1', '', '个', 'Φ50 L250(T1039)', '');
INSERT INTO `zuchengmingxi` VALUES ('457', '392.41027-100 40 100A', '刀柄', '1', '', '个', 'Φ32.5/90°(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('458', 'DCI 32.65（看不见）', '非标阶梯刀杆', '1', '', '个', 'Φ32.5/90°(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('459', '880-06 04 06H-C-GR  1044', '中心刀片', '1', '', '个', 'Φ32.5/90°(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('460', '880-06 04 W10H-P-GR  4044', '中心刀片', '1', '', '个', 'Φ32.5/90°(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('461', '880-04 03 W05H-P-GM  4044', '中心刀片', '1', '', '个', 'Φ32.5/90°(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('462', '5692 022-06', '水嘴', '1', '', '个', 'Φ32.5/90°(T1040)', '');
INSERT INTO `zuchengmingxi` VALUES ('463', '5692 022-06', '水嘴', '1', '', '个', 'Φ6.8阶梯钻(T1041)', '');
INSERT INTO `zuchengmingxi` VALUES ('464', '392.41014-100 32 120A', '刀柄', '1', '', '个', 'Φ6.8阶梯钻(T1041)', '');
INSERT INTO `zuchengmingxi` VALUES ('465', 'ER40-DCB 10.0-9.5', '夹心', '1', '', '个', 'Φ6.8阶梯钻(T1041)', '');
INSERT INTO `zuchengmingxi` VALUES ('466', 'ST0766 Φ6.8×20×120°×Φ10×103', '非标钻头', '1', '', '个', 'Φ6.8阶梯钻(T1041)', '');
INSERT INTO `zuchengmingxi` VALUES ('467', '5692 022-06', '水嘴', '1', '', '个', 'M8丝锥(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('468', '392.41014-100 32 110A', '刀柄', '1', '', '个', 'M8丝锥(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('469', '05.027.964', '钢性夹心', '1', '', '个', 'M8丝锥(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('470', 'E446M8', '丝锥', '1', '', '个', 'M8丝锥(T1042)', '');
INSERT INTO `zuchengmingxi` VALUES ('471', '5692 022-06', '水嘴', '1', '', '个', 'Φ20阶梯钻(T1043)', '');
INSERT INTO `zuchengmingxi` VALUES ('472', 'C6-390.410-100 110A', '主柄', '1', '', '个', 'Φ20阶梯钻(T1043)', '');
INSERT INTO `zuchengmingxi` VALUES ('473', 'C6-391.14-40 130', '接杆', '1', '', '个', 'Φ20阶梯钻(T1043)', '');
INSERT INTO `zuchengmingxi` VALUES ('474', '393.15-32 20', '夹心 ', '1', '', '个', 'Φ20阶梯钻(T1043)', '');
INSERT INTO `zuchengmingxi` VALUES ('475', 'ST0759 Φ20×78×Φ20×131', '非标钻头', '1', '', '个', 'Φ20阶梯钻(T1043)', '');
INSERT INTO `zuchengmingxi` VALUES ('476', '5692 022-06', '水嘴', '1', '', '个', 'Φ9阶梯钻(T1044)', '');
INSERT INTO `zuchengmingxi` VALUES ('477', '392.41014-100 32 100A', '刀柄', '1', '', '个', 'Φ9阶梯钻(T1044)', '');
INSERT INTO `zuchengmingxi` VALUES ('478', '393.15-32 12', '夹心', '1', '', '个', 'Φ9阶梯钻(T1044)', '');
INSERT INTO `zuchengmingxi` VALUES ('479', 'ST0767 Φ9×20×120°×Φ12×103', '非标钻头', '1', '', '个', 'Φ9阶梯钻(T1044)', '');
INSERT INTO `zuchengmingxi` VALUES ('480', '5692 022-06', '水嘴', '1', '', '个', 'M10×1丝锥(T1045)', '');
INSERT INTO `zuchengmingxi` VALUES ('481', '392.41014-100 32 100A', '刀柄', '1', '', '个', 'M10×1丝锥(T1045)', '');
INSERT INTO `zuchengmingxi` VALUES ('482', 'ER32-GB  Φ7.0-5.5', '钢性夹心', '1', '', '个', 'M10×1丝锥(T1045)', '');
INSERT INTO `zuchengmingxi` VALUES ('483', 'ES13KM10×1.0', '丝锥', '1', '', '个', 'M10×1丝锥(T1045)', '');
INSERT INTO `zuchengmingxi` VALUES ('484', '5692 022-06', '水嘴', '1', '', '个', 'Φ5阶梯钻(T1046)', '');
INSERT INTO `zuchengmingxi` VALUES ('485', '392.41014-100 32 100A', '刀柄', '1', '', '个', 'Φ5阶梯钻(T1046)', '');
INSERT INTO `zuchengmingxi` VALUES ('486', '393.15-32 10', '夹心', '1', '', '个', 'Φ5阶梯钻(T1046)', '');
INSERT INTO `zuchengmingxi` VALUES ('487', 'ST0768 Φ5×20×120°×Φ10×122', '复合钻头', '1', '', '个', 'Φ5阶梯钻(T1046)', '');
INSERT INTO `zuchengmingxi` VALUES ('488', '5692 022-06', '水嘴', '1', '', '个', 'M6丝锥(T1047)', '');
INSERT INTO `zuchengmingxi` VALUES ('489', '392.41014-100 32 100A', '刀柄', '1', '', '个', 'M6丝锥(T1047)', '');
INSERT INTO `zuchengmingxi` VALUES ('490', '05.027.862(看不到）', '钢性夹心', '1', '', '个', 'M6丝锥(T1047)', '');
INSERT INTO `zuchengmingxi` VALUES ('491', 'E616M6', '丝锥', '1', '', '个', 'M6丝锥(T1047)', '');
INSERT INTO `zuchengmingxi` VALUES ('492', '5692 022-06', '水嘴', '1', '', '个', 'Φ16.5阶梯钻(T1048)', '');
INSERT INTO `zuchengmingxi` VALUES ('493', 'G25 25000A10.022.40', '钢性夹头', '1', '', '个', 'Φ16.5阶梯钻(T1048)', '');
INSERT INTO `zuchengmingxi` VALUES ('494', '393.15-40 20', '夹心', '1', '', '个', 'Φ16.5阶梯钻(T1048)', '');
INSERT INTO `zuchengmingxi` VALUES ('495', 'ST0762 Φ16.5×42×120°×Φ20×153', '复合钻头', '1', '', '个', 'Φ16.5阶梯钻(T1048)', '');
INSERT INTO `zuchengmingxi` VALUES ('496', '5692 022-06', '水嘴', '1', '', '个', 'M18×1.5丝锥(T1049)', '');
INSERT INTO `zuchengmingxi` VALUES ('497', 'G25 2500 0A10.022.40', '钢性夹头', '1', '', '个', 'M18×1.5丝锥(T1049)', '');
INSERT INTO `zuchengmingxi` VALUES ('498', '393.14-40 D140×112', '钢性夹心', '1', '', '个', 'M18×1.5丝锥(T1049)', '');
INSERT INTO `zuchengmingxi` VALUES ('499', 'LS-SP M18×1.5', '丝锥', '1', '', '个', 'M18×1.5丝锥(T1049)', '');
INSERT INTO `zuchengmingxi` VALUES ('500', '5692 022-06', '水嘴', '1', '', '个', 'Φ11.8阶梯钻(T1050)', '');
INSERT INTO `zuchengmingxi` VALUES ('501', '392.41014-100 40 120A', '刀柄', '1', '', '个', 'Φ11.8阶梯钻(T1050)', '');
INSERT INTO `zuchengmingxi` VALUES ('502', '393.15-40 14', '夹心', '1', '', '个', 'Φ11.8阶梯钻(T1050)', '');
INSERT INTO `zuchengmingxi` VALUES ('503', 'ST0769 Φ11.8×14×120°×Φ14×120', '复合钻头', '1', '', '个', 'Φ11.8阶梯钻(T1050)', '');
INSERT INTO `zuchengmingxi` VALUES ('504', '5692 022-06', '水嘴', '1', '', '个', 'Φ12F9-铰刀 (T1051)', '');
INSERT INTO `zuchengmingxi` VALUES ('505', '392.41014-100 40 120A', '刀柄', '1', '', '个', 'Φ12F9-铰刀 (T1051)', '');
INSERT INTO `zuchengmingxi` VALUES ('506', '393.15-40 12', '夹心', '1', '', '个', 'Φ12F9-铰刀 (T1051)', '');
INSERT INTO `zuchengmingxi` VALUES ('507', 'TM435.B-XF-435-XF.12', '铰刀', '1', '', '个', 'Φ12F9-铰刀 (T1051)', '');
INSERT INTO `zuchengmingxi` VALUES ('508', '5692 022-06', '水嘴', '1', '', '个', '  Φ12立铣刀 (T1052)', '');
INSERT INTO `zuchengmingxi` VALUES ('509', '392.41014-100 40 120A', '刀柄', '1', '', '个', '  Φ12立铣刀 (T1052)', '');
INSERT INTO `zuchengmingxi` VALUES ('510', '393.15-40 12', '夹心', '1', '', '个', '  Φ12立铣刀 (T1052)', '');
INSERT INTO `zuchengmingxi` VALUES ('511', '2P340-1200-PA       1630', '立铣刀', '1', '', '个', '  Φ12立铣刀 (T1052)', '');
INSERT INTO `zuchengmingxi` VALUES ('512', '5692 022-06', '水嘴', '1', '', '个', '镗刀(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('513', 'C4-390.410-100 090A', '主刀柄', '1', '', '个', '镗刀(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('514', 'C4-391.02-32 055A', '接柄', '1', '', '个', '镗刀(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('515', 'C3-391.68A-3-032034B', '接柄', '1', '', '个', '镗刀(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('516', '391.68F-3-04716TC11B', '滑块', '2', '', '个', '镗刀(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('517', 'TCMT 11 T3 08-KM 3215', '刀片', '2', '', '个', '镗刀(T1053)', '');
INSERT INTO `zuchengmingxi` VALUES ('518', '5692 022-06', '水嘴', '1', '', '个', 'Φ15镗刀(T1054)', '');
INSERT INTO `zuchengmingxi` VALUES ('519', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ15镗刀(T1054)', '');
INSERT INTO `zuchengmingxi` VALUES ('520', 'C5-391.37A-12 048B', '接柄', '1', '', '个', 'Φ15镗刀(T1054)', '');
INSERT INTO `zuchengmingxi` VALUES ('521', 'R429.90-14-040-09（看不见）', '镗刀杆', '1', '', '个', 'Φ15镗刀(T1054)', '');
INSERT INTO `zuchengmingxi` VALUES ('522', 'TPMT090204-KF', '刀片', '1', '', '个', 'Φ15镗刀(T1054)', '');
INSERT INTO `zuchengmingxi` VALUES ('523', '5692 022-06', '水嘴', '1', '', '个', 'Φ44玉米铣(T1055)', '');
INSERT INTO `zuchengmingxi` VALUES ('524', 'C4-390.410-100 090A', '主刀柄', '1', '', '个', 'Φ44玉米铣(T1055)', '');
INSERT INTO `zuchengmingxi` VALUES ('525', 'R390-044C4-45M', '刀盘', '1', '', '个', 'Φ44玉米铣(T1055)', '');
INSERT INTO `zuchengmingxi` VALUES ('526', 'R390-11T308M-KM', '刀片', '15', '', '个', 'Φ44玉米铣(T1055)', '');
INSERT INTO `zuchengmingxi` VALUES ('527', '5692 022-06', '水嘴', '1', '', '个', 'Φ16立铣刀(T1056)', '');
INSERT INTO `zuchengmingxi` VALUES ('528', 'G25 25000 A10.022.32', '主刀柄', '1', '', '个', 'Φ16立铣刀(T1056)', '');
INSERT INTO `zuchengmingxi` VALUES ('529', 'ER32-16', '夹心', '1', '', '个', 'Φ16立铣刀(T1056)', '');
INSERT INTO `zuchengmingxi` VALUES ('530', '2P340-1600-PA', '立铣刀', '1', '', '个', 'Φ16立铣刀(T1056)', '');
INSERT INTO `zuchengmingxi` VALUES ('531', '5692 022-06', '水嘴', '1', '', '个', 'Φ25U钻(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('532', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'Φ25U钻(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('533', 'C5-391.01-50 100A', '接杆', '3', '', '个', 'Φ25U钻(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('534', 'C5-391.27-25 071', '侧压夹头', '1', '', '个', 'Φ25U钻(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('535', '880-D2500L25-05', 'U钻', '1', '', '个', 'Φ25U钻(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('536', '880-050305H-C-GM', '中心刀片', '1', '', '个', 'Φ25U钻(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('537', '880-0503W05H-P-GM', '周边刀片', '1', '', '个', 'Φ25U钻(T1057)', '');
INSERT INTO `zuchengmingxi` VALUES ('538', '5692 022-06', '水嘴', '1', '', '个', 'Φ80铣刀(T1058)', '');
INSERT INTO `zuchengmingxi` VALUES ('539', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'Φ80铣刀(T1058)', '');
INSERT INTO `zuchengmingxi` VALUES ('540', 'C8-391.06-27 320', '接杆', '1', '', '个', 'Φ80铣刀(T1058)', '');
INSERT INTO `zuchengmingxi` VALUES ('541', 'R390-080Q27-17M', '铣刀盘', '1', '', '个', 'Φ80铣刀(T1058)', '');
INSERT INTO `zuchengmingxi` VALUES ('542', 'R390-170408M-KM 3040', '刀片', '6', '', '个', 'Φ80铣刀(T1058)', '');
INSERT INTO `zuchengmingxi` VALUES ('543', '5692 022-06', '水嘴', '1', '', '个', 'Φ17阶梯钻(T1063)', '');
INSERT INTO `zuchengmingxi` VALUES ('544', 'C6-390.410-100 110A', '主刀柄', '1', '', '个', 'Φ17阶梯钻(T1063)', '');
INSERT INTO `zuchengmingxi` VALUES ('545', 'C6-391.27-25 070A', '侧压夹头', '1', '', '个', 'Φ17阶梯钻(T1063)', '');
INSERT INTO `zuchengmingxi` VALUES ('546', 'TM870.2.1-553751（看不见）', '刀杆', '1', '', '个', 'Φ17阶梯钻(T1063)', '');
INSERT INTO `zuchengmingxi` VALUES ('547', '870-1700-17-KM 3234', '刀片', '1', '', '个', 'Φ17阶梯钻(T1063)', '');
INSERT INTO `zuchengmingxi` VALUES ('548', '5692-022-06', '水嘴', '1', '', '个', 'Φ20.5U钻(T1100)', '');
INSERT INTO `zuchengmingxi` VALUES ('549', 'C6-390.410-100 110A', '主刀柄', '1', '', '个', 'Φ20.5U钻(T1100)', '');
INSERT INTO `zuchengmingxi` VALUES ('550', 'C6-391.01-63 100A', '接杆', '1', '', '个', 'Φ20.5U钻(T1100)', '');
INSERT INTO `zuchengmingxi` VALUES ('551', 'C6-391.27-32 075', '阶梯接杆', '1', '', '个', 'Φ20.5U钻(T1100)', '');
INSERT INTO `zuchengmingxi` VALUES ('552', '880-D2050L25-05', 'U钻刀杆', '1', '', '个', 'Φ20.5U钻(T1100)', '');
INSERT INTO `zuchengmingxi` VALUES ('553', '880-030305H-C-GM', '中心刀片', '1', '', '个', 'Φ20.5U钻(T1100)', '');
INSERT INTO `zuchengmingxi` VALUES ('554', '880-0303W05H-P-GM', '周边刀片', '1', '', '个', 'Φ20.5U钻(T1100)', '');
INSERT INTO `zuchengmingxi` VALUES ('555', '5692-022-06', '水嘴', '1', '', '个', 'M22*1.5丝锥(T1101)', '');
INSERT INTO `zuchengmingxi` VALUES ('556', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'M22*1.5丝锥(T1101)', '');
INSERT INTO `zuchengmingxi` VALUES ('557', 'C8-391.02-63 080A', '阶梯接杆', '1', '', '个', 'M22*1.5丝锥(T1101)', '');
INSERT INTO `zuchengmingxi` VALUES ('558', 'C6-391.02-50 110A', '接杆', '1', '', '个', 'M22*1.5丝锥(T1101)', '');
INSERT INTO `zuchengmingxi` VALUES ('559', 'C5-391.14-40 060', '刚性夹头', '1', '', '个', 'M22*1.5丝锥(T1101)', '');
INSERT INTO `zuchengmingxi` VALUES ('560', '393.14-40D180X145', '夹心', '1', '', '个', 'M22*1.5丝锥(T1101)', '');
INSERT INTO `zuchengmingxi` VALUES ('561', 'EP11M22X1.5', '丝锥', '1', '', '个', 'M22*1.5丝锥(T1101)', '');
INSERT INTO `zuchengmingxi` VALUES ('562', '5692 022-06', '水嘴', '1', '', '个', 'φ37U钻（T1102）', '');
INSERT INTO `zuchengmingxi` VALUES ('563', '392.41020-100 40 120A', '主刀柄', '1', '', '个', 'φ37U钻（T1102）', '');
INSERT INTO `zuchengmingxi` VALUES ('564', '880-D3700L40-05', 'U钻刀杆', '1', '', '个', 'φ37U钻（T1102）', '');
INSERT INTO `zuchengmingxi` VALUES ('565', '880-070406H-C-GM', '中心刀片', '1', '', '个', 'φ37U钻（T1102）', '');
INSERT INTO `zuchengmingxi` VALUES ('566', '880-0704W06H-P-GM', '周边刀片', '1', '', '个', 'φ37U钻（T1102）', '');
INSERT INTO `zuchengmingxi` VALUES ('567', '5692 022-06', '水嘴', '1', '', '个', 'M39螺纹铣刀（T1103）', '');
INSERT INTO `zuchengmingxi` VALUES ('568', 'C8-390.410-100 120A', '主刀柄', '1', '', '个', 'M39螺纹铣刀（T1103）', '');
INSERT INTO `zuchengmingxi` VALUES ('569', 'C8-391.02-50 080A', '阶梯接杆', '1', '', '个', 'M39螺纹铣刀（T1103）', '');
INSERT INTO `zuchengmingxi` VALUES ('570', 'C5-391.27-25 071', '侧压夹头', '1', '', '个', 'M39螺纹铣刀（T1103）', '');
INSERT INTO `zuchengmingxi` VALUES ('571', 'SR0021H21', '刀杆', '1', '', '个', 'M39螺纹铣刀（T1103）', '');
INSERT INTO `zuchengmingxi` VALUES ('572', '21I2.0ISO MT7', '螺纹刀片', '1', '', '个', 'M39螺纹铣刀（T1103）', '');
INSERT INTO `zuchengmingxi` VALUES ('573', '5692 022-06', '水嘴', '1', '', '个', 'φ32玉米铣T1104', '');
INSERT INTO `zuchengmingxi` VALUES ('574', 'C5-390.410-100 100A', '主刀柄', '1', '', '个', 'φ32玉米铣T1104', '');
INSERT INTO `zuchengmingxi` VALUES ('575', 'C5-391.01-50 080A', '接杆', '1', '', '个', 'φ32玉米铣T1104', '');
INSERT INTO `zuchengmingxi` VALUES ('576', 'R390-032C5-36L', '铣刀盘', '1', '', '个', 'φ32玉米铣T1104', '');
INSERT INTO `zuchengmingxi` VALUES ('577', 'R390-11T308M-KM', '刀片', '8', '', '个', 'φ32玉米铣T1104', '');
INSERT INTO `zuchengmingxi` VALUES ('578', '', '测头', '1', '', '个', '', '');
INSERT INTO `zuchengmingxi` VALUES ('579', 'R220.96-0080-08-7A', '方肩铣刀7刃', '1', '', '个', 'D80 铣刀(T185)', '');
INSERT INTO `zuchengmingxi` VALUES ('580', 'XNEX080608TR-MD15.MK2050', '刀片', '7', '', '个', 'D80 铣刀(T185)', '');
INSERT INTO `zuchengmingxi` VALUES ('581', 'E9306552527160', 'HSKA100铣刀刀柄', '1', '', '个', 'D80 铣刀(T185)', '');
INSERT INTO `zuchengmingxi` VALUES ('582', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'D80 铣刀(T185)', '');
INSERT INTO `zuchengmingxi` VALUES ('583', 'R220.96-0063-08-6A-27', '方肩铣刀6刃', '1', '', '个', 'D63 铣刀(T101)', '');
INSERT INTO `zuchengmingxi` VALUES ('584', 'XNEX080608TR-MD15.MK2050', '刀片', '6', '', '个', 'D63 铣刀(T101)', '');
INSERT INTO `zuchengmingxi` VALUES ('585', 'E9306552527100', 'HSKA100铣刀刀柄', '1', '', '个', 'D63 铣刀(T101)', '');
INSERT INTO `zuchengmingxi` VALUES ('586', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'D63 铣刀(T101)', '');
INSERT INTO `zuchengmingxi` VALUES ('587', 'D30*D32*126', '非标立铣刀', '1', '', '个', 'Φ30 铣刀(T102)', '');
INSERT INTO `zuchengmingxi` VALUES ('588', '4736 32.100', '热胀刀柄', '1', '', '个', 'Φ30 铣刀(T102)', '');
INSERT INTO `zuchengmingxi` VALUES ('589', '4949 24.100', '冷却管', '1', '', '个', 'Φ30 铣刀(T102)', '');
INSERT INTO `zuchengmingxi` VALUES ('590', 'C5-390.410-100100A', 'HSK Capto刀柄', '1', '', '个', 'Φ63 粗镗刀(T103)', '');
INSERT INTO `zuchengmingxi` VALUES ('591', 'C5-391.68A-5-050 044B', '接柄', '1', '', '个', 'Φ63 粗镗刀(T103)', '');
INSERT INTO `zuchengmingxi` VALUES ('592', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'Φ63 粗镗刀(T103)', '');
INSERT INTO `zuchengmingxi` VALUES ('593', '5692022-06', '冷却液套管', '1', '', '个', 'Φ63 粗镗刀(T103)', '');
INSERT INTO `zuchengmingxi` VALUES ('594', '391.68A-5-070 26T16B', '滑块', '2', '', '个', 'Φ63 粗镗刀(T103)', '');
INSERT INTO `zuchengmingxi` VALUES ('595', 'C5-390.410-100100A', 'HSKCapto刀柄', '1', '', '个', 'Φ67.7半精镗(T104)', '');
INSERT INTO `zuchengmingxi` VALUES ('596', 'C5-391.68A-5-050 044B', '接柄', '1', '', '个', 'Φ67.7半精镗(T104)', '');
INSERT INTO `zuchengmingxi` VALUES ('597', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'Φ67.7半精镗(T104)', '');
INSERT INTO `zuchengmingxi` VALUES ('598', '5692022-06', '冷却液套管', '1', '', '个', 'Φ67.7半精镗(T104)', '');
INSERT INTO `zuchengmingxi` VALUES ('599', '391.68A-5-070 26T16B', '滑块', '2', '', '个', 'Φ67.7半精镗(T104)', '');
INSERT INTO `zuchengmingxi` VALUES ('600', 'RA215.64-32M32-4512', '英制倒角立铣刀', '1', '', '个', 'Φ32.5-48.2倒角铣(T105)', '');
INSERT INTO `zuchengmingxi` VALUES ('601', 'A932.41020-100 31 100A', 'KSK 英制侧固刀柄', '1', '', '个', 'Φ32.5-48.2倒角铣(T105)', '');
INSERT INTO `zuchengmingxi` VALUES ('602', 'SPMT120408-WH4030', 'Waveline铣刀片', '3', '', '个', 'Φ32.5-48.2倒角铣(T105)', '');
INSERT INTO `zuchengmingxi` VALUES ('603', '5692022-06', '冷却液套管', '1', '', '个', 'Φ32.5-48.2倒角铣(T105)', '');
INSERT INTO `zuchengmingxi` VALUES ('604', 'C6-391.68A-7-096 060', '接柄', '1', '', '个', 'Φ101 粗镗(T106)', '');
INSERT INTO `zuchengmingxi` VALUES ('605', 'C6-390.410-1001 10A', 'HSK Capto刀柄', '1', '', '个', 'Φ101 粗镗(T106)', '');
INSERT INTO `zuchengmingxi` VALUES ('606', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'Φ101 粗镗(T106)', '');
INSERT INTO `zuchengmingxi` VALUES ('607', '5692022-06', '冷却液套管', '1', '', '个', 'Φ101 粗镗(T106)', '');
INSERT INTO `zuchengmingxi` VALUES ('608', '391.68A-7-125 40T16B', '滑块', '2', '', '个', 'Φ101 粗镗(T106)', '');
INSERT INTO `zuchengmingxi` VALUES ('609', 'C6-391.68A-7-096 060', '接柄', '1', '', '个', 'Φ106 粗镗(T107)', '');
INSERT INTO `zuchengmingxi` VALUES ('610', 'C6-390.410-1001 10A', 'HSK Capto刀柄', '1', '', '个', 'Φ106 粗镗(T107)', '');
INSERT INTO `zuchengmingxi` VALUES ('611', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'Φ106 粗镗(T107)', '');
INSERT INTO `zuchengmingxi` VALUES ('612', '5692022-06', '冷却液套管', '1', '', '个', 'Φ106 粗镗(T107)', '');
INSERT INTO `zuchengmingxi` VALUES ('613', '391.68A-7-125 40T16B', '滑块', '2', '', '个', 'Φ106 粗镗(T107)', '');
INSERT INTO `zuchengmingxi` VALUES ('614', 'C6-391.68A-6-063 045C', '接柄', '1', '', '个', 'Φ80 粗镗(T108)', '');
INSERT INTO `zuchengmingxi` VALUES ('615', 'C6-390.410-1001 10HD', 'HSK Capto刀柄', '1', '', '个', 'Φ80 粗镗(T108)', '');
INSERT INTO `zuchengmingxi` VALUES ('616', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'Φ80 粗镗(T108)', '');
INSERT INTO `zuchengmingxi` VALUES ('617', '5692022-06', '冷却液套管', '1', '', '个', 'Φ80 粗镗(T108)', '');
INSERT INTO `zuchengmingxi` VALUES ('618', '391.68A-7-125 40T16B', '滑块', '2', '', '个', 'Φ80 粗镗(T108)', '');
INSERT INTO `zuchengmingxi` VALUES ('619', 'C6-391.68A-6-063 045C', '接柄', '1', '', '个', 'φ84.7半精镗(T109)', '');
INSERT INTO `zuchengmingxi` VALUES ('620', 'C6-390.410-1001 10A', 'HSK Capto刀柄', '1', '', '个', 'φ84.7半精镗(T109)', '');
INSERT INTO `zuchengmingxi` VALUES ('621', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'φ84.7半精镗(T109)', '');
INSERT INTO `zuchengmingxi` VALUES ('622', '5692022-06', '冷却液套管', '1', '', '个', 'φ84.7半精镗(T109)', '');
INSERT INTO `zuchengmingxi` VALUES ('623', '391.68A-7-125 40T16B', '滑块', '2', '', '个', 'φ84.7半精镗(T109)', '');
INSERT INTO `zuchengmingxi` VALUES ('624', 'C8-390.410-100 120A', 'HSK Capto刀柄', '1', '', '个', 'Φ42 倒角铣(T110)', '');
INSERT INTO `zuchengmingxi` VALUES ('625', 'RA215.64-36M32-6012', '英制倒角立铣刀', '1', '', '个', 'Φ42 倒角铣(T110)', '');
INSERT INTO `zuchengmingxi` VALUES ('626', 'C8-A391.23-31 080', 'Capto英制组合接柄', '1', '', '个', 'Φ42 倒角铣(T110)', '');
INSERT INTO `zuchengmingxi` VALUES ('627', 'SPMT120408-WH4030', 'Waveline铣刀片', '3', '', '个', 'Φ42 倒角铣(T110)', '');
INSERT INTO `zuchengmingxi` VALUES ('628', '5692022-06', '冷却液套管', '1', '', '个', 'Φ42 倒角铣(T110)', '');
INSERT INTO `zuchengmingxi` VALUES ('629', '4108 26.000(看不到）', '刀杆', '1', '', '个', 'Φ26 钻(T111)', '');
INSERT INTO `zuchengmingxi` VALUES ('630', '4113 26.0', '刀片', '1', '', '个', 'Φ26 钻(T111)', '');
INSERT INTO `zuchengmingxi` VALUES ('631', 'GM3004334 32.100', '侧固刀柄', '1', '', '个', 'Φ26 钻(T111)', '');
INSERT INTO `zuchengmingxi` VALUES ('632', '4949 24.100', '冷却管', '1', '', '个', 'Φ26 钻(T111)', '');
INSERT INTO `zuchengmingxi` VALUES ('633', '4H0987239', '刀体', '1', '', '个', 'Φ29.7 粗镗(T112)', '');
INSERT INTO `zuchengmingxi` VALUES ('634', '392.41027-100 32 100A', 'HSK钻头接柄', '1', '', '个', 'Φ29.7 粗镗(T112)', '');
INSERT INTO `zuchengmingxi` VALUES ('635', 'CCMT09T308-KM3210', 'Tum107菱形80°', '2', '', '个', 'Φ29.7 粗镗(T112)', '');
INSERT INTO `zuchengmingxi` VALUES ('636', '56692022-06', '冷却液套管', '1', '', '个', 'Φ29.7 粗镗(T112)', '');
INSERT INTO `zuchengmingxi` VALUES ('637', 'S912-552083', 'Check Product Codel', '1', '', '个', 'Φ21-Φ35倒角(T113)', '');
INSERT INTO `zuchengmingxi` VALUES ('638', 'CCMT09T308-KM3210', 'Tum107菱形80°', '1', '', '个', 'Φ21-Φ35倒角(T113)', '');
INSERT INTO `zuchengmingxi` VALUES ('639', '392.41027-100 32 100A', ' HSK钻头接柄', '1', '', '个', 'Φ21-Φ35倒角(T113)', '');
INSERT INTO `zuchengmingxi` VALUES ('640', '5692022-06', '冷却液套管', '1', '', '个', 'Φ21-Φ35倒角(T113)', '');
INSERT INTO `zuchengmingxi` VALUES ('641', '5510 13.0(看不到）', '整体硬钻', '1', '', '个', 'φ13 硬钻(T131)', '');
INSERT INTO `zuchengmingxi` VALUES ('642', '4736 14.100', '热胀刀柄', '1', '', '个', 'φ13 硬钻(T131)', '');
INSERT INTO `zuchengmingxi` VALUES ('643', '4949 24.100', '冷却管', '1', '', '个', 'φ13 硬钻(T131)', '');
INSERT INTO `zuchengmingxi` VALUES ('644', 'D17.7*D22*D20*105(看不到）', '非标HM扩孔钻', '1', '', '个', 'Φ17.7锪孔钻(T115)', '');
INSERT INTO `zuchengmingxi` VALUES ('645', '4736 20.100', '热胀刀柄', '1', '', '个', 'Φ17.7锪孔钻(T115)', '');
INSERT INTO `zuchengmingxi` VALUES ('646', '4949 24.100', '冷却导管', '1', '', '个', 'Φ17.7锪孔钻(T115)', '');
INSERT INTO `zuchengmingxi` VALUES ('647', '5510 6.800(看不到）', '整体硬钻', '1', '', '个', 'φ6.8 硬钻(T116)', '');
INSERT INTO `zuchengmingxi` VALUES ('648', 'GM3004736 108.100', '热胀刀柄', '1', '', '个', 'φ6.8 硬钻(T116)', '');
INSERT INTO `zuchengmingxi` VALUES ('649', '4949 24.100', '冷却管', '1', '', '个', 'φ6.8 硬钻(T116)', '');
INSERT INTO `zuchengmingxi` VALUES ('650', '723 16.0(看不到）', '中心钻', '1', '', '个', 'φ16 中心钻(T117)', '');
INSERT INTO `zuchengmingxi` VALUES ('651', 'GM3004736 116.100', '热胀刀柄', '1', '', '个', 'φ16 中心钻(T117)', '');
INSERT INTO `zuchengmingxi` VALUES ('652', '4949 24.100', '冷却管', '1', '', '个', 'φ16 中心钻(T117)', '');
INSERT INTO `zuchengmingxi` VALUES ('653', ' 931 8.000(看不到）', '丝锥', '1', '', '个', 'M8*1.25丝锥(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('654', 'FA:14103955', '弹簧夹头刀柄', '1', '', '个', 'M8*1.25丝锥(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('655', '4306 IC16，100', '螺母', '1', '', '个', 'M8*1.25丝锥(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('656', '4308 16.016(看不到）', '弹簧夹套', '1', '', '个', 'M8*1.25丝锥(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('657', '4335 6.016(看不到）', '密封环', '1', '', '个', 'M8*1.25丝锥(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('658', '4949 24.100', '冷却管', '1', '', '个', 'M8*1.25丝锥(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('659', '2477 19.7(看不到）', '整体合金钻', '1', '', '个', 'φ19.7硬钻(T119)', '');
INSERT INTO `zuchengmingxi` VALUES ('660', '4736 120.100', '热胀刀柄', '1', '', '个', 'φ19.7硬钻(T119)', '');
INSERT INTO `zuchengmingxi` VALUES ('661', '4949 24.100', '冷却管', '1', '', '个', 'φ19.7硬钻(T119)', '');
INSERT INTO `zuchengmingxi` VALUES ('662', '6711 12.000(看不到）', '合金倒角钻', '1', '', '个', 'φ12 倒角钻(T71)', '');
INSERT INTO `zuchengmingxi` VALUES ('663', '4719 12.125', '延长杆', '1', '', '个', 'φ12 倒角钻(T71)', '');
INSERT INTO `zuchengmingxi` VALUES ('664', 'GM3004736 25.100', '热胀刀柄', '1', '', '个', 'φ12 倒角钻(T71)', '');
INSERT INTO `zuchengmingxi` VALUES ('665', '4949 24.100', '冷却导管', '1', '', '个', 'φ12 倒角钻(T71)', '');
INSERT INTO `zuchengmingxi` VALUES ('666', 'R335.15-063-03.22-5', '槽铣刀（5齿）', '1', '', '个', 'Φ63 铣槽刀(T78)', '');
INSERT INTO `zuchengmingxi` VALUES ('667', 'R335.15-13265FG-M10,F40M', '刀片', '5', '', '个', 'Φ63 铣槽刀(T78)', '');
INSERT INTO `zuchengmingxi` VALUES ('668', 'E9306Y552522160', 'HSKA100铣刀刀柄', '1', '', '个', 'Φ63 铣槽刀(T78)', '');
INSERT INTO `zuchengmingxi` VALUES ('669', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'Φ63 铣槽刀(T78)', '');
INSERT INTO `zuchengmingxi` VALUES ('670', 'C8-391.68A-7-080 060D', '接柄', '1', '', '个', 'Φ115 粗镗(T22)', '');
INSERT INTO `zuchengmingxi` VALUES ('671', 'C8-390.410-100 120A', 'HSK Capto刀柄', '1', '', '个', 'Φ115 粗镗(T22)', '');
INSERT INTO `zuchengmingxi` VALUES ('672', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'Φ115 粗镗(T22)', '');
INSERT INTO `zuchengmingxi` VALUES ('673', '5692022-06', '冷却液套管', '1', '', '个', 'Φ115 粗镗(T22)', '');
INSERT INTO `zuchengmingxi` VALUES ('674', '391.68A-7-125 40T16B', '滑块', '2', '', '个', 'Φ115 粗镗(T22)', '');
INSERT INTO `zuchengmingxi` VALUES ('675', 'C8-391.68A-7-080 060D', '接柄', '1', '', '个', 'Φ119.7半精镗(T20)', '');
INSERT INTO `zuchengmingxi` VALUES ('676', 'C8-390.410-100 120A', 'HSK Capto刀柄', '1', '', '个', 'Φ119.7半精镗(T20)', '');
INSERT INTO `zuchengmingxi` VALUES ('677', 'TCMT16T308-KM3215', '车刀片', '1', '', '个', 'Φ119.7半精镗(T20)', '');
INSERT INTO `zuchengmingxi` VALUES ('678', '5692022-06', '冷却液套管', '1', '', '个', 'Φ119.7半精镗(T20)', '');
INSERT INTO `zuchengmingxi` VALUES ('679', '391.68A-7-125 40T16B', '滑块', '2', '', '个', 'Φ119.7半精镗(T20)', '');
INSERT INTO `zuchengmingxi` VALUES ('680', 'R220.53-0080-12-6A', '面铣刀6齿，45°', '1', '', '个', 'Φ80 铣刀(T72)', '');
INSERT INTO `zuchengmingxi` VALUES ('681', 'SEMX1204AFTN-M15,MK2050', '刀片', '6', '', '个', 'Φ80 铣刀(T72)', '');
INSERT INTO `zuchengmingxi` VALUES ('682', 'E9306Y552527160', 'HSKA100铣刀刀柄', '1', '', '个', 'Φ80 铣刀(T72)', '');
INSERT INTO `zuchengmingxi` VALUES ('683', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'Φ80 铣刀(T72)', '');
INSERT INTO `zuchengmingxi` VALUES ('684', 'D18/100(看不到）', '非标硬质合金铰刀', '1', '', '个', 'Φ18R8铰刀(T79)', '');
INSERT INTO `zuchengmingxi` VALUES ('685', '4299 18，100', '液压刀柄', '1', '', '个', 'Φ18R8铰刀(T79)', '');
INSERT INTO `zuchengmingxi` VALUES ('686', '4949 24.100', '冷却导管', '1', '', '个', 'Φ18R8铰刀(T79)', '');
INSERT INTO `zuchengmingxi` VALUES ('687', 'D20*105(看不到）', '非标硬质合金铰刀', '1', '', '个', 'Φ20H9铰刀(T80)', '');
INSERT INTO `zuchengmingxi` VALUES ('688', '4299 20.100', '液压刀柄', '1', '', '个', 'Φ20H9铰刀(T80)', '');
INSERT INTO `zuchengmingxi` VALUES ('689', '4949 24.100', '冷却管', '1', '', '个', 'Φ20H9铰刀(T80)', '');
INSERT INTO `zuchengmingxi` VALUES ('690', 'C6-390.410-1001 10A', 'HSK Capto刀柄', '1', '', '个', 'Φ68精镗(T73)', '');
INSERT INTO `zuchengmingxi` VALUES ('691', 'C6-R825C-AAE 097A', '整体式精镗刀', '1', '', '个', 'Φ68精镗(T73)', '');
INSERT INTO `zuchengmingxi` VALUES ('692', 'TCMT110304-KF3005', '107车刀片', '1', '', '个', 'Φ68精镗(T73)', '');
INSERT INTO `zuchengmingxi` VALUES ('693', '5692022-06', '冷却液套管', '1', '', '个', 'Φ68精镗(T73)', '');
INSERT INTO `zuchengmingxi` VALUES ('694', 'C-AF23STVC 1103', '鹰嘴', '1', '', '个', 'Φ68精镗(T73)', '');
INSERT INTO `zuchengmingxi` VALUES ('695', 'C6-390.410-1001 10A', 'HSK Capto刀柄', '1', '', '个', 'Φ85精镗(T74)', '');
INSERT INTO `zuchengmingxi` VALUES ('696', 'C6-R825C-AAE 055A', '整体式精镗刀', '1', '', '个', 'Φ85精镗(T74)', '');
INSERT INTO `zuchengmingxi` VALUES ('697', 'TCMT110304-KF3005', '车刀片', '1', '', '个', 'Φ85精镗(T74)', '');
INSERT INTO `zuchengmingxi` VALUES ('698', '5692022-06', '冷却液套管', '1', '', '个', 'Φ85精镗(T74)', '');
INSERT INTO `zuchengmingxi` VALUES ('699', 'C-AF23STVC 1103', '鹰嘴', '1', '', '个', 'Φ85精镗(T74)', '');
INSERT INTO `zuchengmingxi` VALUES ('700', '930-HA10-HD-25-106', '高精度液压夹头', '1', '', '个', 'Φ30精镗(T75)', '');
INSERT INTO `zuchengmingxi` VALUES ('701', 'TCMT06T104-KF3005', '车刀片', '1', '', '个', 'Φ30精镗(T75)', '');
INSERT INTO `zuchengmingxi` VALUES ('702', '5692022-06', '冷却液套管', '1', '', '个', 'Φ30精镗(T75)', '');
INSERT INTO `zuchengmingxi` VALUES ('703', 'A-AF11STVC 0671', '鹰嘴', '1', '', '个', 'Φ30精镗(T75)', '');
INSERT INTO `zuchengmingxi` VALUES ('704', 'A25-R825A-AB146-RA', '精镗杆', '1', '', '个', 'Φ30精镗(T75)', '');
INSERT INTO `zuchengmingxi` VALUES ('705', 'R331103', '精镗头', '1', '', '个', 'Φ120反精镗刀(T30)', '');
INSERT INTO `zuchengmingxi` VALUES ('706', 'TCMT110304-KF3005', '车刀片', '1', '', '个', 'Φ120反精镗刀(T30)', '');
INSERT INTO `zuchengmingxi` VALUES ('707', 'C8-390.410-100 120A', 'HSK Capto刀柄', '1', '', '个', 'Φ120反精镗刀(T30)', '');
INSERT INTO `zuchengmingxi` VALUES ('708', '5692022-06', '冷却液套管', '1', '', '个', 'Φ120反精镗刀(T30)', '');
INSERT INTO `zuchengmingxi` VALUES ('709', '890 450232R57661', '接柄', '1', '', '个', 'Φ120反精镗刀(T30)', '');
INSERT INTO `zuchengmingxi` VALUES ('710', '4736.120.100(看不到）', '立铣刀', '1', '', '个', 'Φ20铣刀（立）(T53)', '');
INSERT INTO `zuchengmingxi` VALUES ('711', 'HSK100A 20.00', '热胀刀柄', '1', '', '个', 'Φ20铣刀（立）(T53)', '');
INSERT INTO `zuchengmingxi` VALUES ('712', '4949 24.100', '冷却管', '1', '', '个', 'Φ20铣刀（立）(T53)', '');
INSERT INTO `zuchengmingxi` VALUES ('713', 'R220.96-0063-08-7A-27', '方肩铣刀（7刃）', '1', '', '个', 'D63 精铣(T76)', '');
INSERT INTO `zuchengmingxi` VALUES ('714', 'XNEX080608TR-M13.MK1500', '刀片', '7', '', '个', 'D63 精铣(T76)', '');
INSERT INTO `zuchengmingxi` VALUES ('715', 'E9306Y552527160', 'HSKA100铣刀刀柄', '1', '', '个', 'D63 精铣(T76)', '');
INSERT INTO `zuchengmingxi` VALUES ('716', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'D63 精铣(T76)', '');
INSERT INTO `zuchengmingxi` VALUES ('717', 'C6-391.68A-6-063 045C', '接柄', '1', '', '个', 'φ75粗镗刀(T136)', '');
INSERT INTO `zuchengmingxi` VALUES ('718', 'C6-390.410-1001 10HD', 'HSK Capto刀柄', '1', '', '个', 'φ75粗镗刀(T136)', '');
INSERT INTO `zuchengmingxi` VALUES ('719', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'φ75粗镗刀(T136)', '');
INSERT INTO `zuchengmingxi` VALUES ('720', '5692022-06', '冷却液套管', '1', '', '个', 'φ75粗镗刀(T136)', '');
INSERT INTO `zuchengmingxi` VALUES ('721', '391.68A-6-084 30T16B', '滑块', '2', '', '个', 'φ75粗镗刀(T136)', '');
INSERT INTO `zuchengmingxi` VALUES ('722', 'C6-391.68A-6-063 045C', '接柄', '1', '', '个', 'Φ79.7半精镗(T34)', '');
INSERT INTO `zuchengmingxi` VALUES ('723', 'C6-390.410-1001 10A', 'HSK Capto刀柄', '1', '', '个', 'Φ79.7半精镗(T34)', '');
INSERT INTO `zuchengmingxi` VALUES ('724', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'Φ79.7半精镗(T34)', '');
INSERT INTO `zuchengmingxi` VALUES ('725', '5692022-06', '冷却液套管', '1', '', '个', 'Φ79.7半精镗(T34)', '');
INSERT INTO `zuchengmingxi` VALUES ('726', '391.68A-6-084 30T16B', '滑块', '2', '', '个', 'Φ79.7半精镗(T34)', '');
INSERT INTO `zuchengmingxi` VALUES ('727', '5510 8.700(看不到）', '整体硬钻', '1', '', '个', 'φ8.7硬钻(T35)', '');
INSERT INTO `zuchengmingxi` VALUES ('728', '4736 110.100', '热胀刀柄', '1', '', '个', 'φ8.7硬钻(T35)', '');
INSERT INTO `zuchengmingxi` VALUES ('729', '4949 24.100', '冷却管', '1', '', '个', 'φ8.7硬钻(T35)', '');
INSERT INTO `zuchengmingxi` VALUES ('730', '1090 10.006(看不到）', '丝锥', '1', '', '个', 'M10*1.25丝锥(T36)', '');
INSERT INTO `zuchengmingxi` VALUES ('731', 'FA:14103955', '弹簧夹头刀柄', '1', '', '个', 'M10*1.25丝锥(T36)', '');
INSERT INTO `zuchengmingxi` VALUES ('732', '4306 IC16，100', '螺母', '1', '', '个', 'M10*1.25丝锥(T36)', '');
INSERT INTO `zuchengmingxi` VALUES ('733', '4308 7.016(看不到）', '弹簧夹套', '1', '', '个', 'M10*1.25丝锥(T36)', '');
INSERT INTO `zuchengmingxi` VALUES ('734', '4335 7.016(看不到）', '密封环', '1', '', '个', 'M10*1.25丝锥(T36)', '');
INSERT INTO `zuchengmingxi` VALUES ('735', '4949 24.100', '冷却管', '1', '', '个', 'M10*1.25丝锥(T36)', '');
INSERT INTO `zuchengmingxi` VALUES ('736', 'C6-390.410-1001 10A', 'HSKCapto刀柄', '1', '', '个', 'Φ80精镗 (T37)', '');
INSERT INTO `zuchengmingxi` VALUES ('737', 'C6-R825C-AAF 055A', '接柄', '1', '', '个', 'Φ80精镗 (T37)', '');
INSERT INTO `zuchengmingxi` VALUES ('738', 'TCMT110304-KF3005', '车刀片', '1', '', '个', 'Φ80精镗 (T37)', '');
INSERT INTO `zuchengmingxi` VALUES ('739', '5692022-06', '冷却液套管', '1', '', '个', 'Φ80精镗 (T37)', '');
INSERT INTO `zuchengmingxi` VALUES ('740', 'C-AF23 STUC 1103', '鹰嘴', '1', '', '个', 'Φ80精镗 (T37)', '');
INSERT INTO `zuchengmingxi` VALUES ('741', '5510 10.4(看不到）', '引导钻', '1', '', '个', 'Φ10.4 钻头(T38)', '');
INSERT INTO `zuchengmingxi` VALUES ('742', '4736 112.100', '热胀刀柄', '1', '', '个', 'Φ10.4 钻头(T38)', '');
INSERT INTO `zuchengmingxi` VALUES ('743', '4949 24.100', '冷却管', '1', '', '个', 'Φ10.4 钻头(T38)', '');
INSERT INTO `zuchengmingxi` VALUES ('744', 'D10*106*D12*155(看不到）', '非标HM直槽钻', '1', '', '个', 'Φ10.4直槽钻(T39)', '');
INSERT INTO `zuchengmingxi` VALUES ('745', '4736 112.100', '热胀刀柄', '1', '', '个', 'Φ10.4直槽钻(T39)', '');
INSERT INTO `zuchengmingxi` VALUES ('746', '4949 24.100', '冷却管', '1', '', '个', 'Φ10.4直槽钻(T39)', '');
INSERT INTO `zuchengmingxi` VALUES ('747', 'D13*D14*168', '整体硬钻', '1', '', '个', 'φ13 硬钻(T77)', '');
INSERT INTO `zuchengmingxi` VALUES ('748', 'GM3004736 14.100', '热胀刀柄', '1', '', '个', 'φ13 硬钻(T77)', '');
INSERT INTO `zuchengmingxi` VALUES ('749', '4949 24.100', '冷却管', '1', '', '个', 'φ13 硬钻(T77)', '');
INSERT INTO `zuchengmingxi` VALUES ('750', '5510 11.0', '整体硬钻', '1', '', '个', 'φ11硬钻(T40)', '');
INSERT INTO `zuchengmingxi` VALUES ('751', 'GM3004736 12.100', '热胀刀柄', '1', '', '个', 'φ11硬钻(T40)', '');
INSERT INTO `zuchengmingxi` VALUES ('752', '4949 24.100', '冷却管', '1', '', '个', 'φ11硬钻(T40)', '');
INSERT INTO `zuchengmingxi` VALUES ('753', '5510-11.7', '标准合金扩孔钻', '1', '', '个', 'φ11.7 扩孔钻(T41)', '');
INSERT INTO `zuchengmingxi` VALUES ('754', 'GM3004736 12.100', '热胀刀柄', '1', '', '个', 'φ11.7 扩孔钻(T41)', '');
INSERT INTO `zuchengmingxi` VALUES ('755', '4949 24.100', '冷却管', '1', '', '个', 'φ11.7 扩孔钻(T41)', '');
INSERT INTO `zuchengmingxi` VALUES ('756', 'D12*90(看不到）', '非标铰刀', '1', '', '个', 'Φ12R8铰刀(T42)', '');
INSERT INTO `zuchengmingxi` VALUES ('757', 'GM3004736 12.100', '热胀刀柄', '1', '', '个', 'Φ12R8铰刀(T42)', '');
INSERT INTO `zuchengmingxi` VALUES ('758', '4949 24.100', '冷却管', '1', '', '个', 'Φ12R8铰刀(T42)', '');
INSERT INTO `zuchengmingxi` VALUES ('759', '2P340-2500-PB1630(看不到）', '粗铣刀', '1', '', '个', 'D25 铣刀(T132)', '');
INSERT INTO `zuchengmingxi` VALUES ('760', '391.41020-100 25 100A', '测固刀柄', '1', '', '个', 'D25 铣刀(T132)', '');
INSERT INTO `zuchengmingxi` VALUES ('761', '5692022-06', '冷却导管', '1', '', '个', 'D25 铣刀(T132)', '');
INSERT INTO `zuchengmingxi` VALUES ('762', '345-C8-390S/410-100 200', 'HSK Capto刀柄', '1', '', '个', 'Φ250*15宽精铣刀（T225）', '');
INSERT INTO `zuchengmingxi` VALUES ('763', 'C8-391.01-50 030', 'CAPto加长接杆', '1', '', '个', 'Φ250*15宽精铣刀（T225）', '');
INSERT INTO `zuchengmingxi` VALUES ('764', 'L331.52-250S50MM', '铣刀盘', '1', '', '个', 'Φ250*15宽精铣刀（T225）', '');
INSERT INTO `zuchengmingxi` VALUES ('765', 'N331.1A-115008E-KL1020', '铣刀片', '16', '', '个', 'Φ250*15宽精铣刀（T225）', '');
INSERT INTO `zuchengmingxi` VALUES ('766', '5692022-06', '冷却液套管', '1', '', '个', 'Φ250*15宽精铣刀（T225）', '');
INSERT INTO `zuchengmingxi` VALUES ('767', '5510 15.700(看不到)', '整体硬钻', '1', '', '个', 'φ15.7硬钻(T45)', '');
INSERT INTO `zuchengmingxi` VALUES ('768', 'GM3004736 16.100', '热胀刀柄', '1', '', '个', 'φ15.7硬钻(T45)', '');
INSERT INTO `zuchengmingxi` VALUES ('769', '4949 24.100', '冷却管', '1', '', '个', 'φ15.7硬钻(T45)', '');
INSERT INTO `zuchengmingxi` VALUES ('770', '5510 12.500(看不到)', '整体硬钻', '1', '', '个', 'φ12.5硬钻(T46)', '');
INSERT INTO `zuchengmingxi` VALUES ('771', 'GM3004736 114.100', '热胀刀柄', '1', '', '个', 'φ12.5硬钻(T46)', '');
INSERT INTO `zuchengmingxi` VALUES ('772', '4949 24.100', '冷却管', '1', '', '个', 'φ12.5硬钻(T46)', '');
INSERT INTO `zuchengmingxi` VALUES ('773', '5511 10.7(看不到)', '整体硬钻', '1', '', '个', 'φ10.7硬钻(T47)', '');
INSERT INTO `zuchengmingxi` VALUES ('774', 'GM3004736 12.100', '热胀刀柄', '1', '', '个', 'φ10.7硬钻(T47)', '');
INSERT INTO `zuchengmingxi` VALUES ('775', '4949 24.100', '冷却管', '1', '', '个', 'φ10.7硬钻(T47)', '');
INSERT INTO `zuchengmingxi` VALUES ('776', 'D10.7*D12*184', '非标整体硬花钻', '1', '', '个', 'Φ10.7硬钻(T49)', '');
INSERT INTO `zuchengmingxi` VALUES ('777', 'GM3004736 12.100', '热胀刀柄', '1', '', '个', 'Φ10.7硬钻(T49)', '');
INSERT INTO `zuchengmingxi` VALUES ('778', '4949 24.100', '冷却管', '1', '', '个', 'Φ10.7硬钻(T49)', '');
INSERT INTO `zuchengmingxi` VALUES ('779', '347 14.007(看不到)', '丝锥', '1', '', '个', 'M14*1.5丝锥(T50)', '');
INSERT INTO `zuchengmingxi` VALUES ('780', 'GM3004324 32.101', '弹簧夹头刀柄', '1', '', '个', 'M14*1.5丝锥(T50)', '');
INSERT INTO `zuchengmingxi` VALUES ('781', '4308 11.032(看不到)', '弹簧夹套', '1', '', '个', 'M14*1.5丝锥(T50)', '');
INSERT INTO `zuchengmingxi` VALUES ('782', '4335 11.032(看不到)', '密封环', '1', '', '个', 'M14*1.5丝锥(T50)', '');
INSERT INTO `zuchengmingxi` VALUES ('783', '4949 24.100', '冷却管', '1', '', '个', 'M14*1.5丝锥(T50)', '');
INSERT INTO `zuchengmingxi` VALUES ('784', '4306-32.600', '螺母', '1', '', '个', 'M14*1.5丝锥(T50)', '');
INSERT INTO `zuchengmingxi` VALUES ('785', '932 12.006(看不到)', '丝锥', '1', '', '个', 'M12*1.25丝锥(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('786', 'GM3004324 32.100', '弹簧夹头刀柄', '1', '', '个', 'M12*1.25丝锥(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('787', '4308 9.032(看不到)', '弹簧夹头', '1', '', '个', 'M12*1.25丝锥(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('788', '4335 9.032(看不到)', '密封环', '1', '', '个', 'M12*1.25丝锥(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('789', '4949 24.100', '冷却管', '1', '', '个', 'M12*1.25丝锥(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('790', '4306-32.600', '螺母', '1', '', '个', 'M12*1.25丝锥(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('791', '4107 20，500(看不到)', 'HT800刀体', '1', '', '个', 'φ20.5钻头(T52)', '');
INSERT INTO `zuchengmingxi` VALUES ('792', '4113 20.500(看不到)', '刀片', '1', '', '个', 'φ20.5钻头(T52)', '');
INSERT INTO `zuchengmingxi` VALUES ('793', 'GM3004334 25.100', '侧固刀柄', '1', '', '个', 'φ20.5钻头(T52)', '');
INSERT INTO `zuchengmingxi` VALUES ('794', '4949 24.100', '冷却管', '1', '', '个', 'φ20.5钻头(T52)', '');
INSERT INTO `zuchengmingxi` VALUES ('795', '3736 20.000(看不到)', '立铣刀', '1', '', '个', 'φ20铣刀(T137)', '');
INSERT INTO `zuchengmingxi` VALUES ('796', 'GM3004736 120.100', '热胀刀柄', '1', '', '个', 'φ20铣刀(T137)', '');
INSERT INTO `zuchengmingxi` VALUES ('797', '4949 24.100', '冷却管', '1', '', '个', 'φ20铣刀(T137)', '');
INSERT INTO `zuchengmingxi` VALUES ('798', '347 22.007(看不到)', '丝锥', '1', '', '个', 'M22*1.5丝锥(T134)', '');
INSERT INTO `zuchengmingxi` VALUES ('799', 'GM3004324 32.100', '弹簧夹头刀柄', '1', '', '个', 'M22*1.5丝锥(T134)', '');
INSERT INTO `zuchengmingxi` VALUES ('800', '4308 18.032(看不到)', '弹簧夹套', '1', '', '个', 'M22*1.5丝锥(T134)', '');
INSERT INTO `zuchengmingxi` VALUES ('801', '4335 18.032(看不到)', '密封环', '1', '', '个', 'M22*1.5丝锥(T134)', '');
INSERT INTO `zuchengmingxi` VALUES ('802', '4949 24.100', '冷却管', '1', '', '个', 'M22*1.5丝锥(T134)', '');
INSERT INTO `zuchengmingxi` VALUES ('803', '4306-32.600', '螺母', '1', '', '个', 'M22*1.5丝锥(T134)', '');
INSERT INTO `zuchengmingxi` VALUES ('804', '930-HA10-S-20-100', '高精度液压夹头', '1', '', '个', 'Φ15*3.5±0.1宽铣槽刀(T135)', '');
INSERT INTO `zuchengmingxi` VALUES ('805', '393.CG-20 16 52', '高精度夹心', '1', '', '个', 'Φ15*3.5±0.1宽铣槽刀(T135)', '');
INSERT INTO `zuchengmingxi` VALUES ('806', 'BU1310036(看不到)', '非标槽铣刀', '1', '', '个', 'Φ15*3.5±0.1宽铣槽刀(T135)', '');
INSERT INTO `zuchengmingxi` VALUES ('807', '5692022-06', '冷却液套管', '1', '', '个', 'Φ15*3.5±0.1宽铣槽刀(T135)', '');
INSERT INTO `zuchengmingxi` VALUES ('808', 'D16*100', '非标铰刀', '1', '', '个', 'Φ16F9铰刀(T56)', '');
INSERT INTO `zuchengmingxi` VALUES ('809', 'GM3004736 16.100', '热胀刀柄', '1', '', '个', 'Φ16F9铰刀(T56)', '');
INSERT INTO `zuchengmingxi` VALUES ('810', '4949 24.100', '冷却管', '1', '', '个', 'Φ16F9铰刀(T56)', '');
INSERT INTO `zuchengmingxi` VALUES ('811', 'S912-552076(看不到)', '镗刀杆', '1', '', '个', 'Φ27.7半精镗(T57)', '');
INSERT INTO `zuchengmingxi` VALUES ('812', 'CCMT09T308-KM3210', 'Tum107菱形80°', '2', '', '个', 'Φ27.7半精镗(T57)', '');
INSERT INTO `zuchengmingxi` VALUES ('813', '392.41027-100 32 100A', 'HSK钻头接柄', '1', '', '个', 'Φ27.7半精镗(T57)', '');
INSERT INTO `zuchengmingxi` VALUES ('814', '5692022-06', '冷却液套管', '1', '', '个', 'Φ27.7半精镗(T57)', '');
INSERT INTO `zuchengmingxi` VALUES ('815', 'D28*D25*130', '非标焊硬质合金铰', '1', '', '个', 'Φ28 铰刀(T58)', '');
INSERT INTO `zuchengmingxi` VALUES ('816', 'GM3004736 25.100', '热胀刀柄', '1', '', '个', 'Φ28 铰刀(T58)', '');
INSERT INTO `zuchengmingxi` VALUES ('817', '4949 24.100', '冷却管', '1', '', '个', 'Φ28 铰刀(T58)', '');
INSERT INTO `zuchengmingxi` VALUES ('818', 'D6.05*D8*65', '非标整体硬钻', '1', '', '个', 'Φ6.05 硬钻(T59)', '');
INSERT INTO `zuchengmingxi` VALUES ('819', 'GM3004736 308.100', '热胀刀柄', '1', '', '个', 'Φ6.05 硬钻(T59)', '');
INSERT INTO `zuchengmingxi` VALUES ('820', '4949 24.100', '冷却管', '1', '', '个', 'Φ6.05 硬钻(T59)', '');
INSERT INTO `zuchengmingxi` VALUES ('821', 'D6.05*D8*108', '非标整体硬钻', '1', '', '个', 'Φ6.05 硬钻(T60)', '');
INSERT INTO `zuchengmingxi` VALUES ('822', 'GM3004736 308.100', '热胀刀柄', '1', '', '个', 'Φ6.05 硬钻(T60)', '');
INSERT INTO `zuchengmingxi` VALUES ('823', '4949 24.100', '冷却管', '1', '', '个', 'Φ6.05 硬钻(T60)', '');
INSERT INTO `zuchengmingxi` VALUES ('824', 'C6-390.410-1001 10HD', 'HSK Capto刀柄', '1', '', '个', 'Φ67 粗镗 (T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('825', 'C6-391.02-50 080A', 'Captp缩径接杆', '1', '', '个', 'Φ67 粗镗 (T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('826', 'C5-391.68A-5-050 044B', '接柄', '1', '', '个', 'Φ67 粗镗 (T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('827', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'Φ67 粗镗 (T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('828', '5692022-06', '冷却液套管', '1', '', '个', 'Φ67 粗镗 (T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('829', '391.68A-5-070 26T16B', '滑块', '2', '', '个', 'Φ67 粗镗 (T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('830', 'C6-390.410-100 110HD', '刀柄', '1', '', '个', 'Φ71.7半精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('831', 'C6-391.01-63 100A', 'Captp加长接杆', '1', '', '个', 'Φ71.7半精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('832', 'C6-391.68A-6-063 045C', '接柄', '1', '', '个', 'Φ71.7半精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('833', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'Φ71.7半精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('834', '5692022-06', '冷却液套管', '1', '', '个', 'Φ71.7半精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('835', '391.68A-6-084 30T16B', '滑块', '2', '', '个', 'Φ71.7半精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('836', 'R220.66-0063-12-4', '面铣刀(4齿，60°﹚', '1', '', '个', 'D63/C30倒角刀(T81)', '');
INSERT INTO `zuchengmingxi` VALUES ('837', 'HPMN1206ZETR-MD20,MK2050', '刀片', '4', '', '个', 'D63/C30倒角刀(T81)', '');
INSERT INTO `zuchengmingxi` VALUES ('838', 'E9306Y552522100', 'HSKA100铣刀刀柄', '1', '', '个', 'D63/C30倒角刀(T81)', '');
INSERT INTO `zuchengmingxi` VALUES ('839', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'D63/C30倒角刀(T81)', '');
INSERT INTO `zuchengmingxi` VALUES ('840', '930-HA10-HD-32-110', '高精度液压夹头', '1', '', '个', 'Φ32 铣刀(T64)', '');
INSERT INTO `zuchengmingxi` VALUES ('841', 'R390D-032A32-11M(看不到）', '防震铣刀（4齿）', '1', '', '个', 'Φ32 铣刀(T64)', '');
INSERT INTO `zuchengmingxi` VALUES ('842', 'R390-11T308M-KL1020', '铣刀片', '3', '', '个', 'Φ32 铣刀(T64)', '');
INSERT INTO `zuchengmingxi` VALUES ('843', '5692022-06', '冷却液套管', '1', '', '个', 'Φ32 铣刀(T64)', '');
INSERT INTO `zuchengmingxi` VALUES ('844', '890 200232R56020', '铣刀', '1', 'R58特殊刀', '个', '扇面铣刀（T65）', '');
INSERT INTO `zuchengmingxi` VALUES ('845', '490R-140408M-PL 1030', '铣刀片', '3', '', '个', '扇面铣刀（T65）', '');
INSERT INTO `zuchengmingxi` VALUES ('846', '5692022-06', '冷却液套管', '1', '', '个', '扇面铣刀（T65）', '');
INSERT INTO `zuchengmingxi` VALUES ('847', 'C6-R825C-AAF 055A', '接柄', '1', '', '个', 'Φ72 精镗 (T66)', '');
INSERT INTO `zuchengmingxi` VALUES ('848', 'C6-391.01-63 100A', 'CAPto加长接杆', '1', '', '个', 'Φ72 精镗 (T66)', '');
INSERT INTO `zuchengmingxi` VALUES ('849', 'C6-390.410-100110HD', 'HSK Capto刀柄', '1', '', '个', 'Φ72 精镗 (T66)', '');
INSERT INTO `zuchengmingxi` VALUES ('850', 'TCMT110304-KF3005', '车刀片', '1', '', '个', 'Φ72 精镗 (T66)', '');
INSERT INTO `zuchengmingxi` VALUES ('851', '5692022-06', '冷却液套管', '1', '', '个', 'Φ72 精镗 (T66)', '');
INSERT INTO `zuchengmingxi` VALUES ('852', 'C-AF23 STUC 1103', '鹰嘴', '1', '', '个', 'Φ72 精镗 (T66)', '');
INSERT INTO `zuchengmingxi` VALUES ('853', 'D26.5/D25/275', '非标焊合金扩孔钻', '1', '', '个', 'Φ26.5扩孔钻(T67)', '');
INSERT INTO `zuchengmingxi` VALUES ('854', 'GM3004736 25.100', '侧固刀柄', '1', '', '个', 'Φ26.5扩孔钻(T67)', '');
INSERT INTO `zuchengmingxi` VALUES ('855', '4949 24.100', '冷却管', '1', '', '个', 'Φ26.5扩孔钻(T67)', '');
INSERT INTO `zuchengmingxi` VALUES ('856', 'D26.82*D25*220', '非标硬质合金铰刀', '1', '', '个', 'Φ26.82铰刀(T68)', '');
INSERT INTO `zuchengmingxi` VALUES ('857', 'FA:14701197', '延长杆', '1', '', '个', 'Φ26.82铰刀(T68)', '');
INSERT INTO `zuchengmingxi` VALUES ('858', 'GM3004299 25.100', '液压刀柄', '1', '', '个', 'Φ26.82铰刀(T68)', '');
INSERT INTO `zuchengmingxi` VALUES ('859', '4949 24.100', '冷却管', '1', '', '个', 'Φ26.82铰刀(T68)', '');
INSERT INTO `zuchengmingxi` VALUES ('860', '3627-25.0（看不到）', '立铣刀', '1', '', '个', 'Φ25立铣刀(T86)', '');
INSERT INTO `zuchengmingxi` VALUES ('861', 'GM3004736-25.100', '热涨刀柄', '1', '', '个', 'Φ25立铣刀(T86)', '');
INSERT INTO `zuchengmingxi` VALUES ('862', '4949 24.100', '冷却管', '1', '', '个', 'Φ25立铣刀(T86)', '');
INSERT INTO `zuchengmingxi` VALUES ('863', 'D8×D11×D12×90（看不到）', '非标立铣刀', '1', '', '个', 'Φ11立铣刀(T87)', '');
INSERT INTO `zuchengmingxi` VALUES ('864', '4736-12.100', '热涨刀柄', '1', '', '个', 'Φ11立铣刀(T87)', '');
INSERT INTO `zuchengmingxi` VALUES ('865', '4949-24.100', '冷却管', '1', '', '个', 'Φ11立铣刀(T87)', '');
INSERT INTO `zuchengmingxi` VALUES ('866', 'C6-390.410-100 110HD', '主刀柄（变径）', '1', '', '个', 'Φ40铣刀(T130)', '');
INSERT INTO `zuchengmingxi` VALUES ('867', 'R390-040C6-11M080', '铣刀盘', '1', '', '个', 'Φ40铣刀(T130)', '');
INSERT INTO `zuchengmingxi` VALUES ('868', 'R390-11T308M-KL 1020', '铣刀片', '4', '', '个', 'Φ40铣刀(T130)', '');
INSERT INTO `zuchengmingxi` VALUES ('869', '20E9306', '冷却管', '1', '', '个', 'Φ40铣刀(T130)', '');
INSERT INTO `zuchengmingxi` VALUES ('870', '5510 13.0(看不到）', '整体硬质合金钻', '1', '', '个', 'Φ13硬钻(T114)', '');
INSERT INTO `zuchengmingxi` VALUES ('871', 'GM3004736 114.100', '热涨刀柄', '1', '', '个', 'Φ13硬钻(T114)', '');
INSERT INTO `zuchengmingxi` VALUES ('872', '4949 24.100', '冷却管', '1', '', '个', 'Φ13硬钻(T114)', '');
INSERT INTO `zuchengmingxi` VALUES ('873', 'R220.53-0125-12-8A', '快豹面铣刀(8齿）', '1', '', '个', 'D125铣刀(T20)', '');
INSERT INTO `zuchengmingxi` VALUES ('874', 'SEMX1204AFTN-M15,MK2050', '刀片', '8', '', '个', 'D125铣刀(T20)', '');
INSERT INTO `zuchengmingxi` VALUES ('875', 'E9306Y552540100', 'HSKA100铣刀刀柄', '1', '', '个', 'D125铣刀(T20)', '');
INSERT INTO `zuchengmingxi` VALUES ('876', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'D125铣刀(T20)', '');
INSERT INTO `zuchengmingxi` VALUES ('877', 'D22*90*D20155(看不到）', '立铣刀', '1', '', '个', 'Φ22钻头(T49)', '');
INSERT INTO `zuchengmingxi` VALUES ('878', '4736 20.100', '热胀刀柄', '1', '', '个', 'Φ22钻头(T49)', '');
INSERT INTO `zuchengmingxi` VALUES ('879', '4949 24.100', '冷却刀柄', '1', '', '个', 'Φ22钻头(T49)', '');
INSERT INTO `zuchengmingxi` VALUES ('880', '4107 28，0(看不到）', '扩孔钻', '1', '', '个', '扩孔钻(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('881', '4113 28，0', '刀片', '1', '', '个', '扩孔钻(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('882', '4334 32.100', '侧固刀柄', '1', '', '个', '扩孔钻(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('883', '4949 24.100', '冷却导管', '1', '', '个', '扩孔钻(T51)', '');
INSERT INTO `zuchengmingxi` VALUES ('884', 'S912-552083(看不到）', '倒角刀', '1', '', '个', 'Φ21-Φ35倒角钻(T52)', '');
INSERT INTO `zuchengmingxi` VALUES ('885', 'TCMT220408-PM235', '刀片', '2', '', '个', 'Φ21-Φ35倒角钻(T52)', '');
INSERT INTO `zuchengmingxi` VALUES ('886', '392.41027-100 32 100A', 'HSK 钻头接柄', '1', '', '个', 'Φ21-Φ35倒角钻(T52)', '');
INSERT INTO `zuchengmingxi` VALUES ('887', '5692022-06', '冷却液套管', '1', '', '个', 'Φ21-Φ35倒角钻(T52)', '');
INSERT INTO `zuchengmingxi` VALUES ('888', '3523 16，200(看不到）', 'HM螺纹铣刀', '1', '', '个', 'D16*2螺纹铣刀(T53)', '');
INSERT INTO `zuchengmingxi` VALUES ('889', '4736 16，100', '热胀刀柄', '1', '', '个', 'D16*2螺纹铣刀(T53)', '');
INSERT INTO `zuchengmingxi` VALUES ('890', '4949 24，100', '冷却导管', '1', '', '个', 'D16*2螺纹铣刀(T53)', '');
INSERT INTO `zuchengmingxi` VALUES ('891', '5510 14.5(看不到）', '整体硬钻', '1', '', '个', 'φ14.5钻头(T202)', '');
INSERT INTO `zuchengmingxi` VALUES ('892', '4736 16.100', '热胀刀柄', '1', '', '个', 'φ14.5钻头(T202)', '');
INSERT INTO `zuchengmingxi` VALUES ('893', '4949 24.100', '冷却管', '1', '', '个', 'φ14.5钻头(T202)', '');
INSERT INTO `zuchengmingxi` VALUES ('894', '723 20.100(看不到）', 'NC点钻', '1', '', '个', 'φ20倒角钻(T200)', '');
INSERT INTO `zuchengmingxi` VALUES ('895', '4736 20.100', '热胀刀柄', '1', '', '个', 'φ20倒角钻(T200)', '');
INSERT INTO `zuchengmingxi` VALUES ('896', '4949 24.100', '冷却管', '1', '', '个', 'φ20倒角钻(T200)', '');
INSERT INTO `zuchengmingxi` VALUES ('897', '3523 16,007(看不到）', 'HM螺纹铣刀', '1', '', '个', 'M16*1.5螺纹铣刀(T56)', '');
INSERT INTO `zuchengmingxi` VALUES ('898', '4324 32.100', '弹簧夹头刀柄', '1', '', '个', 'M16*1.5螺纹铣刀(T56)', '');
INSERT INTO `zuchengmingxi` VALUES ('899', '4308 12.032(看不到）', '弹簧夹套', '1', '', '个', 'M16*1.5螺纹铣刀(T56)', '');
INSERT INTO `zuchengmingxi` VALUES ('900', '4325 12.032(看不到）', '密封环', '1', '', '个', 'M16*1.5螺纹铣刀(T56)', '');
INSERT INTO `zuchengmingxi` VALUES ('901', '4949 24.100', '冷却管', '1', '', '个', 'M16*1.5螺纹铣刀(T56)', '');
INSERT INTO `zuchengmingxi` VALUES ('902', '4306 32.600', '螺母', '1', '', '个', 'M16*1.5螺纹铣刀(T56)', '');
INSERT INTO `zuchengmingxi` VALUES ('903', '5510 10.500(看不到）', 'HM麻花钻', '1', '', '个', 'φ10.5钻头(T57)', '');
INSERT INTO `zuchengmingxi` VALUES ('904', '4736 12.100', '热胀刀柄', '1', '', '个', 'φ10.5钻头(T57)', '');
INSERT INTO `zuchengmingxi` VALUES ('905', '4949 24.100', '冷却导管', '1', '', '个', 'φ10.5钻头(T57)', '');
INSERT INTO `zuchengmingxi` VALUES ('906', '974 12，07(看不到）', 'HM丝锥', '1', '', '个', 'M12*1.5丝锥(T58)', '');
INSERT INTO `zuchengmingxi` VALUES ('907', '4324 32，100', 'ER刀柄', '1', '', '个', 'M12*1.5丝锥(T58)', '');
INSERT INTO `zuchengmingxi` VALUES ('908', '4308 9，032(看不到）', 'ER夹头', '1', '', '个', 'M12*1.5丝锥(T58)', '');
INSERT INTO `zuchengmingxi` VALUES ('909', '4949 24.100', '冷却导管', '1', '', '个', 'M12*1.5丝锥(T58)', '');
INSERT INTO `zuchengmingxi` VALUES ('910', '4335 9.032(看不到）', 'F封水环', '1', '', '个', 'M12*1.5丝锥(T58)', '');
INSERT INTO `zuchengmingxi` VALUES ('911', '4306 32.600', '螺母', '1', '', '个', 'M12*1.5丝锥(T58)', '');
INSERT INTO `zuchengmingxi` VALUES ('912', '6068 18,500(看不到）', 'HM直槽钻', '1', '', '个', 'Φ18.5直槽钻(T59)', '');
INSERT INTO `zuchengmingxi` VALUES ('913', '4736 20.100', '热胀刀柄', '1', '', '个', 'Φ18.5直槽钻(T59)', '');
INSERT INTO `zuchengmingxi` VALUES ('914', '4949 24.100', '冷却导管', '1', '', '个', 'Φ18.5直槽钻(T59)', '');
INSERT INTO `zuchengmingxi` VALUES ('915', 'D29.7*20*D32*120', '非标焊片扩孔刀', '1', '', '个', 'Φ29.5扩孔钻(T60)', '');
INSERT INTO `zuchengmingxi` VALUES ('916', '4299 32.100', '液压刀柄', '1', '', '个', 'Φ29.5扩孔钻(T60)', '');
INSERT INTO `zuchengmingxi` VALUES ('917', '4949 24.100', '冷却导管', '1', '', '个', 'Φ29.5扩孔钻(T60)', '');
INSERT INTO `zuchengmingxi` VALUES ('918', '974 20，007 (看不到）', 'HM丝锥', '1', '', '个', 'M20*1.5丝锥(T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('919', '4324 32，100', 'ER刀柄', '1', '', '个', 'M20*1.5丝锥(T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('920', '4308 20，032(看不到）', 'ER夹头', '1', '', '个', 'M20*1.5丝锥(T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('921', '4335 20.032(看不到）', 'F封水环', '1', '', '个', 'M20*1.5丝锥(T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('922', '4949 24.100', '冷却导管', '1', '', '个', 'M20*1.5丝锥(T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('923', '4306 32.600', '螺母', '1', '', '个', 'M20*1.5丝锥(T61)', '');
INSERT INTO `zuchengmingxi` VALUES ('924', 'R220.96-0080-08-7A', '快豹面铣刀(7齿）', '1', '', '个', 'D80粗铣(T63)', '');
INSERT INTO `zuchengmingxi` VALUES ('925', 'XNEX080608TR-MD15,MK2050', '刀片', '7', '', '个', 'D80粗铣(T63)', '');
INSERT INTO `zuchengmingxi` VALUES ('926', 'E9306552527100', 'HSKA100铣刀刀柄', '1', '', '个', 'D80粗铣(T63)', '');
INSERT INTO `zuchengmingxi` VALUES ('927', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'D80粗铣(T63)', '');
INSERT INTO `zuchengmingxi` VALUES ('928', 'C8-390.410-100 120A', 'HSK Capto刀柄', '1', '', '个', 'Φ189.5粗镗(T229)', '');
INSERT INTO `zuchengmingxi` VALUES ('929', 'C8-R822XLS17-AJ 070', '刀杆', '1', '', '个', 'Φ189.5粗镗(T229)', '');
INSERT INTO `zuchengmingxi` VALUES ('930', 'TCMT220408-KR3215', '车刀片', '2', '', '个', 'Φ189.5粗镗(T229)', '');
INSERT INTO `zuchengmingxi` VALUES ('931', '5692022-06', '冷却液套管', '1', '', '个', 'Φ189.5粗镗(T229)', '');
INSERT INTO `zuchengmingxi` VALUES ('932', 'S17-R820XLS12-012', '滑块', '2', '', '个', 'Φ189.5粗镗(T229)', '');
INSERT INTO `zuchengmingxi` VALUES ('933', 'S12-R820XLR40STFC22', '刀夹', '2', '', '个', 'Φ189.5粗镗(T229)', '');
INSERT INTO `zuchengmingxi` VALUES ('934', 'HSK Capto刀柄', 'HSK Capto刀柄', '1', '', '个', 'Φ199.5粗(T232)', '');
INSERT INTO `zuchengmingxi` VALUES ('935', 'C8-R822XLS17-AJ 070', '整体式粗镗刀', '1', '', '个', 'Φ199.5粗(T232)', '');
INSERT INTO `zuchengmingxi` VALUES ('936', 'TCMT220408-KR3215', '车刀片', '2', '', '个', 'Φ199.5粗(T232)', '');
INSERT INTO `zuchengmingxi` VALUES ('937', '5692022-06', '冷却液套管', '1', '', '个', 'Φ199.5粗(T232)', '');
INSERT INTO `zuchengmingxi` VALUES ('938', 'S17-R820XLS12-012', '滑块', '2', '', '个', 'Φ199.5粗(T232)', '');
INSERT INTO `zuchengmingxi` VALUES ('939', 'S12-R820XLR40STFC22', '刀夹', '2', '', '个', 'Φ199.5粗(T232)', '');
INSERT INTO `zuchengmingxi` VALUES ('940', '6068 6，800(看不到）', 'HM直槽钻', '1', '', '个', 'φ6.8直槽钻(T79)', '');
INSERT INTO `zuchengmingxi` VALUES ('941', '4736 108.100', '热胀刀柄', '1', '', '个', 'φ6.8直槽钻(T79)', '');
INSERT INTO `zuchengmingxi` VALUES ('942', '4949 24.100', '冷却导管', '1', '', '个', 'φ6.8直槽钻(T79)', '');
INSERT INTO `zuchengmingxi` VALUES ('943', '931 8.000（看不到）', '丝锥', '1', '', '个', 'M8*1.25丝锥(T80)', '');
INSERT INTO `zuchengmingxi` VALUES ('944', 'FA:14103955', 'ER刀柄', '1', '', '个', 'M8*1.25丝锥(T80)', '');
INSERT INTO `zuchengmingxi` VALUES ('945', '4306-16.600', '螺母', '1', '', '个', 'M8*1.25丝锥(T80)', '');
INSERT INTO `zuchengmingxi` VALUES ('946', '4335 6.016（看不到）', '夹芯', '1', '', '个', 'M8*1.25丝锥(T80)', '');
INSERT INTO `zuchengmingxi` VALUES ('947', '4949 24.100', '冷却导管', '1', '', '个', 'M8*1.25丝锥(T80)', '');
INSERT INTO `zuchengmingxi` VALUES ('948', 'R220.96-0080-08-9A', '方肩铣刀', '1', '', '个', 'D80精铣(T201)', '');
INSERT INTO `zuchengmingxi` VALUES ('949', 'XNEX080608TR-M13,MP1500', '刀片（9刃）', '9', '', '个', 'D80精铣(T201)', '');
INSERT INTO `zuchengmingxi` VALUES ('950', 'E9306552527160', 'HSKA100铣刀刀柄', '1', '', '个', 'D80精铣(T201)', '');
INSERT INTO `zuchengmingxi` VALUES ('951', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'D80精铣(T201)', '');
INSERT INTO `zuchengmingxi` VALUES ('952', '392.410XL-10040080', '刀柄', '1', '', '个', 'Φ391粗镗(T8)', '');
INSERT INTO `zuchengmingxi` VALUES ('953', 'A40-RALS24-AN2 067', '接柄', '1', '', '个', 'Φ391粗镗(T8)', '');
INSERT INTO `zuchengmingxi` VALUES ('954', 'TCMT220408-KR3215', '车刀片', '2', '', '个', 'Φ391粗镗(T8)', '');
INSERT INTO `zuchengmingxi` VALUES ('955', '5692022-06', '冷却液套管', '1', '', '个', 'Φ391粗镗(T8)', '');
INSERT INTO `zuchengmingxi` VALUES ('956', 'S12-R820XLR40STFC22', '刀夹', '2', '', '个', 'Φ391粗镗(T8)', '');
INSERT INTO `zuchengmingxi` VALUES ('957', '392.410XL-10040080', '刀柄', '1', '', '个', 'φ395.5粗镗(T2)', '');
INSERT INTO `zuchengmingxi` VALUES ('958', 'A40-RALS24-AN2 067', '接柄', '1', '', '个', 'φ395.5粗镗(T2)', '');
INSERT INTO `zuchengmingxi` VALUES ('959', 'TCMT220408-KR3215', '车刀片', '2', '', '个', 'φ395.5粗镗(T2)', '');
INSERT INTO `zuchengmingxi` VALUES ('960', '5692022-06', '冷却液套管', '1', '', '个', 'φ395.5粗镗(T2)', '');
INSERT INTO `zuchengmingxi` VALUES ('961', 'S12-R820XLR40STFC22', '刀夹', '2', '', '个', 'φ395.5粗镗(T2)', '');
INSERT INTO `zuchengmingxi` VALUES ('962', '6068 17，500（看不到）', 'HM直槽钻', '1', '', '个', 'φ17.5直槽钻(T81)', '');
INSERT INTO `zuchengmingxi` VALUES ('963', '4736 18.100', '热胀刀柄', '1', '', '个', 'φ17.5直槽钻(T81)', '');
INSERT INTO `zuchengmingxi` VALUES ('964', '4949 24.100', '冷却导管', '1', '', '个', 'φ17.5直槽钻(T81)', '');
INSERT INTO `zuchengmingxi` VALUES ('965', 'D17.5*183D18*235（看不到）', '硬质合金麻花钻', '1', '', '个', 'Φ17.5硬钻(T82)', '');
INSERT INTO `zuchengmingxi` VALUES ('966', '4736 18.100', '热胀刀柄', '1', '', '个', 'Φ17.5硬钻(T82)', '');
INSERT INTO `zuchengmingxi` VALUES ('967', '4949 24.100', '冷却导管', '1', '', '个', 'Φ17.5硬钻(T82)', '');
INSERT INTO `zuchengmingxi` VALUES ('968', 'HSK100A-CT25S-90', 'ER刀柄', '1', '', '个', 'Φ17.5/Φ40反划(T83)', '');
INSERT INTO `zuchengmingxi` VALUES ('969', 'BSF 17.5/40-155SP', '反划刀杆', '1', '', '个', 'Φ17.5/Φ40反划(T83)', '');
INSERT INTO `zuchengmingxi` VALUES ('970', 'BSF-M-G1200/1000-1A', '刀片', '1', '', '个', 'Φ17.5/Φ40反划(T83)', '');
INSERT INTO `zuchengmingxi` VALUES ('971', '5692022-06', '冷却液套管', '1', '', '个', 'Φ17.5/Φ40反划(T83)', '');
INSERT INTO `zuchengmingxi` VALUES ('972', '392.410XL-10040080', 'Coropak12.2', '1', '', '个', 'Φ396精镗(T13)', '');
INSERT INTO `zuchengmingxi` VALUES ('973', 'A40-RXLS24-AN2 067', '整体式精镗刀', '1', '', '个', 'Φ396精镗(T13)', '');
INSERT INTO `zuchengmingxi` VALUES ('974', 'TCMT110304-KF3005', '车刀片', '1', '', '个', 'Φ396精镗(T13)', '');
INSERT INTO `zuchengmingxi` VALUES ('975', '5692022-06', '冷却液套管', '1', '', '个', 'Φ396精镗(T13)', '');
INSERT INTO `zuchengmingxi` VALUES ('976', 'S20-525XL-CW', '滑块', '1', '', '个', 'Φ396精镗(T13)', '');
INSERT INTO `zuchengmingxi` VALUES ('977', 'S24-R825XLA34-012', '滑块', '1', '', '个', 'Φ396精镗(T13)', '');
INSERT INTO `zuchengmingxi` VALUES ('978', 'A34-R825C-E017A', '刀尖', '1', '', '个', 'Φ396精镗(T13)', '');
INSERT INTO `zuchengmingxi` VALUES ('979', 'C-AF23STUC1103', '鹰嘴', '1', '', '个', 'Φ396精镗(T13)', '');
INSERT INTO `zuchengmingxi` VALUES ('980', 'C8-390.410-100120A', 'HSK Capto刀柄', '1', '', '个', 'Φ190精镗(T235)', '');
INSERT INTO `zuchengmingxi` VALUES ('981', 'C8-R822XLS17-AJ 070', '刀杆', '1', '', '个', 'Φ190精镗(T235)', '');
INSERT INTO `zuchengmingxi` VALUES ('982', 'TCMT110304-KF3005', '车刀片', '1', '', '个', 'Φ190精镗(T235)', '');
INSERT INTO `zuchengmingxi` VALUES ('983', '5692022-06', '冷却液套管', '1', '', '个', 'Φ190精镗(T235)', '');
INSERT INTO `zuchengmingxi` VALUES ('984', 'A34-R825C-E017A', '夹头', '1', '', '个', 'Φ190精镗(T235)', '');
INSERT INTO `zuchengmingxi` VALUES ('985', 'S17-825XLA34-020', '滑块', '1', '', '个', 'Φ190精镗(T235)', '');
INSERT INTO `zuchengmingxi` VALUES ('986', 'S17-825XL-CW', '滑块', '1', '', '个', 'Φ190精镗(T235)', '');
INSERT INTO `zuchengmingxi` VALUES ('987', 'C-AF23STUC1103', '刀夹', '1', '', '个', 'Φ190精镗(T235)', '');
INSERT INTO `zuchengmingxi` VALUES ('988', '345-C8-390S/410.100 200', 'HSK Capto刀柄', '1', '', '个', 'Φ200反精镗(T17)', '');
INSERT INTO `zuchengmingxi` VALUES ('989', 'C8-391.01-80100A', '抗震铣刀接柄', '1', '', '个', 'Φ200反精镗(T17)', '');
INSERT INTO `zuchengmingxi` VALUES ('990', 'C8-391.05C-32 030M', '接柄', '1', '', '个', 'Φ200反精镗(T17)', '');
INSERT INTO `zuchengmingxi` VALUES ('991', '890450232R56916', '非标镗刀头', '1', '', '个', 'Φ200反精镗(T17)', '');
INSERT INTO `zuchengmingxi` VALUES ('992', 'TCMT110304-KF3005', '车刀片', '1', '', '个', 'Φ200反精镗(T17)', '');
INSERT INTO `zuchengmingxi` VALUES ('993', '5692022-06', '冷却液套管', '1', '', '个', 'Φ200反精镗(T17)', '');
INSERT INTO `zuchengmingxi` VALUES ('994', 'R220.69-0080-10-8A', '方肩铣刀（8齿）', '1', '', '个', 'D80精铣(T199)', '');
INSERT INTO `zuchengmingxi` VALUES ('995', 'XOMX10T308TR-M09,MK1500', '刀片', '8', '', '个', 'D80精铣(T199)', '');
INSERT INTO `zuchengmingxi` VALUES ('996', 'M55254627R', '铣刀接柄', '1', '', '个', 'D80精铣(T199)', '');
INSERT INTO `zuchengmingxi` VALUES ('997', 'EM9306Y40146160', 'HSKA100基础刀柄', '1', '', '个', 'D80精铣(T199)', '');
INSERT INTO `zuchengmingxi` VALUES ('998', '20E9306', 'HSKA100冷却液管', '1', '', '个', 'D80精铣(T199)', '');
INSERT INTO `zuchengmingxi` VALUES ('999', '3718 25，000（L=121）看不到', 'HM粗铣刀', '1', '', '个', 'D25粗铣(T109)', '');
INSERT INTO `zuchengmingxi` VALUES ('1000', '4329 25，100（L=100)', '侧固刀柄', '1', '', '个', 'D25粗铣(T109)', '');
INSERT INTO `zuchengmingxi` VALUES ('1001', '4949 24.100', '冷却导管', '1', '', '个', 'D25粗铣(T109)', '');
INSERT INTO `zuchengmingxi` VALUES ('1002', '3627 25.000看不到', '精铣刀', '1', '', '个', 'D25精铣(T110)', '');
INSERT INTO `zuchengmingxi` VALUES ('1003', '4736 25.100（L=100)', '侧固刀柄', '1', '', '个', 'D25精铣(T110)', '');
INSERT INTO `zuchengmingxi` VALUES ('1004', '4949 24,100', '冷却导管', '1', '', '个', 'D25精铣(T110)', '');
INSERT INTO `zuchengmingxi` VALUES ('1005', '5510 8.700看不到', '整体硬钻', '1', '', '个', 'Φ8.7硬钻(T86)', '');
INSERT INTO `zuchengmingxi` VALUES ('1006', '4736 10.100', '热胀刀柄', '1', '', '个', 'Φ8.7硬钻(T86)', '');
INSERT INTO `zuchengmingxi` VALUES ('1007', '4949 24.100', '冷却管', '1', '', '个', 'Φ8.7硬钻(T86)', '');
INSERT INTO `zuchengmingxi` VALUES ('1008', '5510 11.100看不到', '整体硬钻', '1', '', '个', 'Φ11 硬钻(T88)', '');
INSERT INTO `zuchengmingxi` VALUES ('1009', '4736 12.100', '热胀刀柄', '1', '', '个', 'Φ11 硬钻(T88)', '');
INSERT INTO `zuchengmingxi` VALUES ('1010', '4949 24.100', '冷却管', '1', '', '个', 'Φ11 硬钻(T88)', '');
INSERT INTO `zuchengmingxi` VALUES ('1011', '5510 11.7看不到', '麻花钻', '1', '', '个', 'Φ11.7硬钻(T89)', '');
INSERT INTO `zuchengmingxi` VALUES ('1012', '4736 12.100', '热胀刀柄', '1', '', '个', 'Φ11.7硬钻(T89)', '');
INSERT INTO `zuchengmingxi` VALUES ('1013', '4949 24.100', '冷却管', '1', '', '个', 'Φ11.7硬钻(T89)', '');
INSERT INTO `zuchengmingxi` VALUES ('1014', 'D13*D14*168看不到', '整体硬钻', '1', '', '个', 'Φ13硬钻(T90)', '');
INSERT INTO `zuchengmingxi` VALUES ('1015', '4736 14.100', '热胀刀柄', '1', '', '个', 'Φ13硬钻(T90)', '');
INSERT INTO `zuchengmingxi` VALUES ('1016', '4949 24.100', '冷却管', '1', '', '个', 'Φ13硬钻(T90)', '');
INSERT INTO `zuchengmingxi` VALUES ('1017', '723 16.0看不到', '中心钻', '1', '', '个', '中心钻(T91)', '');
INSERT INTO `zuchengmingxi` VALUES ('1018', '4736 116.100', '热胀刀柄', '1', '', '个', '中心钻(T91)', '');
INSERT INTO `zuchengmingxi` VALUES ('1019', '4949 24.100', '冷却管', '1', '', '个', '中心钻(T91)', '');
INSERT INTO `zuchengmingxi` VALUES ('1020', '1090 10.006看不到', '丝锥', '1', '', '个', 'M10*1.25丝锥(T92)', '');
INSERT INTO `zuchengmingxi` VALUES ('1021', '4324 32.100', '弹簧夹头刀柄', '1', '', '个', 'M10*1.25丝锥(T92)', '');
INSERT INTO `zuchengmingxi` VALUES ('1022', '4308 7.032看不到', '弹簧夹套', '1', '', '个', 'M10*1.25丝锥(T92)', '');
INSERT INTO `zuchengmingxi` VALUES ('1023', '4325 7.032看不到', '密封环', '1', '', '个', 'M10*1.25丝锥(T92)', '');
INSERT INTO `zuchengmingxi` VALUES ('1024', '4949 24.100', '冷却管', '1', '', '个', 'M10*1.25丝锥(T92)', '');
INSERT INTO `zuchengmingxi` VALUES ('1025', '4306-32.600', '螺母', '1', '', '个', 'M10*1.25丝锥(T92)', '');
INSERT INTO `zuchengmingxi` VALUES ('1026', 'D12*90看不到', '非标铰刀', '1', '', '个', 'Φ12R8铰刀(T93)', '');
INSERT INTO `zuchengmingxi` VALUES ('1027', '4736 12.100', '热胀刀柄', '1', '', '个', 'Φ12R8铰刀(T93)', '');
INSERT INTO `zuchengmingxi` VALUES ('1028', '4949 24.100', '冷却管', '1', '', '个', 'Φ12R8铰刀(T93)', '');
INSERT INTO `zuchengmingxi` VALUES ('1029', '3736 20.000看不到', '立铣刀', '1', '', '个', 'Φ20铣刀(T50)', '');
INSERT INTO `zuchengmingxi` VALUES ('1030', '4736 20.100', '热胀刀柄', '1', '', '个', 'Φ20铣刀(T50)', '');
INSERT INTO `zuchengmingxi` VALUES ('1031', '4949 24.100', '冷却管', '1', '', '个', 'Φ20铣刀(T50)', '');
INSERT INTO `zuchengmingxi` VALUES ('1032', '347 22.007看不到', '丝锥', '1', '', '个', 'M22*1.5丝锥(T117)', '');
INSERT INTO `zuchengmingxi` VALUES ('1033', '4324 32.100', '弹簧夹头刀柄', '1', '', '个', 'M22*1.5丝锥(T117)', '');
INSERT INTO `zuchengmingxi` VALUES ('1034', '4308 18.032看不到', '弹簧夹套', '1', '', '个', 'M22*1.5丝锥(T117)', '');
INSERT INTO `zuchengmingxi` VALUES ('1035', '4306-32.600', '密封环', '1', '', '个', 'M22*1.5丝锥(T117)', '');
INSERT INTO `zuchengmingxi` VALUES ('1036', '4949 24.100', '冷却管', '1', '', '个', 'M22*1.5丝锥(T117)', '');
INSERT INTO `zuchengmingxi` VALUES ('1037', '4108 26.000看不到', 'HT800', '1', '', '个', 'Φ26钻头(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('1038', '4113 26.000', '刀片', '1', '', '个', 'Φ26钻头(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('1039', '4334 32.100', '测固刀柄', '1', '', '个', 'Φ26钻头(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('1040', '4949 24.100', '冷却管', '1', '', '个', 'Φ26钻头(T118)', '');
INSERT INTO `zuchengmingxi` VALUES ('1041', '4H0987242', '刀体', '1', '', '个', 'Φ27.7半精镗(T119)', '');
INSERT INTO `zuchengmingxi` VALUES ('1042', 'CCMT09T308-KM3210', 'Turn107菱形80°', '2', '', '个', 'Φ27.7半精镗(T119)', '');
INSERT INTO `zuchengmingxi` VALUES ('1043', '392.41027-100 32 100A', 'HSK 钻头接柄 ', '1', '', '个', 'Φ27.7半精镗(T119)', '');
INSERT INTO `zuchengmingxi` VALUES ('1044', '5692022-06', '冷却液管', '1', '', '个', 'Φ27.7半精镗(T119)', '');
INSERT INTO `zuchengmingxi` VALUES ('1045', '6711 12.000看不到', '合金倒角刀', '1', '', '个', 'Φ34铣刀(T120)', '');
INSERT INTO `zuchengmingxi` VALUES ('1046', '4719 12.125', '延长杆', '1', '', '个', 'Φ34铣刀(T120)', '');
INSERT INTO `zuchengmingxi` VALUES ('1047', '4736 25.100', '液压刀柄', '1', '', '个', 'Φ34铣刀(T120)', '');
INSERT INTO `zuchengmingxi` VALUES ('1048', '4949 24.100', '冷却导管', '1', '', '个', 'Φ34铣刀(T120)', '');
INSERT INTO `zuchengmingxi` VALUES ('1049', '5511 10.700看不到', '整体硬钻', '1', '', '个', 'Φ10.7钻头(T140)', '');
INSERT INTO `zuchengmingxi` VALUES ('1050', '4736 12.100', '热胀刀柄', '1', '', '个', 'Φ10.7钻头(T140)', '');
INSERT INTO `zuchengmingxi` VALUES ('1051', '4949 24.100', '冷却管', '1', '', '个', 'Φ10.7钻头(T140)', '');
INSERT INTO `zuchengmingxi` VALUES ('1052', '932 12.006', '丝锥', '1', '', '个', 'M12*1.25丝锥(T142)', '');
INSERT INTO `zuchengmingxi` VALUES ('1053', '4324 32.100', '弹簧夹头刀柄', '1', '', '个', 'M12*1.25丝锥(T142)', '');
INSERT INTO `zuchengmingxi` VALUES ('1054', '4308 9.032看不到', '弹簧夹套', '1', '', '个', 'M12*1.25丝锥(T142)', '');
INSERT INTO `zuchengmingxi` VALUES ('1055', '4335 9.032看不到', '密封环', '1', '', '个', 'M12*1.25丝锥(T142)', '');
INSERT INTO `zuchengmingxi` VALUES ('1056', '4949 24.100', '冷却管', '1', '', '个', 'M12*1.25丝锥(T142)', '');
INSERT INTO `zuchengmingxi` VALUES ('1057', '4306-32.600', '螺母', '1', '', '个', 'M12*1.25丝锥(T142)', '');
INSERT INTO `zuchengmingxi` VALUES ('1058', 'D10.7*D12*175看不到', '硬质合金钻', '1', '', '个', 'Φ10.7钻头(T141)', '');
INSERT INTO `zuchengmingxi` VALUES ('1059', '4736 12.100', 'ER刀柄', '1', '', '个', 'Φ10.7钻头(T141)', '');
INSERT INTO `zuchengmingxi` VALUES ('1060', '4307 11.025', 'ER夹头', '1', '', '个', 'Φ10.7钻头(T141)', '');
INSERT INTO `zuchengmingxi` VALUES ('1061', '4949 24.100', '冷却管', '1', '', '个', 'Φ10.7钻头(T141)', '');
INSERT INTO `zuchengmingxi` VALUES ('1062', 'D13*D14*97看不到', '非标铰刀', '1', '', '个', 'Φ13.2H7铰刀(T143)', '');
INSERT INTO `zuchengmingxi` VALUES ('1063', '4736 14.100', '热胀刀柄', '1', '', '个', 'Φ13.2H7铰刀(T143)', '');
INSERT INTO `zuchengmingxi` VALUES ('1064', '4949 24.100', '冷却管', '1', '', '个', 'Φ13.2H7铰刀(T143)', '');
INSERT INTO `zuchengmingxi` VALUES ('1065', '345-C8-390S/410-100 200', 'HSK Capto刀柄', '1', '', '个', 'Φ250*15宽精铣刀（T225)', '');
INSERT INTO `zuchengmingxi` VALUES ('1066', 'C8-391.10-50 030', 'Capto 铣刀接杆', '1', '', '个', 'Φ250*15宽精铣刀（T225)', '');
INSERT INTO `zuchengmingxi` VALUES ('1067', 'L331.52-250S50MM', '铣刀盘', '1', '', '个', 'Φ250*15宽精铣刀（T225)', '');
INSERT INTO `zuchengmingxi` VALUES ('1068', 'N331.1A-1150088E-KL1020', '铣刀片', '16', '', '个', 'Φ250*15宽精铣刀（T225)', '');
INSERT INTO `zuchengmingxi` VALUES ('1069', '5692022-06', '冷却液套管', '1', '', '个', 'Φ250*15宽精铣刀（T225)', '');
INSERT INTO `zuchengmingxi` VALUES ('1070', '5512 6.000看不到', '整体硬钻', '1', '', '个', 'Φ6钻头(T148)', '');
INSERT INTO `zuchengmingxi` VALUES ('1071', '4736 306.100', '热涨刀柄', '1', '', '个', 'Φ6钻头(T148)', '');
INSERT INTO `zuchengmingxi` VALUES ('1072', '4949 24.100', '冷却管', '1', '', '个', 'Φ6钻头(T148)', '');
INSERT INTO `zuchengmingxi` VALUES ('1073', '5510 12.5看不到', '整体硬钻', '1', '', '个', 'Φ12.5钻头(T144)', '');
INSERT INTO `zuchengmingxi` VALUES ('1074', '4736 14.100', '热胀刀柄', '1', '', '个', 'Φ12.5钻头(T144)', '');
INSERT INTO `zuchengmingxi` VALUES ('1075', '4949 24.100', '冷却管', '1', '', '个', 'Φ12.5钻头(T144)', '');
INSERT INTO `zuchengmingxi` VALUES ('1076', '347 14.700看不到', '丝锥', '1', '', '个', 'M14*1.5丝锥(T147)', '');
INSERT INTO `zuchengmingxi` VALUES ('1077', '4324 32.101', '弹簧夹头刀柄', '1', '', '个', 'M14*1.5丝锥(T147)', '');
INSERT INTO `zuchengmingxi` VALUES ('1078', '4308 11.032看不到', '弹簧夹套', '1', '', '个', 'M14*1.5丝锥(T147)', '');
INSERT INTO `zuchengmingxi` VALUES ('1079', '4306-32.600', '密封环', '1', '', '个', 'M14*1.5丝锥(T147)', '');
INSERT INTO `zuchengmingxi` VALUES ('1080', '4949 24.100', '冷却管', '1', '', '个', 'M14*1.5丝锥(T147)', '');
INSERT INTO `zuchengmingxi` VALUES ('1081', '5510 15.700看不到', '整体硬钻', '1', '', '个', 'Φ15.7钻头(T149)', '');
INSERT INTO `zuchengmingxi` VALUES ('1082', '4736 16.100', '热胀刀柄', '1', '', '个', 'Φ15.7钻头(T149)', '');
INSERT INTO `zuchengmingxi` VALUES ('1083', '4949 24.100', '冷却管', '1', '', '个', 'Φ15.7钻头(T149)', '');
INSERT INTO `zuchengmingxi` VALUES ('1084', '930-HA10-S-20-100', '高精度液压夹头', '1', '', '个', 'Φ20.2*3.5槽铣刀（T150)', '');
INSERT INTO `zuchengmingxi` VALUES ('1085', '393.CG-20 16 52', '高精度夹套', '1', '', '个', 'Φ20.2*3.5槽铣刀（T150)', '');
INSERT INTO `zuchengmingxi` VALUES ('1086', 'BU1310036看不到', '非标槽铣刀', '1', '', '个', 'Φ20.2*3.5槽铣刀（T150)', '');
INSERT INTO `zuchengmingxi` VALUES ('1087', '5692022-06', '冷却液套管', '1', '', '个', 'Φ20.2*3.5槽铣刀（T150)', '');
INSERT INTO `zuchengmingxi` VALUES ('1088', 'D16*150看不到', '非标铰刀', '1', '', '个', 'Φ16F9铰刀(T151)', '');
INSERT INTO `zuchengmingxi` VALUES ('1089', '4736 16.100', '热胀刀柄', '1', '', '个', 'Φ16F9铰刀(T151)', '');
INSERT INTO `zuchengmingxi` VALUES ('1090', '4949 24.100', '冷却管', '1', '', '个', 'Φ16F9铰刀(T151)', '');
INSERT INTO `zuchengmingxi` VALUES ('1091', 'C4-390.410-10090HD', '基本刀柄', '1', '', '个', 'Φ33.7粗镗(T145)', '');
INSERT INTO `zuchengmingxi` VALUES ('1092', 'c3-391.68A-2-026 084B', '整体式粗镗刀', '1', '', '个', 'Φ33.7粗镗(T145)', '');
INSERT INTO `zuchengmingxi` VALUES ('1093', 'C4-391.02-32 070A', '缩径接杆', '1', '', '个', 'Φ33.7粗镗(T145)', '');
INSERT INTO `zuchengmingxi` VALUES ('1094', 'CCMT060208-KM3215', '车刀片', '2', '', '个', 'Φ33.7粗镗(T145)', '');
INSERT INTO `zuchengmingxi` VALUES ('1095', '5692022-06', '冷却液套管', '1', '', '个', 'Φ33.7粗镗(T145)', '');
INSERT INTO `zuchengmingxi` VALUES ('1096', '391.68A-2-038 13C06B', '滑块', '2', '', '个', 'Φ33.7粗镗(T145)', '');
INSERT INTO `zuchengmingxi` VALUES ('1097', 'C4-390.410-100090HD', '基本刀柄', '1', '', '个', 'φ35.4半精镗(T146)', '');
INSERT INTO `zuchengmingxi` VALUES ('1098', 'C3-391.68A-2-026084B', '整体式粗镗刀', '1', '', '个', 'φ35.4半精镗(T146)', '');
INSERT INTO `zuchengmingxi` VALUES ('1099', '391.68A-2-038 13C06B', '刀夹', '2', '', '个', 'φ35.4半精镗(T146)', '');
INSERT INTO `zuchengmingxi` VALUES ('1100', 'C4--391.02-32 070A', '缩径接杆', '1', '', '个', 'φ35.4半精镗(T146)', '');
INSERT INTO `zuchengmingxi` VALUES ('1101', 'CCMT060208-KM3215', '车刀片', '2', '', '个', 'φ35.4半精镗(T146)', '');
INSERT INTO `zuchengmingxi` VALUES ('1102', '5692022-06', '冷却液套管', '1', '', '个', 'φ35.4半精镗(T146)', '');
INSERT INTO `zuchengmingxi` VALUES ('1103', '391.68A-2-038 13C06B', '滑块', '2', '', '个', 'φ88.5粗镗(T170)', '');
INSERT INTO `zuchengmingxi` VALUES ('1104', '无号', '垫刀块', '2', '', '个', 'φ88.5粗镗(T170)', '');
INSERT INTO `zuchengmingxi` VALUES ('1105', 'C6-391.68A-6-063 045C', '接柄', '1', '', '个', 'φ88.5粗镗(T170)', '');
INSERT INTO `zuchengmingxi` VALUES ('1106', 'C6-390.410-100110HD', '刀柄', '1', '', '个', 'φ88.5粗镗(T170)', '');
INSERT INTO `zuchengmingxi` VALUES ('1107', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'φ88.5粗镗(T170)', '');
INSERT INTO `zuchengmingxi` VALUES ('1108', '5692022-06', '冷却液套管', '1', '', '个', 'φ88.5粗镗(T170)', '');
INSERT INTO `zuchengmingxi` VALUES ('1109', '391.68A-2-038 13C06B', '滑块', '2', '', '个', 'φ89.7半精镗(T171)', '');
INSERT INTO `zuchengmingxi` VALUES ('1110', 'C6-391.68A-6-063 045C', '接柄', '1', '', '个', 'φ89.7半精镗(T171)', '');
INSERT INTO `zuchengmingxi` VALUES ('1111', 'C6-390.410-100110HD', 'HSK Capto刀柄', '1', '', '个', 'φ89.7半精镗(T171)', '');
INSERT INTO `zuchengmingxi` VALUES ('1112', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'φ89.7半精镗(T171)', '');
INSERT INTO `zuchengmingxi` VALUES ('1113', '5692022-06', '冷却液套管', '1', '', '个', 'φ89.7半精镗(T171)', '');
INSERT INTO `zuchengmingxi` VALUES ('1114', '无号', '垫刀块', '2', '', '个', 'φ89.7半精镗(T171)', '');
INSERT INTO `zuchengmingxi` VALUES ('1115', 'C6-391.68A-6-063 045C', '接柄', '1', '', '个', 'φ80粗镗(T172)', '');
INSERT INTO `zuchengmingxi` VALUES ('1116', 'C6-390.410-100110HD', '刀柄', '1', '', '个', 'φ80粗镗(T172)', '');
INSERT INTO `zuchengmingxi` VALUES ('1117', 'C6-390.01-63 100A', '加长接柄', '1', '', '个', 'φ80粗镗(T172)', '');
INSERT INTO `zuchengmingxi` VALUES ('1118', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'φ80粗镗(T172)', '');
INSERT INTO `zuchengmingxi` VALUES ('1119', '5692022-06', '冷却液套管', '1', '', '个', 'φ80粗镗(T172)', '');
INSERT INTO `zuchengmingxi` VALUES ('1120', '391.68A-2-038 13C06B', '滑块', '2', '', '个', 'φ80粗镗(T172)', '');
INSERT INTO `zuchengmingxi` VALUES ('1121', '无号', '垫刀块', '2', '', '个', 'φ80粗镗(T172)', '');
INSERT INTO `zuchengmingxi` VALUES ('1122', 'C6-391.68A-6-063 045C', '接柄', '1', '', '个', 'φ84.7半精镗(T173)', '');
INSERT INTO `zuchengmingxi` VALUES ('1123', 'C6-390.410-100110HD', '刀柄', '1', '', '个', 'φ84.7半精镗(T173)', '');
INSERT INTO `zuchengmingxi` VALUES ('1124', 'TCMT16T308-KM3215', '车刀片', '2', '', '个', 'φ84.7半精镗(T173)', '');
INSERT INTO `zuchengmingxi` VALUES ('1125', 'C6-390.01-63 100A', '加长接杆', '1', '', '个', 'φ84.7半精镗(T173)', '');
INSERT INTO `zuchengmingxi` VALUES ('1126', '5692022-06', '冷却液套管', '1', '', '个', 'φ84.7半精镗(T173)', '');
INSERT INTO `zuchengmingxi` VALUES ('1127', '391.68A-2-038 13C06B', '滑块', '2', '', '个', 'φ84.7半精镗(T173)', '');
INSERT INTO `zuchengmingxi` VALUES ('1128', '无号', '垫刀块', '2', '', '个', 'φ84.7半精镗(T173)', '');
INSERT INTO `zuchengmingxi` VALUES ('1129', 'R220.49-0040-12', '倒角铣刀', '1', '', '个', 'D40/C45倒角铣(T180)', '');
INSERT INTO `zuchengmingxi` VALUES ('1130', 'SPMX12T3AP-75，F40M', '刀片', '3', '', '个', 'D40/C45倒角铣(T180)', '');
INSERT INTO `zuchengmingxi` VALUES ('1131', 'M55252822R', '铣刀接柄', '1', '', '个', 'D40/C45倒角铣(T180)', '');
INSERT INTO `zuchengmingxi` VALUES ('1132', 'M402551', '加长杆（L=75)', '1', '', '个', 'D40/C45倒角铣(T180)', '');
INSERT INTO `zuchengmingxi` VALUES ('1133', 'EM930640128110', '基础刀柄', '1', '', '个', 'D40/C45倒角铣(T180)', '');
INSERT INTO `zuchengmingxi` VALUES ('1134', '20E9306', '冷却套管', '1', '', '个', 'D40/C45倒角铣(T180)', '');
INSERT INTO `zuchengmingxi` VALUES ('1135', 'R220.66-0063-12-4', '面铣刀（60°）', '1', '', '个', 'D63/C30铣刀（T169)', '');
INSERT INTO `zuchengmingxi` VALUES ('1136', 'HPMN1206ZETR-MD20，MK2050', '刀片', '4', '', '个', 'D63/C30铣刀（T169)', '');
INSERT INTO `zuchengmingxi` VALUES ('1137', 'E9306552522100', '铣刀刀柄', '1', '', '个', 'D63/C30铣刀（T169)', '');
INSERT INTO `zuchengmingxi` VALUES ('1138', '20E9306', '冷却液管', '1', '', '个', 'D63/C30铣刀（T169)', '');
INSERT INTO `zuchengmingxi` VALUES ('1139', 'R335.15-063-05.22-5', '槽铣刀', '1', '', '个', 'φ63*3.15槽铣刀(T174)', '');
INSERT INTO `zuchengmingxi` VALUES ('1140', 'R335.15-18315FG-M12，F40M', '刀片', '5', '', '个', 'φ63*3.15槽铣刀(T174)', '');
INSERT INTO `zuchengmingxi` VALUES ('1141', 'E9306552522160', '铣刀刀柄', '1', '', '个', 'φ63*3.15槽铣刀(T174)', '');
INSERT INTO `zuchengmingxi` VALUES ('1142', '20E9306', '冷却液管', '1', '', '个', 'φ63*3.15槽铣刀(T174)', '');
INSERT INTO `zuchengmingxi` VALUES ('1143', 'C6-390.410-100110A', '刀柄', '1', '', '个', 'Φ90精镗(T175)', '');
INSERT INTO `zuchengmingxi` VALUES ('1144', 'C6-R825C-AAG 067A', '接柄', '1', '', '个', 'Φ90精镗(T175)', '');
INSERT INTO `zuchengmingxi` VALUES ('1145', 'TCMT110304-KF3005', '车刀片', '1', '', '个', 'Φ90精镗(T175)', '');
INSERT INTO `zuchengmingxi` VALUES ('1146', '5692022-06', '冷却液套管', '1', '', '个', 'Φ90精镗(T175)', '');
INSERT INTO `zuchengmingxi` VALUES ('1147', 'C-AFR23STUC1103', '鹰嘴', '1', '', '个', 'Φ90精镗(T175)', '');
INSERT INTO `zuchengmingxi` VALUES ('1148', 'C8-390.410-100120A', '刀柄', '1', '', '个', 'Φ85精镗(T176)', '');
INSERT INTO `zuchengmingxi` VALUES ('1149', 'C8-391.02-63 080A', '接杆', '1', '', '个', 'Φ85精镗(T176)', '');
INSERT INTO `zuchengmingxi` VALUES ('1150', 'C8-R825C-AAF055A', '整体式精镗刀头', '1', '', '个', 'Φ85精镗(T176)', '');
INSERT INTO `zuchengmingxi` VALUES ('1151', 'TCMT110304-KF3005', '车刀片', '1', '', '个', 'Φ85精镗(T176)', '');
INSERT INTO `zuchengmingxi` VALUES ('1152', '5692022-06', '冷却液套管', '1', '', '个', 'Φ85精镗(T176)', '');
INSERT INTO `zuchengmingxi` VALUES ('1153', 'C-AFR23STUC1103', '鹰嘴', '1', '', '个', 'Φ85精镗(T176)', '');
INSERT INTO `zuchengmingxi` VALUES ('1154', 'C3-390.410-100080A', '刀柄', '1', '', '个', 'φ35.72镗刀(T177)', '');
INSERT INTO `zuchengmingxi` VALUES ('1155', 'C3-R825A-FAB 208A', '精镗刀杆', '1', '', '个', 'φ35.72镗刀(T177)', '');
INSERT INTO `zuchengmingxi` VALUES ('1156', 'TCMT06T04-KF3005', '车刀片', '1', '', '个', 'φ35.72镗刀(T177)', '');
INSERT INTO `zuchengmingxi` VALUES ('1157', '5692022-06', '冷却液套管', '1', '', '个', 'φ35.72镗刀(T177)', '');
INSERT INTO `zuchengmingxi` VALUES ('1158', 'A-AF STUC06T', '鹰嘴', '1', '', '个', 'φ35.72镗刀(T177)', '');
INSERT INTO `zuchengmingxi` VALUES ('1159', 'C3-390.410-100080A', '刀柄', '1', '', '个', 'Φ30精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('1160', 'C3-R825A-AAB 072A', '精镗刀杆', '1', '', '个', 'Φ30精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('1161', 'TCMT06T04-KF3005', '车刀片', '1', '', '个', 'Φ30精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('1162', '5692022-06', '冷却液套管', '1', '', '个', 'Φ30精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('1163', 'A-AF STUC06T', '鹰嘴', '1', '', '个', 'Φ30精镗(T62)', '');
INSERT INTO `zuchengmingxi` VALUES ('1164', '4107 20.500（看不到）', 'HT800刀体', '1', '', '个', 'φ20.5钻头(T116)', '');
INSERT INTO `zuchengmingxi` VALUES ('1165', '4334 25.100', '侧固刀柄', '1', '', '个', 'φ20.5钻头(T116)', '');
INSERT INTO `zuchengmingxi` VALUES ('1166', '4113 20.500（看不到）', '刀片', '1', '', '个', 'φ20.5钻头(T116)', '');
INSERT INTO `zuchengmingxi` VALUES ('1167', '4949 24.100', '冷却管', '1', '', '个', 'φ20.5钻头(T116)', '');
INSERT INTO `zuchengmingxi` VALUES ('1168', 'C8-390.410-100120A(主刀杆）', 'HSK Capto刀柄', '1', 'φ180', '个', 'φ180粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1169', '820-200TC22-C8（①②③）', 'Coropak13.1', '1', 'φ180', '套', 'φ180粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1170', 'TCMT220408-KR3215', 'CoroTum107车刀片', '2', 'φ180', '个', 'φ180粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1171', '5692022-06', '冷却液套管', '1', 'φ180', '个', 'φ180粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1172', '392.410XL-10040080', 'Coropak13.1', '1', 'φ416', '个', 'φ416粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1173', '820-460TC22(①②③)', '820整体式粗镗刀', '1', 'φ416', '套', 'φ416粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1174', 'TCMT220408-KR3215', 'CoroTum107车刀片', '2', 'φ416', '个', 'φ416粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1175', '5692022-06', '冷却液套管', '1', 'φ416', '个', 'φ416粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1176', 'C8-390.410-100120A(主刀杆）', 'HSK Capto刀柄', '1', 'Φ170', '个', 'Φ170粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1177', '820-200TC22-C8（①②③）', 'Coropak13.1', '1', 'Φ170', '套', 'Φ170粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1178', 'TCMT220408-KR3215', 'CoroTum107车刀片', '2', 'Φ170', '个', 'Φ170粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1179', '5692022-06', '冷却液套管', '1', 'Φ170', '个', 'Φ170粗镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1180', 'C8-390.410-100120A(主刀杆）', 'HSK Capto刀柄', '1', 'Φ120', '个', 'Φ120精镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1181', '825-137T11-C8', '820整体式精镗刀', '1', 'Φ120', '个', 'Φ120精镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1182', 'TCMT110304-KF3005', 'CoroTum107车刀片', '1', 'Φ120', '个', 'Φ120精镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1183', '5692022-06', '冷却液套管', '1', 'Φ120', '个', 'Φ120精镗刀', '');
INSERT INTO `zuchengmingxi` VALUES ('1184', 'MCLNL2525M12', '左手刀杆', '1', '', '个', '外圆粗车刀制动器活塞OP20(T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1185', 'CNMG120412UN KCK15B（CNMG120412-KR3210)', '刀片', '1', '', '个', '外圆粗车刀制动器活塞OP20(T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1186', 'A50UMCLNL12', '左手刀杆', '1', '', '个', '内孔粗车刀制动器活塞OP20(T02)', '');
INSERT INTO `zuchengmingxi` VALUES ('1187', 'CNMG120412UN KCK15B（CNMG120412-KR3210)', '刀片', '1', '', '个', '内孔粗车刀制动器活塞OP20(T02)', '');
INSERT INTO `zuchengmingxi` VALUES ('1188', 'MWLNL2525M08H4', '左手刀杆', '1', '', '个', '外圆精车刀制动器活塞OP20(T03)', '');
INSERT INTO `zuchengmingxi` VALUES ('1189', 'WNGA080408', '刀片', '1', '', '个', '外圆精车刀制动器活塞OP20(T03)', '');
INSERT INTO `zuchengmingxi` VALUES ('1190', 'LAG123G09-32B', '刀杆', '1', '', '个', '倒角车刀制动器活塞OP20(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1191', 'N123G2-0300-0004-GF1125', '刀片', '1', '', '个', '倒角车刀制动器活塞OP20(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1192', 'A40TMWLNL08', '左手刀杆', '1', '', '个', '内孔精车刀制动器活塞OP20(T05)', '');
INSERT INTO `zuchengmingxi` VALUES ('1193', 'WNGA080408MW KCP05', '刀片', '1', '', '个', '内孔精车刀制动器活塞OP20(T05)', '');
INSERT INTO `zuchengmingxi` VALUES ('1194', '50-40', '变径套', '1', '', '个', '内孔精车刀制动器活塞OP30(T05)', '');
INSERT INTO `zuchengmingxi` VALUES ('1195', 'MCLNL2525M12', '左手刀杆', '2', '', '个', '外圆粗车刀制动器活塞OP30(T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1196', 'CNMG120412UN KCK15B（CNMG120412-KR3210)', '刀片', '2', '', '个', '外圆粗车刀制动器活塞OP30(T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1197', 'MVJNL2525M16', '左手刀杆', '2', '', '个', '外圆偏车刀制动器活塞OP30(T02)', '');
INSERT INTO `zuchengmingxi` VALUES ('1198', 'VNMG160404FN KCP10', '刀片', '2', '', '个', '外圆偏车刀制动器活塞OP30(T02)', '');
INSERT INTO `zuchengmingxi` VALUES ('1199', 'MWLNL2525M08H4', '左手刀杆', '2', '', '个', '外圆精车刀制动器活塞OP30(T03)', '');
INSERT INTO `zuchengmingxi` VALUES ('1200', 'WNGA080408MW KCP05', '刀片', '1', '', '个', '外圆精车刀制动器活塞OP30(T03)', '');
INSERT INTO `zuchengmingxi` VALUES ('1201', 'D10.55×7.5×D14×F30×L98×SL45 DOHN5774', '钻头', '2', '', '个', 'D10.5*D14组合钻头制动器活塞OP30(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1202', 'D10.55×7.5×D14×F30×L98×SL45DIHN3164', '钻头', '2', '', '个', 'D10.5*D14组合钻头制动器活塞OP30(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1203', 'ER32-14', '筒夹', '4', '', '个', 'D10.5*D14组合钻头制动器活塞OP30(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1204', '1A 600×80×203.2PA80K7V', '砂轮', '1', '', '个', '外圆磨制动器活塞OP40（T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1205', 'JS-BSB-002-1', '斧型金刚笔', '1', '', '个', '外圆磨制动器活塞OP40（T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1206', 'MCLNL2525M12', '左手刀杆', '2', '', '个', '外圆粗车刀轴承座OP10(T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1207', 'CNMG120412UN KCK15B（CNMG120412-KR3210)', '刀片', '2', '', '个', '外圆粗车刀轴承座OP10(T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1208', 'A50UMCLNL12', '左手刀杆', '2', '', '个', '内孔粗车刀轴承座OP10(T02)', '');
INSERT INTO `zuchengmingxi` VALUES ('1209', 'CNMG120412UN KCK15B（CNMG120412-KR3210)', '刀片', '2', '', '个', '内孔粗车刀轴承座OP10(T02)', '');
INSERT INTO `zuchengmingxi` VALUES ('1210', 'MWLNL2525M08H4', '左手刀杆', '2', '', '个', '外圆精车刀轴承座OP10(T03)', '');
INSERT INTO `zuchengmingxi` VALUES ('1211', 'WNMG080404FP KCP10', '刀片', '2', '', '个', '外圆精车刀轴承座OP10(T03)', '');
INSERT INTO `zuchengmingxi` VALUES ('1212', 'A40TMWLNL08', '左手刀杆', '2', '', '个', '内孔精车刀轴承座OP10(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1213', 'WNMG080404FP KCP10', '刀片', '2', '', '个', '内孔精车刀轴承座OP10(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1214', '50-40', '变径套', '2', '', '个', '内孔精车刀轴承座OP10(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1215', 'D11.02×D14×L120 13405', '钻头', '2', '', '个', 'D11*C1组合钻头轴承座OP10(T05)', '');
INSERT INTO `zuchengmingxi` VALUES ('1216', 'ER32-14', '夹套', '0', '', '个', 'D11*C1组合钻头轴承座OP10(T05)', '');
INSERT INTO `zuchengmingxi` VALUES ('1217', 'MCLNL2525M12', '左手刀杆', '1', '', '个', '外圆粗车刀轴承座OP20(T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1218', 'CNMG120412UN KCK15B（CNMG120412-KR3210)', '刀片', '1', '', '个', '外圆粗车刀轴承座OP20(T01)', '');
INSERT INTO `zuchengmingxi` VALUES ('1219', 'MWLNL2525M08H4', '左手刀杆', '1', '', '个', '外圆精车刀轴承座OP20(T02)', '');
INSERT INTO `zuchengmingxi` VALUES ('1220', 'CNMG120412UN KCK15B（CNMG120412-KR3210)', '刀片', '1', '', '个', '外圆精车刀轴承座OP20(T02)', '');
INSERT INTO `zuchengmingxi` VALUES ('1221', 'A50UMCLNL12', '左手刀杆', '1', '', '个', '内孔粗车刀轴承座OP20(T03)', '');
INSERT INTO `zuchengmingxi` VALUES ('1222', 'CNMG120412UN KCK15B（CNMG120412-KR3210)', '刀片', '1', '', '个', '内孔粗车刀轴承座OP20(T03)', '');
INSERT INTO `zuchengmingxi` VALUES ('1223', 'D16×80 13400', '倒角刀', '1', '', '个', 'D16倒角钻轴承座OP20(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1224', 'ER32-16', '夹套', '0', '', '个', 'D16倒角钻轴承座OP20(T04)', '');
INSERT INTO `zuchengmingxi` VALUES ('1225', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1226', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1227', 'HSK A 100 SEM 32X100 C', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1228', 'T490 FLN D100-13-32-R-13', '铣刀盘', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1229', 'T490 LNMT 1306PNTR  IC810', '刀片', '13', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1230', 'SR34-535-SN', '压刀螺钉', '13', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1231', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1232', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1233', 'T490 LNMT 1306PNTR  IC810', '刀片', '65', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1234', 'SR34-535-SN', '压刀螺钉', '65', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1235', 'T490LNK80*151-5-HSK100-13', '玉米粒铣刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1236', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1237', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1238', 'HSK A 100 SEM 32X100 C', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1239', 'F90LN D100-12-32-R-15', '铣刀盘', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1240', 'LNKX  1506PNTN  IC910', '刀片', '12', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1241', 'SR34-535-SN', '压刀螺钉', '12', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1242', 'AST-4625726', '楔块', '12', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1243', 'SR M4-LR-4026147', '楔块螺钉', '12', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1244', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1245', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1246', 'T490 FLN D050-06-22-R-13', '铣刀盘', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1247', 'T490 LNMT 1306PNTR  IC810', '刀片', '6', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1248', 'SR34-535-SN', '压刀螺钉', '6', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1249', 'HSK A 100 SEM 22X19X200', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1250', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1251', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1252', 'HSK A 100 SRKIN 20X160', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1253', 'DCN 170-085-20R-5D', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1254', 'ICK 175            IC908', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1255', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1256', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1257', 'HSK A 100 EM 20X110 E', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1258', 'AOMT 060204-45DT   IC908', '倒角刀片', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1259', 'SR34-508', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1260', 'MN125 033NA-N3R461933', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1261', 'ICK 125            IC908', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1262', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1263', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1264', 'HSK A 100 MB50X120', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1265', 'EMH MB50-20', '钻头接柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1266', 'AOMT 060204-45DT   IC908', '倒角刀片', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1267', 'SR34-508', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1268', 'ICK 145            IC908', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1269', 'MN145 038NA-N3R461939', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1270', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1271', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1272', 'HSK A 100 SRKIN 10X 90', '热涨刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1273', 'SCD 087-049-100 ACP5  908', '硬钻', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1274', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1275', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1276', 'HSK A 100 EM 20X110 E', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1277', 'ICK 140            IC908', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1278', 'AOMT 060204-45DT   IC908', '倒角刀片', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1279', 'SR34-508', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1280', 'MN140 050NA-N3R461983', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1281', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1282', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1283', 'HSK A 100 EM 16X100', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1284', 'DCN 120-036-16A-3D', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1285', 'ICK 120            IC908', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1286', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1287', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1288', 'HSK A 100 SRKIN 8X160', '热涨刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1289', 'SCD 068-043-080 ACP5  908', '硬钻', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1290', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1291', 'HSK A 100 MB50X120', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1292', 'EMH MB50-20', '接柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1293', 'ICK 130            IC908', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1294', 'AOMT 060204-45DT   IC908', '倒角刀片', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1295', 'SR34-508', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1296', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1297', 'MN130 020NA-N3R461973', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1298', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1299', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1300', 'HSK A 100 SRKIN 20X160', '热涨刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1301', 'MM S-A-L090-C20-T12-W-H', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1302', 'MM HCD200-090-2T12 IC908', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1303', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1304', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1305', 'HSK A 100 ER32X100', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1306', 'ER32 GB S 11X9.00 V1', '丝锥夹套', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1307', 'STP9 M14X1.5 6HX HSS-E', '丝锥', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1308', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1309', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1310', 'HSK A 100 ER32X100', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1311', 'FZ111300.11', '延长杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1312', 'ER32 GB 12X 9', '丝锥夹套', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1313', 'STP9 M16X1.5 6HX', '丝锥', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1314', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1315', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1316', 'HSK A 100 ER16X100', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1317', 'ER16 GB 7.0X5.6', '丝锥夹套', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1318', 'STP9 M10X1.25 6HX', '丝锥', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1319', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1320', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1321', 'HSK A 100 EM 20X160', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1322', 'SOMX 050204-DT     IC9080', '刀片', '4', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1323', 'SR34-533/L', '压刀螺钉', '4', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1324', 'MR195 025NA-P4B461952', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1325', 'ASS-120725-T272', '可换刀头式铰刀', '1', 'φ20F7×295', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1326', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1327', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1328', 'HSK A 100 SRKIN 20×105', '刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1329', 'RM-BNT8-3D-20C', 'SHANK 铰刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1330', 'RM-BN8-20.000-F7SE-IC908', '刀头', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1331', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1332', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1333', 'HSK A 100 EM 32X120 E', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1334', 'SOMT 09T306-DT     IC8080', '周边刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1335', 'SOMT 09T306-DT     IC908', '中心刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1336', 'SR34-506', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1337', 'SOMX 070305-DT     IC8080', '倒角刀片', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1338', 'SR14-560', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1339', 'SOMT 110408-DT     IC8080', '锪面刀片', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1340', 'SR34-508', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1341', 'MR290 069NC-F6R461959', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1342', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1343', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1344', 'SOMX 070305-DT     IC8080', '倒角刀片', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1345', 'SR14-560', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1346', 'LNMX 110408L-HT    IC5005', '镗孔刀片', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1347', 'SR34-550-C', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1348', 'HSK A 100 SEM 32X24X200', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1349', 'CR SSXOR-07-65172', '倒角刀夹', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1350', 'SRM4×16 ISO7380', '螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1351', 'CR-LN11-L-64584', '镗刀夹', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1352', 'SRM8×25 ISO7380', '螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1353', 'CB D82-32-LN11-64580', '粗镗头', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1354', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1355', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1356', 'HSK A 100 EM 20X100', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1357', 'MN150 032WA-N3R65120', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1358', 'AOMT 060204-45DT   IC908', '倒角刀片', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1359', 'SR34-508', '压刀螺钉', '2', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1360', 'ICK 151            IC908', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1361', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1362', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1363', 'HSK A 100 EM 16X100 E', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1364', 'CCMT 060204-14     IC5005', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1365', 'SR14-560/S', '压刀螺钉', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1366', 'MR220 002NR-Q1B465175', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1367', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1368', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1369', 'HSK A 100 EM 16X100 E', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1370', 'CCMT 060204-14     IC5005', '刀片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1371', 'SR14-560/S', '压刀螺钉', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1372', 'MR240 002NR-Q1B464530', '刀杆', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1373', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1374', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1375', 'HSK A 100 ER32X100', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1376', 'TP9 M14X2.0 6HX HSS-E', '丝锥', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1377', 'ER32 GB S D 11X9.00 V1', '丝锥夹套', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1378', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1379', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1380', 'HSK A 100 ER16X160', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1381', 'TP9 M8X1.25 6HX HSS-E', '丝锥', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1382', 'ER16 GB  D 8.0X6.3', '丝锥夹套', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1383', 'CHIP BIS.C122-04/L', '芯片', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1384', 'COOLING TUBE HSK A100', '冷却管', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1385', 'HSK A 100 ER32X160', '主刀柄', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1386', 'TP9 M16X2.0 6HX HSS-E', '丝锥', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1387', 'ER32 GB  D  12X 9', '丝锥夹套', '1', '', '个', '减速器自动线', '');
INSERT INTO `zuchengmingxi` VALUES ('1388', 'ST0792', '阶梯硬钻', '1', 'L=131 L4=25', '个', 'Φ8.5-25/120°(T1002)', '');
INSERT INTO `zuchengmingxi` VALUES ('1389', 'ST0791', '阶梯硬钻', '1', 'L=103 L4=19', '个', 'Φ6.8-19/120°(T1004)', '');
INSERT INTO `zuchengmingxi` VALUES ('1390', 'TM870.2.1-553246（看不到）', '阶梯刀杆', '1', 'L=123 L4=67', '个', 'Φ22.1-35/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('1391', 'TM8800-553248（看不到）', '刀杆', '1', 'L=130 L4=30', '个', 'Φ20.5-30/Ø32 (T1010)', '');
INSERT INTO `zuchengmingxi` VALUES ('1392', 'ST0789', '阶梯钻', '1', ' L=118 L4=30', '个', 'Φ10.3-30/120°(T1012)', '');
INSERT INTO `zuchengmingxi` VALUES ('1393', 'TM880-553682(看不到）', '刀杆', '1', 'L=108 Ø29-40/90°DM40', '个', 'Φ29阶梯钻(T1031)', '');
INSERT INTO `zuchengmingxi` VALUES ('1394', 'TM870.2.1-553751(看不到）', '刀杆', '1', 'L4=72 Ø17-47/90°DM25', '个', 'Φ17-47/90°(T1036)', '');
INSERT INTO `zuchengmingxi` VALUES ('1395', 'ST0785', '硬钻', '1', 'L=143 L4=47 120°', '个', 'Φ14.5/120°（T1037)', '');
INSERT INTO `zuchengmingxi` VALUES ('1396', '428.920000-0620-906', '枪钻', '1', 'L=620 DM25 Φ20H9', '个', 'Φ20H9枪钻(T1046)', '');
INSERT INTO `zuchengmingxi` VALUES ('1397', 'ST0757Φ14.5×42×120°×Φ18×143', '硬钻', '1', 'L=143 L4=42', '个', 'Φ14.5-42/90°(T1003)', '');
INSERT INTO `zuchengmingxi` VALUES ('1398', 'ST0760Φ14.5×47×120°×Φ18×143', '阶梯硬钻', '1', 'L=143 L4=47', '个', 'Φ14.5-47/90°(T1004)', '');
INSERT INTO `zuchengmingxi` VALUES ('1399', 'ST0759Φ17×40×90°×Φ20×131', '硬钻', '1', ' L=131 L4=40', '个', 'Φ17-40/90°(T1006)', '');
INSERT INTO `zuchengmingxi` VALUES ('1400', 'ST0761Φ14.5×17×90°×Φ18×118', '阶梯硬钻', '1', 'L=118 L4=17 ', '个', 'Φ14.5-17/90°(T1007)', '');
INSERT INTO `zuchengmingxi` VALUES ('1401', 'ST0761Φ11.5×16×90°×Φ14×103', '非标阶梯硬钻', '1', 'L=103 L4=16', '个', 'Φ11.5-16/90°(T1012)', '');
INSERT INTO `zuchengmingxi` VALUES ('1402', 'ST0765Φ8.8×22×120°×Φ12×103', '非标阶梯硬钻', '1', 'L=103 L4=16', '个', 'Φ8.8-22/90°(T1014)', '');
INSERT INTO `zuchengmingxi` VALUES ('1403', 'TM870.2.1-549576 mod（看不见）', '阶梯刀杆', '1', 'L=117.4 L4=61.4', '个', 'Φ20.5-30/90°(T1018)', '');
