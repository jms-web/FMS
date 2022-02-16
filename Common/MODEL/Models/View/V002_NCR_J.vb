Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports PropertyChanged

<AddINotifyPropertyChangedInterface>
Partial Public Class V002_NCR_J
    Inherits ModelBase
    Implements IDisposable

    Public Shadows Sub Clear()
        ZESEI_SYOCHI_YOHI_KB = "0"
    End Sub

    <StringLength(10)>
    <ComponentModel.DisplayName("�񍐏�No")>
    Public Property HOKOKU_NO As String

    <StringLength(1)>
    <ComponentModel.DisplayName("����敪")>
    Public Property BUMON_KB As String

    <StringLength(30)>
    <ComponentModel.DisplayName("���喼")>
    Public Property BUMON_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�N���[�Y�t���O")>
    Public Property CLOSE_FG As String

    <ComponentModel.DisplayName("�@��ID")>
    Public Property KISYU_ID As Integer

    '<StringLength(30)>
    '<ComponentModel.DisplayName("�@��")>
    'Public Property KISYU As String

    <StringLength(30)>
    <ComponentModel.DisplayName("�@�햼")>
    Public Property KISYU_NAME As String

    <StringLength(30)>
    <ComponentModel.DisplayName("�Г��R�[�h")>
    Public Property SYANAI_CD As String

    <StringLength(60)>
    <ComponentModel.DisplayName("���i�ԍ�")>
    Public Property BUHIN_BANGO As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���i����")>
    Public Property BUHIN_NAME As String

    <StringLength(5)>
    <ComponentModel.DisplayName("���@")>
    Public Property GOKI As String

    <ComponentModel.DisplayName("����")>
    Public Property SURYO As Integer

    <StringLength(10)>
    <ComponentModel.DisplayName("�Ĕ�")>
    Public Property SAIHATU As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�s�K����ԋ敪")>
    Public Property FUTEKIGO_JYOTAI_KB As String

    <StringLength(30)>
    <ComponentModel.DisplayName("�s�K����ԋ敪��")>
    Public Property FUTEKIGO_JYOTAI_NAME As String

    <StringLength(30)>
    <ComponentModel.DisplayName("�s�K����ԓ��e")>
    Public Property FUTEKIGO_NAIYO As String

    <ComponentModel.DisplayName("�s�K���敪")>
    Public Property FUTEKIGO_KB As String

    <ComponentModel.DisplayName("�s�K���敪��")>
    Public Property FUTEKIGO_NAME As String

    <ComponentModel.DisplayName("�s�K���ڍ׋敪")>
    Public Property FUTEKIGO_S_KB As String

    <ComponentModel.DisplayName("�s�K���ڍ׋敪��")>
    Public Property FUTEKIGO_S_NAME As String

    <StringLength(30)>
    <ComponentModel.DisplayName("�}�ʋK�i")>
    Public Property ZUMEN_KIKAKU As String

    <StringLength(500)>
    <ComponentModel.DisplayName("�v�����e")>
    Public Property YOKYU_NAIYO As String

    <StringLength(500)>
    <ComponentModel.DisplayName("�ώ@����")>
    Public Property KANSATU_KEKKA As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�������u�v�ۋ敪")>
    Public Property ZESEI_SYOCHI_YOHI_KB As String

    <StringLength(100)>
    <ComponentModel.DisplayName("�������u�����R")>
    Public Property ZESEI_NASI_RIYU As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���O�R������敪")>
    Public Property JIZEN_SINSA_HANTEI_KB As String

    <ComponentModel.DisplayName("���O�R���Ј�ID")>
    Public Property JIZEN_SINSA_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("���O�R���Ј���")>
    Public Property JIZEN_SINSA_SYAIN_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("���O�R����")>
    Public Property JIZEN_SINSA_YMD As String

    <ComponentModel.DisplayName("�ĐR�ψ��m�F�Ј�ID")>
    Public Property SAISIN_KAKUNIN_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�ĐR�ψ��m�F�Ј���")>
    Public Property SAISIN_KAKUNIN_SYAIN_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�ĐR�ψ��m�F��")>
    Public Property SAISIN_KAKUNIN_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�ĐR�ψ����敪")>
    Public Property SAISIN_IINKAI_HANTEI_KB As String

    <ComponentModel.DisplayName("�ĐR�ψ��Z�p�Ј�ID")>
    Public Property SAISIN_GIJYUTU_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�ĐR�ψ��Z�p�Ј���")>
    Public Property SAISIN_GIJYUTU_SYAIN_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�ĐR�ψ��Z�p�m�F��")>
    Public Property SAISIN_GIJYUTU_YMD As String

    <ComponentModel.DisplayName("�ĐR�ψ��i�؎Ј�ID")>
    Public Property SAISIN_HINSYO_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�ĐR�ψ��i�؎Ј���")>
    Public Property SAISIN_HINSYO_SYAIN_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�ĐR�ψ��i�؊m�F��")>
    Public Property SAISIN_HINSYO_YMD As String

    <StringLength(2)>
    <ComponentModel.DisplayName("�ĐR�ψ����No")>
    Public Property SAISIN_IINKAI_SIRYO_NO As String

    <StringLength(20)>
    <ComponentModel.DisplayName("ITAGNo")>
    Public Property ITAG_NO As String

    <ComponentModel.DisplayName("�ڋq�ĐR�\���S��ID")>
    Public Property KOKYAKU_SAISIN_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�ڋq�ĐR�\���S����")>
    Public Property KOKYAKU_SAISIN_TANTO_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�ڋq�ĐR�\����")>
    Public Property KOKYAKU_SAISIN_YMD As String

    <StringLength(200)>
    <ComponentModel.DisplayName("�ڋq�ĐR�\����")>
    Public Property KOKYAKU_SAISIN_FILEPATH1 As String

    <StringLength(200)>
    <ComponentModel.DisplayName("�ڋq�ĐR�\����")>
    Public Property KOKYAKU_SAISIN_FILEPATH2 As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�ڋq����w���敪")>
    Public Property KOKYAKU_HANTEI_SIJI_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�ڋq����w���敪��")>
    Public Property KOKYAKU_HANTEI_SIJI_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�ڋq����w����")>
    Public Property KOKYAKU_HANTEI_SIJI_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�ڋq�ŏI����敪")>
    Public Property KOKYAKU_SAISYU_HANTEI_KB As String

    <StringLength(30)>
    <ComponentModel.DisplayName("�ڋq�ŏI����敪��")>
    Public Property KOKYAKU_SAISYU_HANTEI_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�ڋq�ŏI�����")>
    Public Property KOKYAKU_SAISYU_HANTEI_YMD As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�p�p�N����")>
    Public Property HAIKYAKU_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�p�p���@�敪")>
    Public Property HAIKYAKU_KB As String

    <StringLength(30)>
    <ComponentModel.DisplayName("�p�p���@�敪��")>
    Public Property HAIKYAKU_KB_NAME As String

    <StringLength(30)>
    <ComponentModel.DisplayName("�p�p���@���e")>
    Public Property HAIKYAKU_HOUHOU As String

    <ComponentModel.DisplayName("�p�p���{��ID")>
    Public Property HAIKYAKU_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�p�p���{�Җ�")>
    Public Property HAIKYAKU_TANTO_NAME As String

    <StringLength(10)>
    <ComponentModel.DisplayName("�ĉ��H�w������No")>
    Public Property SAIKAKO_SIJI_NO As String

    <ComponentModel.DisplayName("�ĉ��H�w���t���O")>
    Public Property SAIKAKO_SIJI_FG As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�ĉ��H��Ɗ�����")>
    Public Property SAIKAKO_SAGYO_KAN_YMD As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�ĉ��H�����N����")>
    Public Property SAIKAKO_KENSA_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("�������ʋ敪")>
    Public Property KENSA_KEKKA_KB As String

    <StringLength(50)>
    <ComponentModel.DisplayName("�������ʋ敪��")>
    Public Property KENSA_KEKKA_NAME As String

    <ComponentModel.DisplayName("���Z�Ј�ID")>
    Public Property SEIGI_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("���Z�Ј���")>
    Public Property SEIGI_TANTO_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("���Z�m�F�N����")>
    Public Property SEIGI_KAKUNIN_YMD As String

    <ComponentModel.DisplayName("�����Ј�ID")>
    Public Property SEIZO_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�����Ј���")>
    Public Property SEIZO_TANTO_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�����m�F�N����")>
    Public Property SEIZO_KAKUNIN_YMD As String

    <ComponentModel.DisplayName("�����Ј�ID")>
    Public Property KENSA_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�����Ј���")>
    Public Property KENSA_TANTO_NAME As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�����m�F�N����")>
    Public Property KENSA_KAKUNIN_YMD As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�ԋp�N����")>
    Public Property HENKYAKU_YMD As String

    <StringLength(60)>
    <ComponentModel.DisplayName("�ԋp��")>
    Public Property HENKYAKU_SAKI As String

    <ComponentModel.DisplayName("�ԋp���{��ID")>
    Public Property HENKYAKU_TANTO_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�ԋp���{�Җ�")>
    Public Property HENKYAKU_TANTO_NAME As String

    <StringLength(100)>
    <ComponentModel.DisplayName("�ԋp���{���l")>
    Public Property HENKYAKU_BIKO As String

    <ComponentModel.DisplayName("�]�p��@��ID")>
    Public Property TENYO_KISYU_ID As Integer

    <StringLength(50)>
    <ComponentModel.DisplayName("�]�p��@��")>
    Public Property TENYO_KISYU_NAME As String

    <StringLength(60)>
    <ComponentModel.DisplayName("�]�p�敔�i�ԍ�")>
    Public Property TENYO_BUHIN_BANGO As String

    <StringLength(5)>
    <ComponentModel.DisplayName("�]�p�捆�@")>
    Public Property TENYO_GOKI As String

    <ComponentModel.DisplayName("�]�p��LOT")>
    Public Property TENYO_LOT As String

    <StringLength(8)>
    <ComponentModel.DisplayName("�]�p�N����")>
    Public Property TENYO_YMD As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���u����a")>
    Public Property SYOCHI_KEKKA_A As String

    <StringLength(50)>
    <ComponentModel.DisplayName("���u����a��")>
    Public Property SYOCHI_KEKKA_A_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���u����b")>
    Public Property SYOCHI_KEKKA_B As String

    <StringLength(50)>
    <ComponentModel.DisplayName("���u����b��")>
    Public Property SYOCHI_KEKKA_B_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���u����c")>
    Public Property SYOCHI_KEKKA_C As String

    <StringLength(50)>
    <ComponentModel.DisplayName("���u����c��")>
    Public Property SYOCHI_KEKKA_C_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���ud�L���敪")>
    Public Property SYOCHI_D_UMU_KB As String

    <StringLength(10)>
    <ComponentModel.DisplayName("���ud�L���敪��")>
    Public Property SYOCHI_D_UMU_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���ud�v�ۋ敪")>
    Public Property SYOCHI_D_YOHI_KB As String

    <StringLength(10)>
    <ComponentModel.DisplayName("���ud�v�ۋ敪��")>
    Public Property SYOCHI_D_YOHI_NAME As String

    <StringLength(100)>
    <ComponentModel.DisplayName("���ud���u�L�^")>
    Public Property SYOCHI_D_SYOCHI_KIROKU As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���ue�L���敪")>
    Public Property SYOCHI_E_UMU_KB As String

    <StringLength(10)>
    <ComponentModel.DisplayName("���ue�L���敪��")>
    Public Property SYOCHI_E_UMU_NAME As String

    <StringLength(1)>
    <ComponentModel.DisplayName("���ue�v�ۋ敪")>
    Public Property SYOCHI_E_YOHI_KB As String

    <StringLength(10)>
    <ComponentModel.DisplayName("���ue�v�ۋ敪��")>
    Public Property SYOCHI_E_YOHI_NAME As String

    <StringLength(100)>
    <ComponentModel.DisplayName("���ue���u�L�^")>
    Public Property SYOCHI_E_SYOCHI_KIROKU As String

    <StringLength(200)>
    <ComponentModel.DisplayName("�t�@�C���p�X")>
    Public Property FILE_PATH As String

    <StringLength(200)>
    <ComponentModel.DisplayName("�摜�t�@�C���p�X1")>
    Public Property G_FILE_PATH1 As String

    <StringLength(200)>
    <ComponentModel.DisplayName("�摜�t�@�C���p�X2")>
    Public Property G_FILE_PATH2 As String

    <ComponentModel.DisplayName("�����H��GL�m�F�S��")>
    Public Property HASSEI_KOTEI_GL_SYAIN_ID As Integer

    <ComponentModel.DisplayName("�������ߕ񍐏��N���S��")>
    Public Property FCR_KISO_TANTO_ID As Integer

    <StringLength(14)>
    <ComponentModel.DisplayName("�ǉ�����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_YMDHNS As String

    <DoNotNotify>
    <Display(AutoGenerateField:=False)>
    <NotMapped>
    Public ReadOnly Property ADD_YMD As String
        Get
            Dim strRET As String
            If ADD_YMDHNS IsNot Nothing AndAlso ADD_YMDHNS.Length = 14 Then
                strRET = DateTime.ParseExact(ADD_YMDHNS, "yyyyMMddHHmmss", Nothing).ToString("yyyyMMdd")
            Else
                strRET = ""
            End If
            Return strRET
        End Get
    End Property

    <ComponentModel.DisplayName("�ǉ��S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�ǉ��S����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property ADD_SYAIN_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("�X�V����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_YMDHNS As String

    <ComponentModel.DisplayName("�X�V�S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�X�V�S����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property UPD_SYAIN_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("�폜����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_YMDHNS As String

    <ComponentModel.DisplayName("�폜�S��ID")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_ID As Integer

    <StringLength(30)>
    <ComponentModel.DisplayName("�폜�S����")>
    <DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property DEL_SYAIN_NAME As String

    <StringLength(14)>
    <ComponentModel.DisplayName("�����H��GL�N����")>
    Public Property HASSEI_KOTEI_GL_YMD As String

    <StringLength(30)>
    <ComponentModel.DisplayName("�����H��GL�m�F�S����")>
    Public Property HASSEI_KOTEI_GL_SYAIN_NAME As String

    <ComponentModel.DisplayName("������")>
    Public Property HASSEI_YMD As String

    <ComponentModel.DisplayName("�ĕs�K���N���S����")>
    Public Property SAI_FUTEKIGO_KISO_TANTO_ID As Integer

    ''' <summary>
    ''' �ĉ��H �s���i��
    ''' </summary>
    ''' <returns></returns>
    Public Property SAI_KAKO_NG_SURYO As Integer

    ''' <summary>
    ''' �ĉ��H�R�����g
    ''' </summary>
    ''' <returns></returns>
    Public Property SAI_KAKO_COMMENT As String

#Region "IDisposable Support"

    Private disposedValue As Boolean ' �d������Ăяo�������o����ɂ�

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: �}�l�[�W��Ԃ�j�����܂� (�}�l�[�W �I�u�W�F�N�g)�B
            End If

            ' TODO: �A���}�l�[�W ���\�[�X (�A���}�l�[�W �I�u�W�F�N�g) ��������A���� Finalize() ���I�[�o�[���C�h���܂��B
            ' TODO: �傫�ȃt�B�[���h�� null �ɐݒ肵�܂��B
        End If
        disposedValue = True
    End Sub

    ' TODO: ��� Dispose(disposing As Boolean) �ɃA���}�l�[�W ���\�[�X���������R�[�h���܂܂��ꍇ�ɂ̂� Finalize() ���I�[�o�[���C�h���܂��B
    'Protected Overrides Sub Finalize()
    '    ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(disposing As Boolean) �ɋL�q���܂��B
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' ���̃R�[�h�́A�j���\�ȃp�^�[���𐳂��������ł���悤�� Visual Basic �ɂ���Ēǉ�����܂����B
    Public Sub Dispose() Implements IDisposable.Dispose
        ' ���̃R�[�h��ύX���Ȃ��ł��������B�N���[���A�b�v �R�[�h����� Dispose(disposing As Boolean) �ɋL�q���܂��B
        Dispose(True)
        ' TODO: ��� Finalize() ���I�[�o�[���C�h����Ă���ꍇ�́A���̍s�̃R�����g���������Ă��������B
        ' GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class