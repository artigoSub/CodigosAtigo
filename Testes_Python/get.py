import requests
from concurrent.futures import ThreadPoolExecutor

def send_get_request(_):
    url = "http://localhost:5213/api/Produto"
    response = requests.get(url)
    return response

if __name__ == "__main__":
    successful_responses = 0  

    with ThreadPoolExecutor(max_workers=100) as executor:
        results = list(executor.map(send_get_request, range(100)))


    for result in results:
        if result.status_code == 200:

    for result in results:
        if result.status_code == 200:
            print("Requisição GET bem-sucedida!")
        else:
            print("Falha na requisição GET.")
            print("Resposta:", result.text)
            
# Para mudar a quantidade de usuários basta mudar o valor da linha 12 na propriedade "max_workers" e "range" na linha 13 
