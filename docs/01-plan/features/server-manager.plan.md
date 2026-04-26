# Plan: FarmOS Server Manager

## Executive Summary

| Item | Detail |
|------|--------|
| Feature | server-manager |
| Created | 2026-04-24 |
| Level | Dynamic |

### Value Delivered

| Perspective | Description |
|-------------|-------------|
| Problem | FarmOS 개발자가 FastAPI + React 서버를 수동으로 실행하고, DB 상태를 매번 확인해야 하는 번거로움 |
| Solution | WinForms 앱에서 원클릭 서버 구동 + 자동 DB 검증/초기화 + 실시간 로그 뷰어 |
| Function UX Effect | 버튼 하나로 DB 검증 → 서버 시작 → 상태 표시 → 로그 확인까지 일관된 워크플로우 |
| Core Value | 개발 환경 셋업 시간 절약, DB 상태 불일치로 인한 오류 예방 |

---

## 1. Feature Overview

FarmOS WinForms 런처에서 서버 구동 버튼 클릭 시:
1. PostgreSQL DB 상태 검증 (존재 여부 → 테이블 여부 → 데이터 충분성)
2. FastAPI 백엔드 + React(Vite) 프론트엔드 프로세스 실행
3. 성공/실패 상태를 색상으로 표시
4. 로그 뷰어 폼에서 Backend/Frontend 로그 실시간 확인

## 2. Requirements

### 2.1 서버 구동 (Server Start)
- "서버 구동" 버튼 클릭 시 FastAPI + React 프로세스 실행
- 실행 전 PostgreSQL DB 상태 자동 검증
- 프로세스 PID 추적 및 관리

### 2.2 DB 검증 분기
- **DB 미존재**: alert 메시지로 DB 생성 안내
- **DB 존재 + 테이블 미존재**: SQLAlchemy(Python 호출)로 테이블 자동 생성
- **DB + 테이블 존재 + 데이터 부족**: SQL 실행하여 데이터 시딩
- **데이터 충분**: pass

### 2.3 상태 표시
- 성공: textBox에 "서버 가동 성공!" (초록색)
- 실패: textBox에 "서버 구동 실패!" (빨간색)

### 2.4 로그 뷰어
- 서버 구동 성공 시: 새 Form에서 Backend/Frontend 로그 표시
- 서버 구동 실패 시: alert "서버를 실행하여주세요!"
- 각 프로세스 PID 표시

## 3. Architecture

```
Form1 (Main)
  ├── Server_Starting Button → ServerManager.StartAll()
  │     └── DatabaseChecker.CheckAndPrepare()
  │           ├── DB 미존재 → Alert
  │           ├── 테이블 미존재 → Python SQLAlchemy 호출
  │           └── 데이터 부족 → SQL Seed 실행
  ├── Log_View Button → LogForm (new Form)
  │     ├── Backend Tab (FastAPI log + PID)
  │     └── Frontend Tab (React log + PID)
  └── textBox1 → 상태 표시 (Green/Red)
```

## 4. Implementation Files

| File | Role |
|------|------|
| `DatabaseChecker.cs` | PostgreSQL DB 검증 및 준비 |
| `ServerManager.cs` | 프로세스 시작/중지/PID 관리 |
| `LogForm.cs` | 로그 뷰어 폼 (Backend/Frontend 탭) |
| `LogForm.Designer.cs` | 로그 뷰어 UI 디자인 |
| `Form1.cs` | 메인 폼 이벤트 핸들러 통합 |
| `Form1.Designer.cs` | 메인 폼 UI 업데이트 |
| `App.config` | PostgreSQL 연결 문자열 |
| `packages.config` | Npgsql NuGet 패키지 |

## 5. Dependencies

- **Npgsql 4.1.13**: .NET Framework 4.7.2 호환 PostgreSQL 드라이버
- **PostgreSQL**: 로컬 설치 필요
- **Python + uv**: FastAPI 백엔드 실행용
- **Node.js + npm**: React 프론트엔드 실행용
