# Proyecto Itrivia

El proyecto es un juego de trivias, donde un usuario va a poder registrarse y disfrutar de las distintas secciones y desafíos disponibles sobre un tema en particular, respondiendo diferentes tipos de preguntas acerca del desafío seleccionado. Los juegos van a poder darse de alta y ser configurado con un usuario administrador. El jugador va tener un perfil, donde va acumularse el puntaje ganado al finalizar cada desafío. Existirá también estadística acerca de su progreso semanal y ranking general de todos los usuarios registrados. La aplicación es multiidiomas, para el desarrollo va a soportar el idioma español y english.

El juego tiene tres modos para jugar: AutoCompletado, MultipleChoise y Seleccion de Pares.

Tecnologia Utilizadas :

Base de Datos : Sql Server 2019

Backend : .Net 6 / ORM Entity Framework

FrontEnd: Angular 12

La api de la aplicación se encuentra documentada, con la librería swagger accediendo a esta dirección.

http://localhost/swagger/index.html (Se debe deployar la api)

Se adjunta esquema de endpoints, exportado desde swagger.

{
  "openapi": "3.0.1",
  "info": {
    "title": "Itrivia.WebApi",
    "version": "1.0"
  },
  "paths": {
    "/api/Autocomplete": {
      "get": {
        "tags": [
          "Autocomplete"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Autocomplete"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AutoCompleteAndStepDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AutoCompleteAndStepDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AutoCompleteAndStepDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Autocomplete"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/AutoCompleteAndStepDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/AutoCompleteAndStepDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/AutoCompleteAndStepDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Autocomplete"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Autocomplete/{id}": {
      "get": {
        "tags": [
          "Autocomplete"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Autocomplete/{id}/validateanswer": {
      "get": {
        "tags": [
          "Autocomplete"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "answer",
            "in": "query",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Category": {
      "get": {
        "tags": [
          "Category"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Category"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GesTcategoria"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GesTcategoria"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GesTcategoria"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Category"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/CategoryDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/CategoryDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/CategoryDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Category"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Category/{id}": {
      "get": {
        "tags": [
          "Category"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Challenge": {
      "get": {
        "tags": [
          "Challenge"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Challenge"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ChallengeDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ChallengeDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ChallengeDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Challenge"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ChallengeDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ChallengeDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ChallengeDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Challenge"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Challenge/{id}": {
      "get": {
        "tags": [
          "Challenge"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Section/{sectionId}/Challenge": {
      "get": {
        "tags": [
          "Challenge"
        ],
        "parameters": [
          {
            "name": "sectionId",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/GameType": {
      "get": {
        "tags": [
          "GameType"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "GameType"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GesPtipoJuego"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GesPtipoJuego"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GesPtipoJuego"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "GameType"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GesPtipoJuego"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GesPtipoJuego"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GesPtipoJuego"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "GameType"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/GameType/{id}": {
      "get": {
        "tags": [
          "GameType"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/HistoryPD": {
      "get": {
        "tags": [
          "HistoryPD"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "HistoryPD"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilDesafio"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilDesafio"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilDesafio"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "HistoryPD"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilDesafio"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilDesafio"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilDesafio"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "HistoryPD"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/HistoryPD/{id}": {
      "get": {
        "tags": [
          "HistoryPD"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/HistoryPD/GetHpdByProfileId": {
      "get": {
        "tags": [
          "HistoryPD"
        ],
        "parameters": [
          {
            "name": "profileId",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/HistoryPD/WeeklyExperienceByProfile/{id}": {
      "get": {
        "tags": [
          "HistoryPD"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/HistoryPS": {
      "get": {
        "tags": [
          "HistoryPS"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "HistoryPS"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilSeccione"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilSeccione"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilSeccione"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "HistoryPS"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilSeccione"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilSeccione"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GesThistPerfilSeccione"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "HistoryPS"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/HistoryPS/{id}": {
      "get": {
        "tags": [
          "HistoryPS"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Label/{id}": {
      "get": {
        "tags": [
          "Label"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "object",
                  "additionalProperties": {
                    "type": "string"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "object",
                  "additionalProperties": {
                    "type": "string"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "object",
                  "additionalProperties": {
                    "type": "string"
                  }
                }
              }
            }
          }
        }
      }
    },
    "/api/Login/Authenticate": {
      "post": {
        "tags": [
          "Login"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UserCredentials"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UserCredentials"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UserCredentials"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Login/RefreshToken": {
      "get": {
        "tags": [
          "Login"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Messages/{id}": {
      "get": {
        "tags": [
          "Messages"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "object",
                  "additionalProperties": {
                    "type": "string"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "object",
                  "additionalProperties": {
                    "type": "string"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "object",
                  "additionalProperties": {
                    "type": "string"
                  }
                }
              }
            }
          }
        }
      }
    },
    "/api/MultipleChoice": {
      "get": {
        "tags": [
          "MultipleChoice"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "MultipleChoice"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/MultipleChoiceAndStepDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/MultipleChoiceAndStepDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/MultipleChoiceAndStepDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "MultipleChoice"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/MultipleChoiceAndStepDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/MultipleChoiceAndStepDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/MultipleChoiceAndStepDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "MultipleChoice"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/MultipleChoice/{id}": {
      "get": {
        "tags": [
          "MultipleChoice"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/PairSelection": {
      "get": {
        "tags": [
          "PairSelection"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "PairSelection"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/PairSelectionAndStepDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/PairSelectionAndStepDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/PairSelectionAndStepDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "PairSelection"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/PairSelectionAndStepDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/PairSelectionAndStepDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/PairSelectionAndStepDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "PairSelection"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/PairSelection/{id}": {
      "get": {
        "tags": [
          "PairSelection"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/PairSelection/Validate": {
      "post": {
        "tags": [
          "PairSelection"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/RequestPairSelectionDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/RequestPairSelectionDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/RequestPairSelectionDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Profile": {
      "get": {
        "tags": [
          "Profile"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Profile"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ProfileDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ProfileDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ProfileDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Profile/{id}": {
      "get": {
        "tags": [
          "Profile"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Profile"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ProfileDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/ProfileDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/ProfileDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Profile"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Profile/AddExperence/{id}": {
      "put": {
        "tags": [
          "Profile"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "challengeId",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Rol/{id}": {
      "get": {
        "tags": [
          "Rol"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Section": {
      "get": {
        "tags": [
          "Section"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Section"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SectionDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SectionDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SectionDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Section"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Section/{id}": {
      "get": {
        "tags": [
          "Section"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Section"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SectionDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/SectionDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/SectionDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Section/GetSectionFilter": {
      "get": {
        "tags": [
          "Section"
        ],
        "parameters": [
          {
            "name": "profileId",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "categoryId",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          },
          {
            "name": "search",
            "in": "query",
            "schema": {
              "type": "string"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Step": {
      "get": {
        "tags": [
          "Step"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "Step"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GesTetapa"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GesTetapa"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GesTetapa"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "Step"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/GesTetapa"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/GesTetapa"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/GesTetapa"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "Step"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Step/detail": {
      "get": {
        "tags": [
          "Step"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/Step/GetStepByChallenge": {
      "get": {
        "tags": [
          "Step"
        ],
        "parameters": [
          {
            "name": "challengeId",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/User": {
      "get": {
        "tags": [
          "User"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "post": {
        "tags": [
          "User"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UserRequestDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UserRequestDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UserRequestDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "put": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UserUpdateRequestDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UserUpdateRequestDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UserUpdateRequestDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      },
      "delete": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "query",
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/User/{id}": {
      "get": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/User/detail/{id}": {
      "get": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/User/SummaryUserProfile": {
      "get": {
        "tags": [
          "User"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/User/api/user/resetpassword/{id}": {
      "put": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/UserResetPasswordDto"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/UserResetPasswordDto"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/UserResetPasswordDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/WeatherForecast": {
      "get": {
        "tags": [
          "WeatherForecast"
        ],
        "operationId": "GetWeatherForecast",
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              },
              "text/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              }
            }
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "AutoCompleteAndStepDto": {
        "type": "object",
        "properties": {
          "AutoCompleteDto": {
            "$ref": "#/components/schemas/AutoCompleteDto"
          },
          "StepDto": {
            "$ref": "#/components/schemas/StepDto"
          }
        },
        "additionalProperties": false
      },
      "AutoCompleteDto": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "IsDeleted": {
            "type": "boolean"
          },
          "CreateDate": {
            "type": "string",
            "format": "date-time"
          },
          "ModifyDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "User": {
            "type": "string",
            "nullable": true
          },
          "Enunciate": {
            "type": "string",
            "nullable": true
          },
          "Answer": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "CategoryDto": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "IsDeleted": {
            "type": "boolean"
          },
          "CreateDate": {
            "type": "string",
            "format": "date-time"
          },
          "ModifyDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "User": {
            "type": "string",
            "nullable": true
          },
          "Name": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ChallengeDto": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "IsDeleted": {
            "type": "boolean"
          },
          "CreateDate": {
            "type": "string",
            "format": "date-time"
          },
          "ModifyDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "User": {
            "type": "string",
            "nullable": true
          },
          "Name": {
            "type": "string",
            "nullable": true
          },
          "Description": {
            "type": "string",
            "nullable": true
          },
          "SectionId": {
            "type": "integer",
            "format": "int32"
          },
          "Experience": {
            "type": "integer",
            "format": "int32"
          },
          "StepsCount": {
            "type": "integer",
            "format": "int32"
          },
          "Activated": {
            "type": "boolean"
          }
        },
        "additionalProperties": false
      },
      "GesPtipoJuego": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Nombre": {
            "type": "string",
            "nullable": true
          },
          "Codigo": {
            "type": "string",
            "nullable": true
          },
          "GesTetapas": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesTetapa"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "GesTautocompletado": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Enunciado": {
            "type": "string",
            "nullable": true
          },
          "Respuesta": {
            "type": "string",
            "nullable": true
          },
          "GesTetapas": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesTetapa"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "GesTcategoria": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Nombre": {
            "type": "string",
            "nullable": true
          },
          "GesTsecciones": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesTseccione"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "GesTdesafio": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Nombre": {
            "type": "string",
            "nullable": true
          },
          "Descripcion": {
            "type": "string",
            "nullable": true
          },
          "IdSeccion": {
            "type": "integer",
            "format": "int32"
          },
          "Experiencia": {
            "type": "integer",
            "format": "int32"
          },
          "CantEtapas": {
            "type": "integer",
            "format": "int32"
          },
          "Activated": {
            "type": "boolean"
          },
          "IdSeccionNavigation": {
            "$ref": "#/components/schemas/GesTseccione"
          },
          "GesTetapas": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesTetapa"
            },
            "nullable": true
          },
          "GesThistPerfilDesafios": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesThistPerfilDesafio"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "GesTetapa": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Nombre": {
            "type": "string",
            "nullable": true
          },
          "IdDesafio": {
            "type": "integer",
            "format": "int32"
          },
          "IdTipoJuego": {
            "type": "integer",
            "format": "int32"
          },
          "IdAutocompletado": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "IdMchoice": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "IdSpares": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "IdAutocompletadoNavigation": {
            "$ref": "#/components/schemas/GesTautocompletado"
          },
          "IdDesafioNavigation": {
            "$ref": "#/components/schemas/GesTdesafio"
          },
          "IdMchoiceNavigation": {
            "$ref": "#/components/schemas/GesTmultiplechoice"
          },
          "IdSparesNavigation": {
            "$ref": "#/components/schemas/GesTselecPare"
          },
          "IdTipoJuegoNavigation": {
            "$ref": "#/components/schemas/GesPtipoJuego"
          }
        },
        "additionalProperties": false
      },
      "GesThistPerfilDesafio": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "IdPerfil": {
            "type": "integer",
            "format": "int32"
          },
          "IdDesafio": {
            "type": "integer",
            "format": "int32"
          },
          "IdDesafioNavigation": {
            "$ref": "#/components/schemas/GesTdesafio"
          },
          "IdPerfilNavigation": {
            "$ref": "#/components/schemas/GesTperfile"
          }
        },
        "additionalProperties": false
      },
      "GesThistPerfilSeccione": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "IdPerfil": {
            "type": "integer",
            "format": "int32"
          },
          "IdSeccion": {
            "type": "integer",
            "format": "int32"
          },
          "IdSeccionNavigation": {
            "$ref": "#/components/schemas/GesTseccione"
          }
        },
        "additionalProperties": false
      },
      "GesTmultiplechoice": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Enunciado": {
            "type": "string",
            "nullable": true
          },
          "OpcionCorrecta": {
            "type": "string",
            "nullable": true
          },
          "Opcion1": {
            "type": "string",
            "nullable": true
          },
          "Opcion2": {
            "type": "string",
            "nullable": true
          },
          "GesTetapas": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesTetapa"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "GesTperfile": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Exp": {
            "type": "integer",
            "format": "int32"
          },
          "SegTusuario": {
            "$ref": "#/components/schemas/SegTusuario"
          },
          "GesThistPerfilDesafios": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesThistPerfilDesafio"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "GesTseccione": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Nombre": {
            "type": "string",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Descripcion": {
            "type": "string",
            "nullable": true
          },
          "IdCategoria": {
            "type": "integer",
            "format": "int32"
          },
          "UrlImagen": {
            "type": "string",
            "nullable": true
          },
          "CantDesafios": {
            "type": "integer",
            "format": "int32"
          },
          "Activated": {
            "type": "boolean"
          },
          "IdCategoriaNavigation": {
            "$ref": "#/components/schemas/GesTcategoria"
          },
          "GesTdesafios": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesTdesafio"
            },
            "nullable": true
          },
          "GesThistPerfilSecciones": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesThistPerfilSeccione"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "GesTselecPare": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Opcion1": {
            "type": "string",
            "nullable": true
          },
          "Respuesta1": {
            "type": "string",
            "nullable": true
          },
          "Opcion2": {
            "type": "string",
            "nullable": true
          },
          "Respuesta2": {
            "type": "string",
            "nullable": true
          },
          "Opcion3": {
            "type": "string",
            "nullable": true
          },
          "Respuesta3": {
            "type": "string",
            "nullable": true
          },
          "Opcion4": {
            "type": "string",
            "nullable": true
          },
          "Respuesta4": {
            "type": "string",
            "nullable": true
          },
          "GesTetapas": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/GesTetapa"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "MultipleChoiceAndStepDto": {
        "type": "object",
        "properties": {
          "MultipleChoiceDto": {
            "$ref": "#/components/schemas/MultipleChoiceDto"
          },
          "StepDto": {
            "$ref": "#/components/schemas/StepDto"
          }
        },
        "additionalProperties": false
      },
      "MultipleChoiceDto": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "IsDeleted": {
            "type": "boolean"
          },
          "CreateDate": {
            "type": "string",
            "format": "date-time"
          },
          "ModifyDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "User": {
            "type": "string",
            "nullable": true
          },
          "Enunciate": {
            "type": "string",
            "nullable": true
          },
          "CorrectOption": {
            "type": "string",
            "nullable": true
          },
          "FirstOption": {
            "type": "string",
            "nullable": true
          },
          "SecondOption": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "PairSelectionAndStepDto": {
        "type": "object",
        "properties": {
          "PairSelectionDto": {
            "$ref": "#/components/schemas/PairSelectionDto"
          },
          "StepDto": {
            "$ref": "#/components/schemas/StepDto"
          }
        },
        "additionalProperties": false
      },
      "PairSelectionDto": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "IsDeleted": {
            "type": "boolean"
          },
          "CreateDate": {
            "type": "string",
            "format": "date-time"
          },
          "ModifyDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "User": {
            "type": "string",
            "nullable": true
          },
          "FirstOption": {
            "type": "string",
            "nullable": true
          },
          "FirstAnswer": {
            "type": "string",
            "nullable": true
          },
          "SecondOption": {
            "type": "string",
            "nullable": true
          },
          "SecondAnswer": {
            "type": "string",
            "nullable": true
          },
          "ThirdOption": {
            "type": "string",
            "nullable": true
          },
          "ThirdAnswer": {
            "type": "string",
            "nullable": true
          },
          "FourthOption": {
            "type": "string",
            "nullable": true
          },
          "FourthAnswer": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ParPimagene": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Codigo": {
            "type": "string",
            "nullable": true
          },
          "UrlImagen": {
            "type": "string",
            "nullable": true
          },
          "SegTusuarios": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/SegTusuario"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ProfileDto": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "IsDeleted": {
            "type": "boolean"
          },
          "CreateDate": {
            "type": "string",
            "format": "date-time"
          },
          "ModifyDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "User": {
            "type": "string",
            "nullable": true
          },
          "Experience": {
            "type": "integer",
            "format": "int32"
          }
        },
        "additionalProperties": false
      },
      "RequestPairSelectionDto": {
        "type": "object",
        "properties": {
          "Option": {
            "type": "string",
            "nullable": true
          },
          "Pair": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SectionDto": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "IsDeleted": {
            "type": "boolean"
          },
          "CreateDate": {
            "type": "string",
            "format": "date-time"
          },
          "ModifyDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "User": {
            "type": "string",
            "nullable": true
          },
          "Name": {
            "type": "string",
            "nullable": true
          },
          "Description": {
            "type": "string",
            "nullable": true
          },
          "CategoryId": {
            "type": "integer",
            "format": "int32"
          },
          "ChallengeCount": {
            "type": "integer",
            "format": "int32"
          },
          "Url_Image": {
            "type": "string",
            "nullable": true
          },
          "Activated": {
            "type": "boolean"
          }
        },
        "additionalProperties": false
      },
      "SegProle": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Nombre": {
            "type": "string",
            "nullable": true
          },
          "Codigo": {
            "type": "string",
            "nullable": true
          },
          "SegTusuarios": {
            "type": "array",
            "items": {
              "$ref": "#/components/schemas/SegTusuario"
            },
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "SegTusuario": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Baja": {
            "type": "boolean"
          },
          "AltaFecha": {
            "type": "string",
            "format": "date-time"
          },
          "ModiFecha": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "Usuario": {
            "type": "string",
            "nullable": true
          },
          "Nombre": {
            "type": "string",
            "nullable": true
          },
          "Apellido": {
            "type": "string",
            "nullable": true
          },
          "Password": {
            "type": "string",
            "nullable": true
          },
          "Email": {
            "type": "string",
            "nullable": true
          },
          "IdRol": {
            "type": "integer",
            "format": "int32"
          },
          "IdPerfil": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "IdImagen": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "IdImagenNavigation": {
            "$ref": "#/components/schemas/ParPimagene"
          },
          "IdPerfilNavigation": {
            "$ref": "#/components/schemas/GesTperfile"
          },
          "IdRolNavigation": {
            "$ref": "#/components/schemas/SegProle"
          }
        },
        "additionalProperties": false
      },
      "StepDto": {
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "IsDeleted": {
            "type": "boolean"
          },
          "CreateDate": {
            "type": "string",
            "format": "date-time"
          },
          "ModifyDate": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "User": {
            "type": "string",
            "nullable": true
          },
          "Name": {
            "type": "string",
            "nullable": true
          },
          "ChallengeId": {
            "type": "string",
            "nullable": true
          },
          "GameTypeId": {
            "type": "integer",
            "format": "int32"
          },
          "AutocompleteId": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "MultipleChoiceId": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "PairSelectionId": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UserCredentials": {
        "type": "object",
        "properties": {
          "Email": {
            "type": "string",
            "nullable": true
          },
          "Password": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "UserRequestDto": {
        "required": [
          "Email",
          "LastName",
          "Name",
          "Password",
          "Password2"
        ],
        "type": "object",
        "properties": {
          "Email": {
            "type": "string"
          },
          "Password": {
            "type": "string"
          },
          "Password2": {
            "type": "string"
          },
          "Name": {
            "type": "string"
          },
          "LastName": {
            "type": "string"
          }
        },
        "additionalProperties": false
      },
      "UserResetPasswordDto": {
        "required": [
          "Id",
          "Password",
          "Password2"
        ],
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Password": {
            "type": "string"
          },
          "Password2": {
            "type": "string"
          }
        },
        "additionalProperties": false
      },
      "UserUpdateRequestDto": {
        "required": [
          "Email",
          "Id",
          "LastName",
          "Name"
        ],
        "type": "object",
        "properties": {
          "Id": {
            "type": "integer",
            "format": "int32"
          },
          "Email": {
            "type": "string"
          },
          "Name": {
            "type": "string"
          },
          "LastName": {
            "type": "string"
          }
        },
        "additionalProperties": false
      },
      "WeatherForecast": {
        "type": "object",
        "properties": {
          "Date": {
            "type": "string",
            "format": "date-time"
          },
          "TemperatureC": {
            "type": "integer",
            "format": "int32"
          },
          "TemperatureF": {
            "type": "integer",
            "format": "int32",
            "readOnly": true
          },
          "Summary": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    }
  }
}
