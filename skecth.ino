// Defina os pinos que você deseja usar como leitores
const int pinoLeitor1 = 2; // Exemplo de pino digital
const int pinoLeitor2 = 3; // Exemplo de outro pino digital

void setup() {
  // Inicializa as portas como entradas
  pinMode(pinoLeitor1, INPUT);
  pinMode(pinoLeitor2, INPUT);
  // Inicializa a comunicação serial
  Serial.begin(9600);
}

void loop() {
  // Lê os valores das portas
  int valorLeitura1 = digitalRead(pinoLeitor1);
  int valorLeitura2 = digitalRead(pinoLeitor2);

  // Verifica se os valores lidos são altos
  if (valorLeitura1 == HIGH) {
    Serial.println("Entry();");
  }

  if (valorLeitura2 == HIGH) {
    Serial.println("Exit();");
  }

  // Aguarda um curto período de tempo antes de fazer a próxima leitura
  delay(1000);
}
