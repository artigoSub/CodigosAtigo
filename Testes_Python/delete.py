import requests
from concurrent.futures import ThreadPoolExecutor

# Função para realizar a solicitação GET e obter todos os IDs dos produtos
def get_all_product_ids():
    url = "http://localhost:5213/api/Produto"
    response = requests.get(url)
    if response.status_code == 200:
        products = response.json()
        return [product["id"] for product in products]
    else:
        return []

def send_delete_request(product_id):
    url = f"http://localhost:5213/api/Produto/{product_id}"
    response = requests.delete(url)
    return response

if __name__ == "__main__":
    product_ids = get_all_product_ids() 
    with ThreadPoolExecutor(max_workers=100) as executor:
        results = list(executor.map(send_delete_request, product_ids))


    for result in results:
        if result.status_code == 200:

    for result in results:
        if result.status_code == 200:
            print("Requisição DELETE bem-sucedida!")
        else:
            print("Falha na requisição DELETE.")
            print("Resposta:", result.text)


# Para mudar a quantidade de usuários basta mudar o valor da linha 24 na propriedade "max_workers"
