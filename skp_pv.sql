-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 12, 2025 at 03:12 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `skp_pv`
--

-- --------------------------------------------------------

--
-- Table structure for table `dosen`
--

CREATE TABLE `dosen` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `nip` varchar(50) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `prodi` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telp` varchar(20) DEFAULT NULL,
  `periode` varchar(25) NOT NULL,
  `foto_key` varchar(64) DEFAULT NULL,
  `foto_url` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dosen`
--

INSERT INTO `dosen` (`id`, `user_id`, `nip`, `nama`, `prodi`, `email`, `telp`, `periode`, `foto_key`, `foto_url`) VALUES
(1, 1, '123', 'azzam', 'TI', 'azzam@gmail.com', '08241638351261', '2024/2025 - Ganjil', 'dc7a526a4375490599dfda8623aa3fe4', 'http://localhost/foto_dosen/dc7a526a4375490599dfda8623aa3fe4.jpg'),
(3, 3, '2029301931', 'Kanisa Nashwan', 'TMJ', 'kanisa@gmail.com', '081342617888', '2024/2025 - Ganjil', NULL, NULL),
(4, 2, '213121232', 'nashwan1', 'TMJ', 'email@gmail.com', '081342617888', '2024/2025 - Ganjil', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `ms_pertanyaan`
--

CREATE TABLE `ms_pertanyaan` (
  `id` int(11) NOT NULL,
  `aspek` varchar(100) DEFAULT NULL,
  `pertanyaan` text DEFAULT NULL,
  `target_role` varchar(50) DEFAULT NULL,
  `tipe_input` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `ms_pertanyaan`
--

INSERT INTO `ms_pertanyaan` (`id`, `aspek`, `pertanyaan`, `target_role`, `tipe_input`) VALUES
(1, 'Orientasi Pelayanan', 'Seberapa baik Dosen memahami dan memenuhi kebutuhan mahasiswa/rekan kerja?', 'Admin', 'Skala'),
(2, 'Orientasi Pelayanan', 'Apakah Dosen bersikap ramah, cekatan, dan solutif dalam memberikan pelayanan?', 'Dosen', 'Skala'),
(3, 'Orientasi Pelayanan', 'Apakah Dosen terus melakukan perbaikan tiada henti terhadap kualitas kerjanya?', 'Admin', 'Skala'),
(4, 'Akuntabel', 'Apakah Dosen melaksanakan tugas dengan jujur, cermat, dan berintegritas tinggi?', 'Admin', 'Skala'),
(5, 'Akuntabel', 'Apakah Dosen menggunakan fasilitas kampus secara bertanggung jawab, efektif, dan efisien?', 'Admin', 'Persen'),
(6, 'Akuntabel', 'Apakah Dosen dipastikan tidak menyalahgunakan kewenangan jabatannya?', 'Admin', 'Skala'),
(7, 'Kompeten', 'Seberapa aktif Dosen meningkatkan kompetensi diri untuk menjawab tantangan yang selalu berubah?', 'Dosen', 'Skala'),
(8, 'Kompeten', 'Apakah Dosen bersedia membantu orang lain belajar?', 'Dosen', 'Skala'),
(9, 'Kompeten', 'Apakah Dosen melaksanakan tugas dengan kualitas terbaik?', 'Dosen', 'Skala'),
(10, 'Loyal', 'Seberapa setia Dosen memegang teguh ideologi Pancasila dan peraturan perundang-undangan?', 'Admin', 'YaTidak'),
(11, 'Loyal', 'Apakah Dosen menjaga nama baik sesama rekan kerja, pimpinan, instansi, dan negara?', 'Admin', 'YaTidak'),
(12, 'Loyal', 'Apakah Dosen mampu menjaga rahasia jabatan dan rahasia negara?', 'Admin', 'YaTidak'),
(13, 'Harmonis', 'Apakah Dosen menghargai setiap orang apapun latar belakangnya?', 'Admin', 'Skala'),
(14, 'Harmonis', 'Seberapa sering Dosen terlihat suka menolong orang lain?', 'Admin', 'Skala'),
(15, 'Harmonis', 'Apakah Dosen turut membangun lingkungan kerja yang kondusif?', 'Admin', 'Skala'),
(16, 'Adaptif', 'Seberapa cepat Dosen menyesuaikan diri menghadapi perubahan?', 'Dosen', 'Skala'),
(17, 'Adaptif', 'Apakah Dosen terus berinovasi dan mengembangkan kreativitas?', 'Dosen', 'Skala'),
(18, 'Adaptif', 'Apakah Dosen selalu bertindak proaktif?', 'Dosen', 'Skala'),
(19, 'Kolaboratif', 'Apakah Dosen memberi kesempatan kepada berbagai pihak untuk berkontribusi?', 'KPS', 'Skala'),
(20, 'Kolaboratif', 'Seberapa terbuka Dosen dalam bekerja sama untuk menghasilkan nilai tambah?', 'Admin', 'Persen'),
(21, 'Kolaboratif', 'Apakah Dosen mampu menggerakkan pemanfaatan berbagai sumberdaya untuk tujuan bersama?', 'Admin', 'Skala');

-- --------------------------------------------------------

--
-- Table structure for table `tr_penilaian`
--

CREATE TABLE `tr_penilaian` (
  `id` int(11) NOT NULL,
  `id_pertanyaan` int(11) NOT NULL,
  `username_penilai` varchar(100) DEFAULT NULL,
  `target_dosen_nip` varchar(50) DEFAULT NULL,
  `periode` varchar(50) DEFAULT NULL,
  `nilai_skor` varchar(50) DEFAULT NULL,
  `catatan` text DEFAULT NULL,
  `bukti_pendukung` varchar(255) DEFAULT NULL,
  `nilai_penilai` varchar(20) DEFAULT NULL,
  `status_verifikasi` varchar(20) DEFAULT NULL,
  `catatan_verifikasi` text DEFAULT NULL,
  `verifikator` varchar(50) DEFAULT NULL,
  `is_final` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tr_penilaian`
--

INSERT INTO `tr_penilaian` (`id`, `id_pertanyaan`, `username_penilai`, `target_dosen_nip`, `periode`, `nilai_skor`, `catatan`, `bukti_pendukung`, `nilai_penilai`, `status_verifikasi`, `catatan_verifikasi`, `verifikator`, `is_final`) VALUES
(1, 2, 'nashwan', 'nashwan', '2024/2025 Ganjil', '5', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(2, 7, 'nashwan', 'nashwan', '2024/2025 Ganjil', '9', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(3, 8, 'nashwan', 'nashwan', '2024/2025 Ganjil', '7', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(4, 9, 'nashwan', 'nashwan', '2024/2025 Ganjil', '8', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(5, 16, 'nashwan', 'nashwan', '2024/2025 Ganjil', '10', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(6, 17, 'nashwan', 'nashwan', '2024/2025 Ganjil', '8', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(7, 18, 'nashwan', 'nashwan', '2024/2025 Ganjil', '9', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(8, 2, 'nashwan', '123', '2024/2025 Ganjil', '6', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(9, 7, 'nashwan', '123', '2024/2025 Ganjil', '8', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(10, 8, 'nashwan', '123', '2024/2025 Ganjil', '8', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(11, 9, 'nashwan', '123', '2024/2025 Ganjil', '9', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(12, 16, 'nashwan', '123', '2024/2025 Ganjil', '4', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(13, 17, 'nashwan', '123', '2024/2025 Ganjil', '10', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(14, 18, 'nashwan', '123', '2024/2025 Ganjil', '10', NULL, NULL, NULL, NULL, NULL, NULL, 0),
(15, 2, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '8', 'ada', NULL, NULL, NULL, NULL, NULL, 0),
(16, 7, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '9', 'ada', NULL, NULL, NULL, NULL, NULL, 0),
(17, 8, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '8', 'ada', NULL, NULL, NULL, NULL, NULL, 0),
(18, 9, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '8', 'ada', NULL, NULL, NULL, NULL, NULL, 0),
(19, 16, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '9', 'ada', NULL, NULL, NULL, NULL, NULL, 0),
(20, 17, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '10', 'ada', NULL, NULL, NULL, NULL, NULL, 0),
(21, 18, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '7', 'ada', NULL, NULL, NULL, NULL, NULL, 0),
(22, 2, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '9', 'ada', '', NULL, NULL, NULL, NULL, 0),
(23, 7, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '8', 'ada', '', NULL, NULL, NULL, NULL, 0),
(24, 8, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '9', 'ada', '', NULL, NULL, NULL, NULL, 0),
(25, 9, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '9', 'ada', '', NULL, NULL, NULL, NULL, 0),
(26, 16, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '8', 'ada', '', NULL, NULL, NULL, NULL, 0),
(27, 17, 'nashwan', 'nashwan', '2024/2025 - Ganjil', '8', 'ada', '', NULL, NULL, NULL, NULL, 0),
(28, 18, 'nashwan', 'nashwan', '2024/2025 - Ganjil', 'Mengusulkan proposal', 'ada', '', NULL, NULL, NULL, NULL, 0);

-- --------------------------------------------------------

--
-- Table structure for table `tr_status_penilaian`
--

CREATE TABLE `tr_status_penilaian` (
  `id` int(11) NOT NULL,
  `nip` varchar(50) DEFAULT NULL,
  `periode` varchar(50) DEFAULT NULL,
  `status_dosen` int(11) DEFAULT 0,
  `status_admin` int(11) DEFAULT 0,
  `status_kps` int(11) DEFAULT 0,
  `nilai_akhir` double DEFAULT 0,
  `predikat` varchar(50) DEFAULT '-'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `role`) VALUES
(1, '123', 'Alazhar1', 'Dosen'),
(2, 'hilmy', '1', 'Dosen'),
(3, 'nashwan', '12345678', 'Dosen'),
(111, 'Admin', 'admin123', 'Admin'),
(222, 'KPS', 'kps12345', 'KPS'),
(223, 'kajur', 'kajur123', 'Kepala Jurusan');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dosen`
--
ALTER TABLE `dosen`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nip` (`nip`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `ms_pertanyaan`
--
ALTER TABLE `ms_pertanyaan`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tr_penilaian`
--
ALTER TABLE `tr_penilaian`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tr_status_penilaian`
--
ALTER TABLE `tr_status_penilaian`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unik_data` (`nip`,`periode`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dosen`
--
ALTER TABLE `dosen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `ms_pertanyaan`
--
ALTER TABLE `ms_pertanyaan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `tr_penilaian`
--
ALTER TABLE `tr_penilaian`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `tr_status_penilaian`
--
ALTER TABLE `tr_status_penilaian`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=224;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `dosen`
--
ALTER TABLE `dosen`
  ADD CONSTRAINT `dosen_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
