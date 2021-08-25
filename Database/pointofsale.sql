-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Aug 24, 2021 at 11:51 PM
-- Server version: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pointofsale`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

DROP TABLE IF EXISTS `barang`;
CREATE TABLE IF NOT EXISTS `barang` (
  `kode` varchar(25) NOT NULL,
  `nama` varchar(200) NOT NULL,
  `kategori` int(11) NOT NULL,
  `satuan` int(11) NOT NULL,
  `harga_beli` float NOT NULL DEFAULT '0',
  `harga` float NOT NULL DEFAULT '0',
  `kadaluarsa` varchar(15) NOT NULL,
  `stok` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`kode`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`kode`, `nama`, `kategori`, `satuan`, `harga_beli`, `harga`, `kadaluarsa`, `stok`) VALUES
('BRG-2021-000000001', 'Beras 3 King 10kg', 1, 1, 104000, 104500, '1679047585000', 50),
('BRG-2021-000000002', 'Beras Belida 10kg', 1, 1, 104000, 104500, '1686737327000', 54),
('BRG-2021-000000003', 'Beras Belida 10kg', 1, 1, 10500, 105500, '1686737366000', 46),
('BRG-2021-000000004', 'Minyak Sayur Grandco 2ltr', 1, 2, 25000, 25500, '1657275016000', 43),
('BRG-2021-000000005', 'Minyak Sayur Grandco 1ltr', 1, 2, 13000, 13500, '1648980690000', 46),
('BRG-2021-000000006', 'Mie Sedaap ayam goreng', 2, 4, 2000, 2500, '1686737547000', 143),
('BRG-2021-000000007', 'HIT MAT elektrik', 3, 3, 7000, 8000, '1718200076000', 96),
('BRG-2021-0000000015', 'VAPE', 3, 4, 1500, 3000, '1691632315000', 35),
('BRG-2021-000000009', 'ale ale jeruk', 5, 3, 1500, 2000, '1752767487000', 198),
('BRG-2021-000000010', 'Air Mineral Citra 220', 5, 3, 500, 1000, '1683907566000', 195);

-- --------------------------------------------------------

--
-- Table structure for table `barang_masuk`
--

DROP TABLE IF EXISTS `barang_masuk`;
CREATE TABLE IF NOT EXISTS `barang_masuk` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kode_barang` varchar(25) NOT NULL,
  `nama_barang` varchar(100) NOT NULL,
  `tanggal` int(2) NOT NULL,
  `bulan` int(2) NOT NULL,
  `tahun` int(4) NOT NULL,
  `qty` int(11) NOT NULL,
  `kode_suplier` varchar(25) NOT NULL,
  `users` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `barang_masuk`
--

INSERT INTO `barang_masuk` (`id`, `kode_barang`, `nama_barang`, `tanggal`, `bulan`, `tahun`, `qty`, `kode_suplier`, `users`) VALUES
(1, 'BRG-2021-000000001', 'Beras 3 King 10kg', 30, 1, 2021, 50, 'SUPL20210206001', 'irwan'),
(2, 'BRG-2021-000000002', 'Beras Belida 10kg', 31, 2, 2021, 60, 'SUPL20210206001', 'irwan'),
(3, 'BRG-2021-000000003', 'Beras Belida 10kg', 2, 2, 2021, 50, 'SUPL20210206001', 'irwan'),
(4, 'BRG-2021-000000004', 'Minyak Sayur Grandco 2ltr', 3, 2, 2021, 45, 'SUPL20210206002', 'irwan'),
(5, 'BRG-2021-000000005', 'Minyak Sayur Grandco 1ltr', 4, 2, 2021, 50, 'SUPL20210206002', 'irwan'),
(6, 'BRG-2021-000000006', 'Mie Sedaap ayam goreng', 5, 2, 2021, 150, 'SUPL20210206003', 'irwan'),
(7, 'BRG-2021-000000007', 'HIT MAT elektrik', 16, 2, 2021, 1, 'SUPL20210206002', 'admin'),
(8, 'BRG-2021-000000007', 'HIT MAT elektrik', 16, 2, 2021, 99, 'SUPL20210206002', 'admin'),
(14, 'BRG-2021-0000000015', 'VAPE', 10, 8, 2021, 1, 'SUPL20210810005', 'admin'),
(10, 'BRG-2021-000000009', 'ale ale jeruk', 21, 6, 2021, 100, 'SUPL20210206002', 'admin'),
(11, 'BRG-2021-000000009', 'ale ale jeruk', 21, 6, 2021, 100, 'SUPL20210206002', 'admin'),
(12, 'BRG-2021-000000010', 'Air Mineral Citra 220', 21, 6, 2021, 120, 'SUPL20210206003', 'admin'),
(13, 'BRG-2021-000000010', 'Air Mineral Citra 220', 21, 6, 2021, 100, 'SUPL20210206003', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `barcodebarang`
--

DROP TABLE IF EXISTS `barcodebarang`;
CREATE TABLE IF NOT EXISTS `barcodebarang` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kode_barang` varchar(25) NOT NULL,
  `barcode` varchar(200) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `barcode` (`barcode`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `barcodebarang`
--

INSERT INTO `barcodebarang` (`id`, `kode_barang`, `barcode`) VALUES
(1, 'BRG-2021-000000001', '1234567890'),
(2, 'BRG-2021-000000002', '1234567891'),
(3, 'BRG-2021-000000003', '1234567892'),
(4, 'BRG-2021-000000004', '1234567893'),
(5, 'BRG-2021-000000005', '1234567895'),
(6, 'BRG-2021-000000006', '123456789098'),
(7, 'BRG-2021-000000007', '8992745140573'),
(11, 'BRG-2021-0000000015', '12345678919'),
(9, 'BRG-2021-000000009', '8998866500319'),
(10, 'BRG-2021-000000010', '8993092220963');

-- --------------------------------------------------------

--
-- Table structure for table `detail_transaksi`
--

DROP TABLE IF EXISTS `detail_transaksi`;
CREATE TABLE IF NOT EXISTS `detail_transaksi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kode_transaksi` varchar(25) NOT NULL,
  `qty` int(11) NOT NULL,
  `kode_barang` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=31 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `detail_transaksi`
--

INSERT INTO `detail_transaksi` (`id`, `kode_transaksi`, `qty`, `kode_barang`) VALUES
(1, 'TR-2021-000000001', 1, 'BRG-2021-000000001'),
(2, 'TR-2021-000000001', 1, 'BRG-2021-000000002'),
(3, 'TR-2021-000000002', 1, 'BRG-2021-000000001'),
(4, 'TR-2021-000000003', 2, 'BRG-2021-000000002'),
(5, 'TR-2021-000000004', 1, 'BRG-2021-000000003'),
(6, 'TR-2021-000000004', 1, 'BRG-2021-000000004'),
(7, 'TR-2021-000000004', 1, 'BRG-2021-000000006'),
(8, 'TR-2021-000000005', 2, 'BRG-2021-000000001'),
(9, 'TR-2021-000000005', 2, 'BRG-2021-000000005'),
(10, 'TR-2021-000000005', 2, 'BRG-2021-000000006'),
(11, 'TR-2021-000000006', 2, 'BRG-2021-000000007'),
(12, 'TR-2021-000000007', 1, 'BRG-2021-000000007'),
(13, 'TR-2021-000000008', 1, 'BRG-2021-000000007'),
(14, 'TR-2021-000000009', 1, 'BRG-2021-000000008'),
(15, 'TR-2021-000000009', 1, 'BRG-2021-000000002'),
(16, 'TR-2021-000000010', 1, 'BRG-2021-000000006'),
(17, 'TR-2021-000000011', 1, 'BRG-2021-000000006'),
(18, 'TR-2021-000000012', 1, 'BRG-2021-000000005'),
(19, 'TR-2021-000000013', 1, 'BRG-2021-000000005'),
(20, 'TR-2021-000000014', 1, 'BRG-2021-000000004'),
(21, 'TR-2021-000000015', 1, 'BRG-2021-000000006'),
(22, 'TR-2021-000000016', 1, 'BRG-2021-000000002'),
(23, 'TR-2021-000000017', 1, 'BRG-2021-000000006'),
(24, 'TR-2021-000000018', 1, 'BRG-2021-000000003'),
(25, 'TR-2021-000000019', 1, 'BRG-2021-000000003'),
(26, 'TR-2021-000000020', 1, 'BRG-2021-000000002'),
(27, 'TR-2021-000000021', 1, 'BRG-2021-000000003'),
(28, 'TR-2021-000000022', 2, 'BRG-2021-000000009'),
(29, 'TR-2021-000000023', 10, 'BRG-2021-000000010'),
(30, 'TR-2021-000000024', 15, 'BRG-2021-000000010');

-- --------------------------------------------------------

--
-- Table structure for table `kategori_barang`
--

DROP TABLE IF EXISTS `kategori_barang`;
CREATE TABLE IF NOT EXISTS `kategori_barang` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `kategori` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `kategori` (`kategori`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kategori_barang`
--

INSERT INTO `kategori_barang` (`id`, `kategori`) VALUES
(1, 'Sembako'),
(2, 'Makanan'),
(3, 'Obat nyamuk'),
(4, 'hdd'),
(5, 'minuman'),
(6, 'Elektronik');

-- --------------------------------------------------------

--
-- Stand-in structure for view `laporan_barang`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `laporan_barang`;
CREATE TABLE IF NOT EXISTS `laporan_barang` (
`kode` varchar(25)
,`nama` varchar(200)
,`kategori` varchar(100)
,`satuan` varchar(100)
,`harga` float
,`kadaluarsa` varchar(15)
,`stok` int(11)
,`jumlah` double
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `laporan_barang_masuk`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `laporan_barang_masuk`;
CREATE TABLE IF NOT EXISTS `laporan_barang_masuk` (
`kode_barang` varchar(25)
,`nama_barang` varchar(100)
,`tanggal` varchar(35)
,`qty` int(11)
,`kode_suplier` varchar(25)
,`nama_suplier` varchar(100)
,`karyawan` varchar(50)
);

-- --------------------------------------------------------

--
-- Table structure for table `satuanbarang`
--

DROP TABLE IF EXISTS `satuanbarang`;
CREATE TABLE IF NOT EXISTS `satuanbarang` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `satuan` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `satuan` (`satuan`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `satuanbarang`
--

INSERT INTO `satuanbarang` (`id`, `satuan`) VALUES
(1, 'Karung'),
(2, 'Liter'),
(3, 'Pcs'),
(4, 'Bungkus');

-- --------------------------------------------------------

--
-- Stand-in structure for view `struk_view`
-- (See below for the actual view)
--
DROP VIEW IF EXISTS `struk_view`;
CREATE TABLE IF NOT EXISTS `struk_view` (
`kode_transaksi` varchar(25)
,`timestamps` varchar(100)
,`nama_barang` varchar(200)
,`qty` int(11)
,`harga_beli` float
,`harga` float
,`subtotal` double
,`total` float
,`bayar` float
,`discount` float
,`kembali` float
,`kasir` varchar(25)
,`nama_kasir` varchar(50)
);

-- --------------------------------------------------------

--
-- Table structure for table `suplier`
--

DROP TABLE IF EXISTS `suplier`;
CREATE TABLE IF NOT EXISTS `suplier` (
  `kode` varchar(25) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `kota` varchar(25) NOT NULL,
  `telp` varchar(20) DEFAULT NULL,
  `alamat` text,
  `keterangan` text,
  PRIMARY KEY (`kode`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `suplier`
--

INSERT INTO `suplier` (`kode`, `nama`, `kota`, `telp`, `alamat`, `keterangan`) VALUES
('SUPL20210206001', 'Pt. Beras', 'Jambi', '09090909', 'jambi', 'suplier beras'),
('SUPL20210206002', 'PT.Grandco', 'Sumatera Barat', '0909090', 'Sumatera Barat', 'GRANDCO'),
('SUPL20210206003', 'PT. Wingsfood', 'Jakarta Pusat', '90909090', 'Jakarta Pusat', 'Jakarta Pusat'),
('SUPL20210810005', 'Fumakilla', 'Jambi', '085324679973', 'Jambi', 'Supplier');

-- --------------------------------------------------------

--
-- Table structure for table `transaksi`
--

DROP TABLE IF EXISTS `transaksi`;
CREATE TABLE IF NOT EXISTS `transaksi` (
  `kode` varchar(25) NOT NULL,
  `timestamps` varchar(100) NOT NULL,
  `total` float NOT NULL,
  `bayar` float NOT NULL,
  `discount` float NOT NULL DEFAULT '0',
  `kembali` float NOT NULL DEFAULT '0',
  `kasir` varchar(25) NOT NULL,
  PRIMARY KEY (`kode`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaksi`
--

INSERT INTO `transaksi` (`kode`, `timestamps`, `total`, `bayar`, `discount`, `kembali`, `kasir`) VALUES
('TR-2021-000000001', '1612088618602', 313500, 350000, 0, 36500, 'kasir'),
('TR-2021-000000002', '1612088618603', 104500, 105000, 0, 500, 'kasir'),
('TR-2021-000000003', '1612175119734', 209000, 210000, 0, 1000, 'kasir'),
('TR-2021-000000004', '1612520813866', 133500, 135000, 0, 1500, 'irwan'),
('TR-2021-000000005', '1612520845813', 241000, 250000, 0, 9000, 'irwan'),
('TR-2021-000000006', '1613483394632', 16000, 20000, 0, 4000, 'admin'),
('TR-2021-000000007', '1613487017208', 8000, 8000, 0, 0, 'admin'),
('TR-2021-000000008', '1613487381530', 8000, 10000, 0, 2000, 'admin'),
('TR-2021-000000009', '1623172906934', 604500, 605000, 0, 500, 'admin'),
('TR-2021-000000010', '1624011104829', 2500, 2500, 0, 0, 'admin'),
('TR-2021-000000011', '1624012498039', 2500, 2500, 0, 0, 'admin'),
('TR-2021-000000012', '1624012618681', 13500, 13500, 0, 0, 'admin'),
('TR-2021-000000013', '1624012686532', 13500, 13500, 0, 0, 'admin'),
('TR-2021-000000014', '1624012881608', 25500, 25500, 0, 0, 'admin'),
('TR-2021-000000015', '1624013025111', 2500, 5000, 0, 2500, 'admin'),
('TR-2021-000000016', '1624013499423', 104500, 105000, 0, 500, 'admin'),
('TR-2021-000000017', '1624013648730', 2500, 2500, 0, 0, 'admin'),
('TR-2021-000000018', '1624013701575', 105500, 105500, 0, 0, 'admin'),
('TR-2021-000000019', '1624013758512', 105500, 105500, 0, 0, 'admin'),
('TR-2021-000000020', '1624013814027', 104500, 105000, 0, 500, 'admin'),
('TR-2021-000000021', '1624013866017', 105500, 106000, 0, 500, 'admin'),
('TR-2021-000000022', '1624290827229', 3000, 5000, 0, 2000, 'admin'),
('TR-2021-000000023', '1624291820693', 7500, 20000, 2500, 12500, 'admin'),
('TR-2021-000000024', '1624293705626', 11500, 35000, 3500, 23500, 'kasir');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `username` varchar(25) NOT NULL,
  `password` varchar(100) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `id` varchar(25) NOT NULL,
  `level` enum('kasir','admin','owner') NOT NULL,
  PRIMARY KEY (`username`),
  UNIQUE KEY `id` (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`username`, `password`, `nama`, `id`, `level`) VALUES
('kasir', 'c7911af3adbd12a035b289556d96470a', 'Nana', '1501999999999', 'kasir'),
('admin', '21232f297a57a5a743894a0e4a801fc3', 'admin', 'admin', 'admin'),
('owner', '72122ce96bfec66e2396d2e25225d70a', 'owner', 'owner', 'owner'),
('irwan', 'b360089e48b62d69c6c80fa1b5ef024d', 'Irwansyah', '1509029390192', 'admin');

-- --------------------------------------------------------

--
-- Structure for view `laporan_barang`
--
DROP TABLE IF EXISTS `laporan_barang`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `laporan_barang`  AS  select `a`.`kode` AS `kode`,`a`.`nama` AS `nama`,`b`.`kategori` AS `kategori`,`c`.`satuan` AS `satuan`,`a`.`harga` AS `harga`,`a`.`kadaluarsa` AS `kadaluarsa`,`a`.`stok` AS `stok`,(`a`.`harga` * `a`.`stok`) AS `jumlah` from ((`barang` `a` left join `kategori_barang` `b` on((`a`.`kategori` = `b`.`id`))) left join `satuanbarang` `c` on((`a`.`satuan` = `c`.`id`))) ;

-- --------------------------------------------------------

--
-- Structure for view `laporan_barang_masuk`
--
DROP TABLE IF EXISTS `laporan_barang_masuk`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `laporan_barang_masuk`  AS  select `a`.`kode_barang` AS `kode_barang`,`a`.`nama_barang` AS `nama_barang`,concat(`a`.`tanggal`,'-',`a`.`bulan`,'-',`a`.`tahun`) AS `tanggal`,`a`.`qty` AS `qty`,`a`.`kode_suplier` AS `kode_suplier`,`b`.`nama` AS `nama_suplier`,`c`.`nama` AS `karyawan` from ((`barang_masuk` `a` left join `suplier` `b` on((`a`.`kode_suplier` = `b`.`kode`))) left join `users` `c` on((`a`.`users` = `c`.`username`))) ;

-- --------------------------------------------------------

--
-- Structure for view `struk_view`
--
DROP TABLE IF EXISTS `struk_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `struk_view`  AS  (select `a`.`kode` AS `kode_transaksi`,`a`.`timestamps` AS `timestamps`,`c`.`nama` AS `nama_barang`,`b`.`qty` AS `qty`,`c`.`harga_beli` AS `harga_beli`,`c`.`harga` AS `harga`,(`b`.`qty` * `c`.`harga`) AS `subtotal`,`a`.`total` AS `total`,`a`.`bayar` AS `bayar`,`a`.`discount` AS `discount`,`a`.`kembali` AS `kembali`,`a`.`kasir` AS `kasir`,`d`.`nama` AS `nama_kasir` from (((`transaksi` `a` join `detail_transaksi` `b` on((`a`.`kode` = `b`.`kode_transaksi`))) join `barang` `c` on((`b`.`kode_barang` = `c`.`kode`))) left join `users` `d` on((`a`.`kasir` = `d`.`username`)))) ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
