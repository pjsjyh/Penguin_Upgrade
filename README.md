# penguinAdventure

![image](https://github.com/user-attachments/assets/14ddfb14-d53d-4d7a-92b9-c12c36cbb9e6)

# 📄프로젝트 정보
#### 장르
로그라이크 디펜스 게임 - 빙하를 지키기 위한 펭귄의 모험!

#### 참여인원
개발자 2인, 디자이너 1인

#### 실행 영상
https://www.youtube.com/watch?v=uT2ozmiKW2Y

#### 실행 링크
https://penguin-build.vercel.app/

#### 역할 분담
본인 : 
- 로비씬 제작
- 게임 시스템 구축(캐릭터 데이터 관리, 몬스터 정보 셋팅)
- 캐릭터 플레이 기능
- 랭킹 시스템
- 메모리 관리 최적화


# 📝사용기술
1) 디자인 패턴을 활용한 관리
   - 싱글톤 패턴을 활용한 플레이어 데이터 관리
     - 플레이어가 한명인것을 활용해 싱글톤 패턴을 활용해 데이터 관리. [플레이어 스크립트](https://github.com/pjsjyh/Penguin_Upgrade/blob/main/PenguinAdventure/Assets/Script/Player/PlayerManager.cs)
     - 직접 접근을 제한해 캐릭터 정보 안전한 처리. [플레이어 Damage처리](https://github.com/pjsjyh/Penguin_Upgrade/blob/main/PenguinAdventure/Assets/Script/Player/playerBlood.cs)
2) JSON을 이용한 데이터 관리
   -  라운드 정보(몬스터 종류, 마리수, 라운드 타입)를 json으로 저장하고 호출해 셋팅. [json저장](https://github.com/pjsjyh/Penguin_Upgrade/blob/main/PenguinAdventure/Assets/Resources/Round.txt) [라운드 json셋팅](https://github.com/pjsjyh/Penguin_Upgrade/blob/main/PenguinAdventure/Assets/Script/GameManager.cs)
   -  사용자의 패시브 종류를 json으로 저장해 확장하기 쉽도록 설계. [패시브 저장](https://github.com/pjsjyh/Penguin_Upgrade/blob/main/PenguinAdventure/Assets/Resources/PassiveInfo.txt)
3) 메모리 관리 최적화
   - 오브젝트 풀링을 활용한 몬스터 생성 및 재활용. [몬스터 생성](https://github.com/pjsjyh/Penguin_Upgrade/blob/main/PenguinAdventure/Assets/Script/Monster/MonsterPoolManager.cs)
   - Addressables를 활용한 메모리 절감.
   - 같이 업데이트 되는 UI요소를 Canvas 단위로 분리하여 불필요한 리렌더링 줄이기.
4) 플레이어 관리
   - namespace와 싱글톤을 이용해 플레이어 관리.
   - 캐릭터 이동을 플랫폼 별로 처리 및 벡터 기반.
5) 랭킹 시스템
   - Firebase를 활용해 유니티 WebGL에서 랭킹 시스템 구현. [랭킹 시스템](https://github.com/pjsjyh/Penguin_Upgrade/blob/main/PenguinAdventure/Assets/Script/Lanking/Ranking.cs)
6) 게임 시스템
   - 씬 변환, 배경 음악, 몬스터 셋팅, 궁극기 정보 셋팅 등 제작.

# 구현 기능
#### 1) 닉네임 입력
####   ![image](https://github.com/user-attachments/assets/5f511232-12fc-4d40-82ab-e8b3a37cf49a)
   닉네임을 입력 후 게임 시작 가능하게 구현. 추후 랭킹 시스템을 위한 닉네임 생성. 오락실과 같이 간단하게 즐기는 것이 목표로 로그인 시스템이 아닌 닉네임 입력만 하도록 제작.
#### 2) 로비
#### ![image](https://github.com/user-attachments/assets/17be5733-068a-4cbd-97f0-c6a6aca5a81d)
   로비에서 개인의 능력치와 궁극기 셋팅이 가능하다. 또한 좌측상단을 통해 랭킹의 현황을 볼 수 있다.
#### 3) 궁극기
#### ![image](https://github.com/user-attachments/assets/33bc14d6-7af6-4da1-ba46-4ce056239d3d)
   저장되어 있는 궁극기 리스트json을 불러와 자동으로 셋팅. 게임 진행에 따라 Level상승과 새로운 궁극기가 생긴다.
   게임 당 하나의 궁극기를 장착하고 진행할 수 있다.
#### 4) 랭킹 시스템
#### ![image](https://github.com/user-attachments/assets/52962ca5-8136-4fb6-b873-c068afd20629)
   현재 랭킹 현황을 볼 수 있다. Firebase에 저장되어 있는 점수 중 Top10의 점수만 볼 수 있다.
#### 5) 게임 시스템
####   - 몬스터 생성
####   ![image](https://github.com/user-attachments/assets/b952a585-31df-4b7e-9343-6ffaf6cbe208)
      - 몬스터들은 캐릭터 기준으로 원 모양틀에서 랜덤 생성된다. 항상 몬스터를 향해 다가온다.
      - 오브젝트 풀링으로 생성되어 사망할 경우 active가 false된다.
#### ![image](https://github.com/user-attachments/assets/4a0ec137-b7bd-4ce3-abf8-c407f7921378)
      - 보스몬스터의 경우 캐릭터를 공격할 수 있는 스킬이 있다.
####   - 캐릭터 공격
####   ![image](https://github.com/user-attachments/assets/8261cff9-c164-472b-8eac-9bca1cba3300)
      - 기본적으로 물방울을 쏜다. 모든 스킬은 자동공격으로 진행되며 보석을 모아 새로운 스킬 구매 혹은 레벨업이 가능하다.
      - 바닥에 떨어져 있는 파란색이 보석으로 해당 보석을 모아 우측 상단의 점수를 다 채우면 스킬을 구매 혹은 레벨업을 할 수 있다.
#### - 캐릭터 스킬
#### ![image](https://github.com/user-attachments/assets/1ddcec26-f1cb-45a3-a7b9-d14025e6fced)
      - 자동으로 스킬 창이 뜨며 선택하면 게임이 마저 진행된다.
      - 개인이 가질 수 있는 스킬은 총 5개로 5개가 다 선택되면 그 후는 레벨업만 진행할 수 있다.
#### ![image](https://github.com/user-attachments/assets/eec5267e-1b59-45d3-8685-c7ea74c6d8dc)
      - 장착되어 있는 스킬은 자동으로 공격된다.
#### ![image](https://github.com/user-attachments/assets/eca0659a-9e3b-4769-a2d4-cc22476bf03f)
      - 궁극기는 장착되어있는 것을 버튼으로 사용이 가능하다.
      - 각 궁극기에는 재사용시간이 있다.
#### 6) 게임 오버
#### ![image](https://github.com/user-attachments/assets/e53aab25-b79d-4421-b9de-1904c177baca)
   HP가 0이 되면 게임은 자동 종료가 된다. 점수는 자동으로 서버에 등록되며 랭킹에 들어가면 랭킹화면에서 확인 할 수 있다.
   게임이 종료되면서 자동으로 새로운 궁극기 또는 궁극기 레벨업이 된다.




