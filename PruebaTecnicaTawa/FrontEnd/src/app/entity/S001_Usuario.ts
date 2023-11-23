export class S001_Usuario {
    constructor(
    public CodUsuario?: string,
    public CodMedico?: string,
    public NombreCompleto?: string,
    public IdPerfil?: number,
    public Login?: string,
    public Password?: string,
    public ConfirmarPassword?: string,
    public Nombres?: string,
    public ApellidoPaterno?: string,
    public ApellidoMaterno?: string,
    public Correo?: string,
    public Token?: string,
    public FlagRecuperacionPwd?: boolean
    ) { }
  }
