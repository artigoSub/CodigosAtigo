import requests
from concurrent.futures import ThreadPoolExecutor

def send_post_request(_):
    url = "http://localhost:5213/api/Produto"
    data = {
        "id": "",
        "nome": "Produto Teste",
        "preco": 10.99,
        "data_validade": "2023-12-31",
    }
    response = requests.post(url, json=data)
    return response

if __name__ == "__main__":
    with ThreadPoolExecutor(max_workers=100) as executor:
        results = list(executor.map(send_post_request, range(100)))

 
    for result in results:
        if result.status_code == 200:

    for result in results:
        if result.status_code == 200:
            print("Produto criado com sucesso!")
        else:
            print("Falha ao criar o produto.")
            print("Resposta:", result.text)

 # Para mudar a quantidade de usuários basta mudar o valor da linha 16 na propriedade "max_workers" e "range" na linha 17 
