# [OJT Project]_Image_Viewer(이미지_뷰어) 프로젝트


## 1. 사용 언어, [UI], 사용 기술
### 1) 사용 언어: C#
### 2) 사용 개발 프레임워크(UI): Wpf
### 3) 사용 기술: MVVM 아키텍처(디자인) 패턴




## 2. [OJT_1_ImageViewer]_프로젝트
### 1) [Common]_Folder
   <1> ParameterRelayCommand.cs 파일
   - ICommand를 상속 받아 UI에서 이벤트 받아 처리하는 함수 구현 2
     
   <2> RelayCommand.cs 파일
   - ICommand를 상속 받아 UI에서 이벤트 받아 처리하는 함수 구현 1


### 2) [Models]_Folder
   <1> ImageFS.cs 파일 (이미지 Property)
   * 파일 경로
   * 파일 이름
   * 생성 일자
   * 파일 크기

   
### 3) [ViewModels]_Folder
   <1> MainVM.cs 파일
   - [Model] 및 [ViewModel] 통합
   - [Model]: 프로퍼티(데이터 처리 및 저장)
   - [ViewModel]: [View]에서 들어온 데이터 가공 및 [Model]과 통신 후, 데이터 바인딩으로 [View] 갱신
   - [Main] 기능 및 함수 구현
   * [ICommand] - Data Binding
   * [MainVM] 생성자 MainVM() (Initialize)

     
### 4) [Views]_Folder
   <1> MainWindow.xaml 파일
   - [View]: 메인 [App]의 [Wpf] 및 [View] 담당
   - [Wpf]: [이미지 뷰어] 화면




## 3. 텍스트 블럭 및 버튼
#### [1] [폴더 경로]_텍스트 블럭

#### [2] [폴더 불러오기]_버튼

#### [3] [이미지 복원]_버튼

#### [4] [파일 초기화]_버튼

#### [5] [확대]_버튼

#### [6] [축소]_버튼

#### [7] [왼쪽 15°]_버튼

#### [8] [오른쪽 15°]_버튼

#### [9] [좌우 반전]_버튼




## 4. 함수 기능
### 1) 함수 기능
   <1> [폴더 불러오기] 기능
   - [함수] OpenFolder()
   - [CommonOpenFileDialog] 클래스를 이용하여, [폴더 경로]를 불러온다.
     
   <2> [이미지 복원] 기능
   - [함수] RestoreImage()
   - [폴더 경로]에 있는 [이미지]를 원상태로 돌려놓는다.
     
   <3> [파일 초기화] 기능
   - [함수] ResetFile()
   - [폴더 경로]를 NULL로 초기화한다.
   
   <4> [확대] 기능
   - [함수] ZoomInFile()
   - [이미지]를 [1.1]배 확대한다.
   
   <5> [축소] 기능
   - [함수] ZoomOutFile()
   - [이미지]를 [1.1]배 축소한다.

   <6> [왼쪽 15°] 기능
   - [함수] RotateLeftFile()
   - [이미지]를 왼쪽으로 15° 돌린다.
   
   <7> [오른쪽 15°] 기능
   - [함수] RotateRightFile()
   - [이미지]를 오른쪽으로 15° 돌린다.
   
   <8> [좌우 반전] 기능
   - [함수] RotateInversion()
   - [이미지]를 좌우 180° 반전 시킨다.




## 5. [App] 실행 시, 초기 화면
<img width="891" alt="이미지 뷰어 초기 화면" src="https://github.com/Haseung-Song/OJT_1_ImageViewer/assets/63398933/22162013-7c80-43c7-a712-279260156c45">




## 6. [App] 실행 시, 기능 녹화




